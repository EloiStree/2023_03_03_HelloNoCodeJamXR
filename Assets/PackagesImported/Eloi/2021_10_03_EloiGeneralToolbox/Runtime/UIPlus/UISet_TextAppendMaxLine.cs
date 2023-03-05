using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UISet_TextAppendMaxLine : MonoBehaviour
{
   
        public Text m_affected;
        public int m_maxLine = 10;



    public void AppendStart(params string []  lines)
    {
        for (int i = lines.Length - 1; i > -1; i--)
        {
            AppendStart(lines[i]);
        }
    }
    public void AppendStart(string text)
    {

        m_affected.text = text + m_affected.text;
    }
    public void AppendStart(char text)
    {
        AppendStart("" + text);
    }

    public void AppendEnd(params string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            AppendEnd(lines[i]);
        }
    }
    public void AppendEnd(string text)
        {
            m_affected.text = m_affected.text + text;

        }
    public void AppendEnd(char text)
    {
        AppendEnd("" + text);
    }


    public void AppendStartWithLineReturn(params string[] lines)
    {
        for (int i = lines.Length - 1; i > -1; i--)
        {
            AppendStartWithLineReturn(lines[i]);
        }
    }
    public void AppendStartWithLineReturn(char text)
    {
        AppendStartWithLineReturn("" + text);
    }
        public void AppendStartWithLineReturn(string text)
    {
        List<string> lines = m_affected.text.Split('\n').ToList();
        lines.Insert(0, text);
        if (lines.Count > m_maxLine)
            lines.RemoveAt(lines.Count - 1);
        m_affected.text = string.Join("\n", lines);
    }
    public void AppendEndWithLineReturn(params string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            AppendEndWithLineReturn(lines[i]);
        }
    }

    public void AppendEndWithLineReturn(char text)
    {
        AppendEndWithLineReturn("" + text);
    }
    public void AppendEndWithLineReturn(string text)
        {
        List<string> lines = m_affected.text.Split('\n').ToList();
        lines.Add( text);
        if (lines.Count > m_maxLine)
            lines.RemoveAt(0);
        m_affected.text = string.Join("\n", lines);

    }

        private void Reset()
        {
            m_affected = GetComponent<Text>();
        }
    
}
