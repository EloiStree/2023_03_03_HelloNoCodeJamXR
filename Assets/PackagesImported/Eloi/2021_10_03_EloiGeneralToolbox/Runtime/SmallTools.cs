using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi {
    public class SmallTools
    {

        [System.Serializable]
        public class CountdownTracker {

            public float m_timeLeft;
            public UnityEvent m_onTimeout;
            public void RemoveTime(float time, out bool isOutOfTime) {
                if (m_timeLeft > 0f)
                {
                    float previousTime = m_timeLeft;
                    m_timeLeft -= time;
                    if (m_timeLeft <= 0f && previousTime > 0f)
                    {
                        isOutOfTime = true;
                        m_timeLeft = 0f;
                        try { 
                        m_onTimeout.Invoke();
                        }
                        catch (Exception e)
                        {
                            Debug.LogError("Exception in the countdown call:" + e.StackTrace);
                        }
                        return;
                    }

                }
                isOutOfTime = false;
            }
        }

        [System.Serializable]
        public class CountdownLoopTracker {
            public float m_loopTime = 2;
            public float m_timeLeft;
            public UnityEvent m_onTimeout;

            public CountdownLoopTracker()
            {
                ResetTime();
            }

            private void ResetTime()
            {
                m_timeLeft = m_loopTime;
            }

            public void RemoveTime(float time, out bool isOutOfTime)
            {
                if (m_timeLeft > 0f)
                {
                    float previousTime = m_timeLeft;
                    m_timeLeft -= time;
                    if (m_timeLeft <= 0f && previousTime > 0f)
                    {
                        isOutOfTime = true;
                        m_timeLeft = 0f;
                        try
                        {
                            m_onTimeout.Invoke();
                        }
                        catch (Exception e) {
                            Debug.LogError("Exception in the countdown call:" + e.StackTrace);
                        }
                        ResetTime();
                        return;
                    }

                }
                isOutOfTime = false;
            }

        }


    }
}
