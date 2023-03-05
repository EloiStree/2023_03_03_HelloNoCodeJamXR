using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using Eloi;

public class PerformanceCheckingUnityEventMono : MonoBehaviour
{
    public UnityEvent m_fastApproximationTest;
    public FullPerformanceTestResult m_fastApproximationResultUnityEvent;

    public uint interationsCount=100000;
    public uint groupOfTestCount=10;

    [ContextMenu("Check code in Unity Event")]
    public void CheckUnityEventLinked()
    {

        IMethodeToTest a = new UnityEventApproximationCodeToTest(m_fastApproximationTest);
        E_PerfEstimationUtility.FullCheckOf(a, out m_fastApproximationResultUnityEvent);

    }
    public void CheckDemoDelegateAction()
    {
        IMethodeToTest a = new DelegateApproximationCodeToTest(
            () => { UnityEngine.Debug.Log("Hello worlds"); });


    }


    double value = 1;
    public void MethodeATest()
    {

        value = 1;
        value *= 1.1;
    }
    public void MethodeBTest()
    {

        value = 1;
        value = value* 1.1;
    }
}
