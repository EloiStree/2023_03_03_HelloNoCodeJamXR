using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class UI_DisplayTimeMMSSMono : MonoBehaviour
    {
        public float m_timeInSecondsReceived;
        public string m_numberFromatSeconds = "0.00";
        public string m_numberFromatMinutes = "0";
        public string m_numberSpliterFromat = ":";

        public string m_timeAsString;
        public PrimitiveUnityEvent_String m_textToDisplay;
        public enum DisplayType { SS , MMSS ,MMSSmmm }

        public void SetTimeWithSeconds(float timeInSeconds)
        {
            m_timeInSecondsReceived = timeInSeconds;

            float minutes = timeInSeconds / 60;
            float seconds = timeInSeconds % 60;
            m_timeAsString = string.Format("{0:" + m_numberFromatMinutes + "} " + m_numberSpliterFromat + " {1:" + m_numberFromatSeconds + "}",
                minutes, seconds);
            m_textToDisplay.Invoke(m_timeAsString);
        }
        
        
    }
}
