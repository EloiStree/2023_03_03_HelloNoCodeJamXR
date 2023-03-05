using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringRelayMono : MonoBehaviour
{
    public bool dontPushEmpty=true;
    public Eloi.PrimitiveUnityEvent_String m_textToRelay;

    [ContextMenu("Push With Empty String")]
    public void PushWithEmptyString()
    {
        PushInTextToRelay("");
    }
    [ContextMenu("Push With Null")]
    public void PushWithNull()
    {
        PushInTextToRelay(null);
    }

    public void PushInTextToRelay(string text) {
        if (dontPushEmpty && Eloi.E_StringUtility.IsNullOrEmpty(in text))
            return;
            
        m_textToRelay.Invoke(text);
    }
}
