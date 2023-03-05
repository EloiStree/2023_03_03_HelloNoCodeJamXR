using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class StringFilterToUnityEvent : MonoBehaviour
{
    public UnityEvent m_textReceivedIsValide;
    public Eloi.PrimitiveUnityEvent_String m_textValidated;
    public string m_lastReceived;
    public string m_lastValidated;
    public void PushIn(string text)
    {
        m_lastReceived = DateTime.Now.ToString();
        IsConditionValideForThisText(in text, out bool isvalide);
        if (isvalide) {
            PushInValidated(in text);
        }

    }
    public void PushIn(in string text)
    {
        m_lastReceived = DateTime.Now.ToString();
        IsConditionValideForThisText(in text, out bool isvalide);
        if (isvalide)
        {
            PushInValidated(in text);
        }
    }
    public abstract void IsConditionValideForThisText(in string text, out bool conditionIsValide);
    protected abstract void NotifyPushInValidatedToChildren(in string text);
    private  void PushInValidated(in string text) {

        m_lastValidated = DateTime.Now.ToString();
        try
        {
            NotifyPushInValidatedToChildren(in text);
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }
        try
        {
            m_textReceivedIsValide.Invoke();
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }
        try
        {
            m_textValidated.Invoke(text);
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }

    }
}

public class DefaultStringFilterToUnityEvent : StringFilterToUnityEvent
{
    public bool m_useLowerCase=true;
    public string m_validateIfIndexOf = "[what to look for]";

    public bool m_receivedDebugLog = true;
    public override void IsConditionValideForThisText(in string text, out bool conditionIsValide)
    {
        string t1 = text;
        string t2 = m_validateIfIndexOf;
        if (m_useLowerCase)
            t1 = t1.ToLower();
        if (m_useLowerCase)
            t2 = t2.ToLower();
        conditionIsValide = t1.IndexOf(t2) > -1;
    }

    protected override void NotifyPushInValidatedToChildren(in string text)
    {
        if( m_receivedDebugLog)
            Debug.Log("Received|" + text, this.gameObject);
    }
}
