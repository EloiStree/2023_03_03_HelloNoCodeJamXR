using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Eloi
{
    public class StopWatchSingletonMono : MonoBehaviour
    {
        public double m_timeElipsedMs;
        public Eloi.PrimitiveUnityEvent_Doube m_timeElipsedChanged;
        public double m_timeAverageMs;
        public Eloi.PrimitiveUnityEvent_Doube m_timeAverageChanged;
        public void Awake()
        {
            StopWatchSingleton.m_instance = this;
        }
    }

    public class StopWatchSingleton
    {
        public static StopWatchSingletonMono m_instance;
        public static void PushAverageTime(double timeInMilliseconds)
        {
            m_instance.m_timeAverageMs = (m_instance.m_timeAverageMs + timeInMilliseconds) / 2.0;
        }

        public static void SetLastElipsedTime(double timeInMilliseconds)
        {
            m_instance.m_timeElipsedMs = timeInMilliseconds;
        }
        public static void DisplayValueInSingleton() {

            m_instance.m_timeAverageChanged.Invoke(m_instance.m_timeAverageMs);
            m_instance.m_timeElipsedChanged.Invoke(m_instance.m_timeElipsedMs);
        }
        public static Stopwatch m_watch = new Stopwatch();
        public static void StartWatch()
        {
            if (m_instance) {
                m_watch.Restart();
                m_watch.Start();
            }


        }
        private static double m_dBin;
        public static void StopTrack()
        {
            StopTrack(out double t, true);
        }
        public static void StopTrack(out double time, bool notifySingleton = true)
        {
            time = 0;
            if (m_instance)
            {
                m_watch.Stop();
                time = m_watch.ElapsedMilliseconds;
                if (notifySingleton)
                {
                    SetLastElipsedTime(time);
                    PushAverageTime(time);
                }
            }
        }

        public static void StopTrackAndDisplay() {
            StopTrack();
            DisplayValueInSingleton();
        }
    }
}
