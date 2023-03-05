using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomTextPusherMono : MonoBehaviour
{
    public TextAsset m_source;
    public Eloi.PrimitiveUnityEvent_String m_onRandomPush;
    public string[] m_lines = new string[0];
    public void Awake()
    {
        if(m_source!=null)
            m_lines = m_source.text.Split('\n');
        m_lines = m_lines.Where(k => k.Trim().Length > 0).ToArray();
           
    }
    public void PushRandomString()
    {
        if (m_lines.Length > 0) { 
            Eloi.E_UnityRandomUtility.GetRandomOf(out string text,in m_lines);
            m_onRandomPush.Invoke(text);
        }
    }

    
}
