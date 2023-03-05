using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    [System.Serializable]
    public class DeltaGameTime
    {
        public float m_gameTimePrevious;
        public float m_gameTimeCurrent;

        public void SetTimeWithNow(out float delta)
        {
            SetTime(Time.timeSinceLevelLoad, out delta);
        }

        public void SetTime(float newTime, out float delta)
        {
            m_gameTimePrevious = m_gameTimeCurrent;
            m_gameTimeCurrent = newTime;
            if (m_gameTimePrevious == 0 || m_gameTimePrevious > m_gameTimeCurrent)
                m_gameTimePrevious = m_gameTimeCurrent;
            delta = m_gameTimeCurrent - m_gameTimePrevious;
        }
    }
}
