using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperNoteMono : MonoBehaviour
{
    [Tooltip("Just a note of the developer")]
    [TextArea(0,10)]
    public string m_note;
    public string m_author;
    protected virtual void OnValidate()
    {
        m_currentDev = m_author;
    }

    private void Reset()
    {
        if (m_author == "") 
            m_author = m_currentDev;
    }

    public static string m_currentDev="";

}
