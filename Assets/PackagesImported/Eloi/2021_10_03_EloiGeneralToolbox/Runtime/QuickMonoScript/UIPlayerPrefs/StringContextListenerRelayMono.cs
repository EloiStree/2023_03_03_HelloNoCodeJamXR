using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringContextListenerRelayMono : MonoBehaviour
{

    public string m_lastContextReceived;
    public Eloi.PrimitiveUnityEvent_String m_onContextReceived;
    public void PushContext(string stringContextId)
    {
        m_lastContextReceived = stringContextId;
        m_onContextReceived.Invoke(m_lastContextReceived);
    }

}
