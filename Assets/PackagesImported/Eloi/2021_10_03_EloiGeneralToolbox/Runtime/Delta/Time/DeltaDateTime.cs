using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    [System.Serializable]
    public class DeltaDateTime
    {
        public DateTime m_gameTimePrevious = DateTime.Now;
        public DateTime m_gameTimeCurrent = DateTime.Now;

        public void SetTimeWithGameLevel(out double delta)
        {
            SetTime(DateTime.Now, out delta);
        }

        public void SetTime(DateTime newTime, out double delta)
        {
            m_gameTimePrevious = m_gameTimeCurrent;
            m_gameTimeCurrent = newTime;
            if ( m_gameTimePrevious > m_gameTimeCurrent)
                m_gameTimePrevious = m_gameTimeCurrent;
            delta = (m_gameTimeCurrent- m_gameTimePrevious).TotalSeconds;
        }
    }
}
