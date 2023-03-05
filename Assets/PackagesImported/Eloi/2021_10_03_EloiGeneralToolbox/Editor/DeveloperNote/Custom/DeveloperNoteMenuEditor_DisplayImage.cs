using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using System;

public class DeveloperNoteMenuEditor_DisplayImage  : EditorWindow
{
    //string myString = "Hello World";
    //bool groupEnabled;
    //bool myBool = true;
    //float myFloat = 1.23f;
    public Texture2D m_texture;
    public Action m_onClick;

    public static void CreateWindow(Texture2D texture, Action onClick)
    {
        DeveloperNoteMenuEditor_DisplayImage window = (DeveloperNoteMenuEditor_DisplayImage)EditorWindow.GetWindow(typeof(DeveloperNoteMenuEditor_DisplayImage));
        window.titleContent.text = "Image viewer";
        window.minSize =new Vector2( 400,200);
        window.m_texture = texture;
        window.m_onClick = onClick;
        window.Show();
    }

    void OnGUI()
    {
        float m_width = position.width ;
        GUILayout.BeginHorizontal();
        GUIStyle style = new GUIStyle();
        style.normal.background = m_texture;
        style.margin = new RectOffset(2, 2, 2, 2);
        style.alignment = TextAnchor.MiddleCenter;
        float ratio = m_texture.height / (float)m_texture.width;
        if (GUILayout.Button("", style, GUILayout.Width(m_width), GUILayout.Height(m_width * ratio)))
        {
            if(m_onClick!=null)
                m_onClick.Invoke();
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("View", GUILayout.Width(m_width)))
        {
            if (m_onClick != null)
                m_onClick.Invoke();
        }
    }
}