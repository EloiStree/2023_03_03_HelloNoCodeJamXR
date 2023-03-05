using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi {


    [System.Serializable]
    public class FullPerformanceTestResult
    {
        public PerformanceResultLong m_stopWatchTick = new PerformanceResultLong();
        public PerformanceResultLong m_stopWatchMilliseconds = new PerformanceResultLong();
        public PerformanceResultDouble m_dateTimeMilliseconds = new PerformanceResultDouble();
    }

    [System.Serializable]
    public class PerformanceResult<T>
    {
        public T m_averageResult;
        public T[] m_testedResult;

        public PerformanceResult(T averageResult, T[] testedResult)
        {
            m_averageResult = averageResult;
            m_testedResult = testedResult;
        }
    }
    [System.Serializable]
    public class PerformanceResultLong : PerformanceResult<long>
    {
        public PerformanceResultLong() : base(0, new long[0])
        { }
        public PerformanceResultLong(long averageResult, long[] testedResult) : base(averageResult, testedResult)
        { }
    }
    [System.Serializable]
    public class PerformanceResultDouble : PerformanceResult<double>
    {
        public PerformanceResultDouble() : base(0, new double[0])
        { }
        public PerformanceResultDouble(double averageResult, double[] testedResult) : base(averageResult, testedResult)
        { }
    }


    public abstract class AbstractCodeToTest : IMethodeToTest
    {
        public abstract void ZhuLieDoTheThing();
    }

    public class DelegateApproximationCodeToTest : AbstractCodeToTest
    {
        private StuffToCheckMethodes m_actionToCall;
        public DelegateApproximationCodeToTest()
        {
        }
        public DelegateApproximationCodeToTest(in StuffToCheckMethodes actionToCall)
        {
            m_actionToCall = actionToCall;
        }

        public void SetAction(in StuffToCheckMethodes action)
        {
            m_actionToCall = action;
        }
        public override void ZhuLieDoTheThing()
        {
            if (m_actionToCall != null)
                m_actionToCall.Invoke();
        }
    }
    public class ActionApproximationCodeToTest : AbstractCodeToTest
    {
        private Action m_actionToCall;
        public ActionApproximationCodeToTest(in Action actionToCall)
        {
            m_actionToCall = actionToCall;
        }

        public void SetAction(in  Action action)
        {
            m_actionToCall = action;
        }
        public override void ZhuLieDoTheThing()
        {
            if (m_actionToCall != null)
                m_actionToCall.Invoke();
        }
    }

    [System.Serializable]
    public class UnityEventApproximationCodeToTest : AbstractCodeToTest
    {
        [SerializeField] UnityEvent m_actionToCall;
        public UnityEventApproximationCodeToTest()
        {
        }
        public UnityEventApproximationCodeToTest(in  UnityEvent actionToCall)
        {
            this.m_actionToCall = actionToCall;
        }

        public void SetUnityEvent(in  UnityEvent action)
        {
            m_actionToCall = action;
        }
        public override void ZhuLieDoTheThing()
        {
            if (m_actionToCall != null)
                m_actionToCall.Invoke();
        }
    }
    
    [System.Serializable]
    public class FullTestScaleFactor{

        [Header("A2B")]
        public double m_watchTickFactorA2B;
        public double m_watchMillisecondsFactorA2B;
        public double m_timeDateFactorA2B; 
        [Header("B2A")]
        public double m_watchTickFactorB2A;
        public double m_watchMillisecondsFactorB2A;
        public double m_timeDateFactorB2A;

        public static void Compute (in FullPerformanceTestResult a, in FullPerformanceTestResult b, out FullTestScaleFactor factor)
        {
            factor = new FullTestScaleFactor();
            factor.m_watchTickFactorA2B =Math.Round( (double)a.m_stopWatchTick.m_averageResult / (double)b.m_stopWatchTick.m_averageResult,3);
            factor.m_watchMillisecondsFactorA2B = Math.Round((double)a.m_stopWatchMilliseconds.m_averageResult / (double)b.m_stopWatchMilliseconds.m_averageResult, 3);
            factor.m_timeDateFactorA2B = Math.Round((double)a.m_dateTimeMilliseconds.m_averageResult / (double)b.m_dateTimeMilliseconds.m_averageResult, 3);

            factor.m_watchTickFactorB2A = Math.Round((double)b.m_stopWatchTick.m_averageResult / (double)a.m_stopWatchTick.m_averageResult, 3);
            factor.m_watchMillisecondsFactorB2A = Math.Round((double)b.m_stopWatchMilliseconds.m_averageResult / (double)a.m_stopWatchMilliseconds.m_averageResult, 3);
            factor.m_timeDateFactorB2A = Math.Round((double)b.m_dateTimeMilliseconds.m_averageResult / (double)a.m_dateTimeMilliseconds.m_averageResult, 3);

        }

    }

    [System.Serializable]
    public class PerformanceCompareResult {
        public FullTestScaleFactor m_scaleFactor;
        public FullPerformanceTestResult m_a;
        public FullPerformanceTestResult m_b;
    }

    public interface IMethodeToTest
    {
        /// <summary>
        /// #Avatar Korra: Varrick and ZhuLie
        /// https://www.youtube.com/watch?v=ojhTu9aAa_Y
        /// </summary>
         void ZhuLieDoTheThing();
    }

    public static class E_PerfEstimationUtility
    {


        public enum StopWatchType { Milliseconds, Ticks }
        public static void DoTheThingStopWatch(in IMethodeToTest theThing, in StopWatchType timeType, out long average, out long[] groupResult, uint iterationCount = 100000, uint groupCount = 10)
        {

            Stopwatch watch = new Stopwatch();
            groupResult = new long[groupCount];

            for (uint groupIndex = 0; groupIndex < groupCount; groupIndex++)
            {
                watch.Reset();
                watch.Start();
                for (uint iterationIndex = 0; iterationIndex < iterationCount; iterationIndex++)
                {
                    theThing.ZhuLieDoTheThing();
                }
                watch.Stop();

                if (timeType == StopWatchType.Milliseconds)
                    groupResult[groupIndex] = watch.ElapsedMilliseconds;
                if (timeType == StopWatchType.Ticks)
                    groupResult[groupIndex] = watch.ElapsedTicks;
            }
            long total = 0;
            for (int i = 0; i < groupCount; i++)
            {
                if (i == 0)
                    total = groupResult[i];
                else
                    total += groupResult[i];
            }
            average = total / groupCount;
        }

        public static void DoTheThingWithDatetime(in IMethodeToTest theThing, out double average, out double[] groupResult, uint iterationCount = 100000, uint groupCount = 10)
        {

            DateTime start, end;

            groupResult = new double[groupCount];

            for (uint groupIndex = 0; groupIndex < groupCount; groupIndex++)
            {
                start = DateTime.Now;
                for (uint iterationIndex = 0; iterationIndex < iterationCount; iterationIndex++)
                {
                    theThing.ZhuLieDoTheThing();
                }
                end = DateTime.Now;

                groupResult[groupIndex] = (end - start).TotalMilliseconds;
            }
            double total = 0;
            for (int i = 0; i < groupCount; i++)
            {
                if (i == 0)
                    total = groupResult[i];
                else
                    total += groupResult[i];
            }
            average = total / groupCount;
        }

        public static void FullCheckOf(in StuffToCheckMethodes methode, out FullPerformanceTestResult result, uint iterationCount = 100000, uint groupCount = 10)
        {
            IMethodeToTest toTest = new DelegateApproximationCodeToTest(methode);
            FullCheckOf(in toTest, out result, iterationCount, groupCount);
        }
        public static void FullCheckOfAToB(in StuffToCheckMethodes a, in StuffToCheckMethodes b,
          out PerformanceCompareResult report, uint iterationCount = 100000, uint groupCount = 10)
        {
            report = new PerformanceCompareResult();
            FullCheckOf(in a, out report.m_a, iterationCount, groupCount);
            FullCheckOf(in b, out report.m_b, iterationCount, groupCount);
            FullTestScaleFactor.Compute(in report.m_a, in report.m_b, out report.m_scaleFactor);
        }
        public static void FullCheckOfAToB(in IMethodeToTest methodeOne, in IMethodeToTest methodeTwo,
          out PerformanceCompareResult report, uint iterationCount = 100000, uint groupCount = 10)
        {
            report = new PerformanceCompareResult();
            FullCheckOf(in methodeOne, out report.m_a, iterationCount, groupCount);
            FullCheckOf(in methodeTwo, out report.m_b, iterationCount, groupCount);
            FullTestScaleFactor.Compute(in report.m_a, in report.m_b, out report.m_scaleFactor);
        }
        public static void FullCheckOfAToB(in IMethodeToTest methodeOne, in IMethodeToTest methodeTwo,
            out FullPerformanceTestResult resultOne, out FullPerformanceTestResult resultTwo, out FullTestScaleFactor scaleFactor,  uint iterationCount = 100000, uint groupCount = 10)
        {
            FullCheckOf(in methodeOne, out resultOne, iterationCount, groupCount);
            FullCheckOf(in methodeTwo, out resultTwo, iterationCount, groupCount);
            FullTestScaleFactor.Compute (in resultOne, in resultTwo, out scaleFactor); 
        }

        public static void FullCheckOf(in IMethodeToTest methodeToTest, out FullPerformanceTestResult result, uint iterationCount = 100000, uint groupCount = 10)
        {
            result = new FullPerformanceTestResult();
            DoTheThingStopWatch(in methodeToTest, StopWatchType.Milliseconds
                , out result.m_stopWatchMilliseconds.m_averageResult,
                out result.m_stopWatchMilliseconds.m_testedResult,
                iterationCount, groupCount);
            DoTheThingStopWatch(in methodeToTest, StopWatchType.Ticks
              , out result.m_stopWatchTick.m_averageResult,
              out result.m_stopWatchTick.m_testedResult,
              iterationCount, groupCount);
            DoTheThingWithDatetime(in methodeToTest,
                out result.m_dateTimeMilliseconds.m_averageResult,
              out result.m_dateTimeMilliseconds.m_testedResult,
              iterationCount, groupCount);

        }

    }

    public delegate void StuffToCheckMethodes();

}

