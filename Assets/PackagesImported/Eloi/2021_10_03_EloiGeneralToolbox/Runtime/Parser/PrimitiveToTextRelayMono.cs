using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveToTextRelayMono : MonoBehaviour
{

    public Eloi.PrimitiveUnityEvent_String m_asText;

    public void Push(int value)
    {
        m_asText.Invoke(value.ToString());
    }
    public void Push(float value)
    {
        m_asText.Invoke(value.ToString());
    }
    public void Push(double value)
    {
        m_asText.Invoke(value.ToString());
    }
    public void Push(bool value)
    {
        m_asText.Invoke(value.ToString());
    }
    
}
