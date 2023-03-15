using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class UI_DisplayTimeSSMono : MonoBehaviour
    {
        public string m_numberFromatSeconds = "0.00";

        public string m_timeAsString;
        public float m_timeInSecondsReceived;

        public void SetTimeWithSeconds(float timeInSeconds) {
            m_timeInSecondsReceived = timeInSeconds;
            m_timeAsString = string.Format("{0:" + m_numberFromatSeconds + "}", timeInSeconds);
        }
        
    }
}
