using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAreaRelayMono : MonoBehaviour
{
    [TextArea(0,10)]
    public string m_text;
    public Eloi.PrimitiveUnityEvent_String m_onTextPush;

    public bool m_pushAtStart=true;
    void Start()
    {
        if (m_pushAtStart)
            Push();
    }
    [ContextMenu("Push text")]
    public void Push()
    {
        Push(m_text);
    }
    public void Push(string text)
    {
        m_onTextPush.Invoke(text);
    }
}
