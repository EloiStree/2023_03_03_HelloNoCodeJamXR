using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUITextWithNumber : MonoBehaviour
{

    public Text m_textToAffect;
    public string m_secondLeftFormat="{0:0.00}";

    public float m_timeReceived;
    public void SetTimeWithSeconds(float timeInSeconds)
    {

        m_textToAffect.text = string.Format(m_secondLeftFormat, timeInSeconds);
    }
    public void SetTimeWithSeconds(int timeInSeconds)
    {

        m_textToAffect.text = string.Format(m_secondLeftFormat, timeInSeconds);
    }

    private void OnValidate()
    {
        SetTimeWithSeconds(m_timeReceived);
    }
}
