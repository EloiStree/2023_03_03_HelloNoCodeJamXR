using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class CancelableCountdownTick : MonoBehaviour
    {

        public float m_countdownValue;
        public float m_timeleft;
        public bool m_countDownIsOn;
        public bool m_startAtAwake;

        public UnityEvent m_timeReach;
        public UnityEvent m_cancelCalled;

        void Awake()
        {
            m_timeleft = m_countdownValue;
            if (m_startAtAwake)
                StartCountdown();
        }
        public void SetTimeToAndReset(float time) {

            m_timeleft = time;
            m_countdownValue = time;
            StartCountdown();
        }
        private void StartCountdown()
        {
            m_timeleft = m_countdownValue;
            m_countDownIsOn = true;
        }
        public void CancelCountdown() {
            StopCountdown();
            m_cancelCalled.Invoke();
        }
        private void StopCountdown()
        {
            m_countDownIsOn = false;
        }
        public void ResetCountdown() {
            m_countDownIsOn = false;
            m_timeleft = m_countdownValue;
        }
        void Update()
        {
            if (m_countDownIsOn) {
                if (m_timeleft > 0f) { 
                    m_timeleft -= Time.deltaTime;
                    if (m_timeleft <= 0f) {
                        m_timeleft =0f;
                        m_timeReach.Invoke();
                    }
                }
            }
        }
    }
}
