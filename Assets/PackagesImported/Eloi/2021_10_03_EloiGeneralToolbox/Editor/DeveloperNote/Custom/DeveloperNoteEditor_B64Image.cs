using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_B64Image))]
    public class DeveloperNoteEditor_B64Image : Editor
    {

        
        public override void OnInspectorGUI()
        {
            DeveloperNote_B64Image myScript = (DeveloperNote_B64Image)target;
            DeveloperNoteEditor_B64Image.DrawImage(myScript.m_image, Open);
            if (GUILayout.Button("Set with Clipboard", GUILayout.Width(m_width)))
            {
                myScript.ConvertClipboardToImage();
            }
            DeveloperNoteEditor_B64Image.WarningAboutSizeB64();
           
            base.DrawDefaultInspector();
            if ((DateTime.Now - m_lastSizeUpdate).Milliseconds > 400)
            {
                GetViewWidth();
                m_lastSizeUpdate = DateTime.Now;
            }
        }

        private void Open()
        {
            DeveloperNote_B64Image myScript = (DeveloperNote_B64Image)target;
            E_Base64ToImage.OpenB64InBrowser(myScript.m_b64Text.m_b64Text);
        }
        public void OpenInUnity()
        {
            DeveloperNote_B64Image myScript = (DeveloperNote_B64Image)target;
            DeveloperNoteMenuEditor_DisplayImage.CreateWindow(myScript.m_image, Open);
        }
        private static void OpenInBrowser( Texture2D texture)
        {
            E_Base64ToImage.ConvertTextureToBase64(texture, E_Base64ToImage.SupportedImageTypeB64.PNG, out bool c,
                out string data, out string dataMeta);
            E_Base64ToImage.OpenB64InBrowser(dataMeta   ) ;
        }
        public static void OpenInUnity(Texture2D texture)
        {
            DeveloperNoteMenuEditor_DisplayImage.CreateWindow(texture,()=> { OpenInBrowser(texture); });
        }


        public static void DrawImage(Texture2D texture,  Action toDoOnClick=null) {

            //if (!texture.isReadable)
            //{
            //    E_Texture2DUtility.CopyWithRenderer( texture ,out texture);
            //}

            if ((DateTime.Now - m_lastSizeUpdate).Milliseconds > 400) { 
                GetViewWidth();
                m_lastSizeUpdate = DateTime.Now;
            }
            if (texture == null)
                return;
            GUILayout.BeginHorizontal(); 
            GUIStyle style = new GUIStyle();
            style.normal.background = texture;
            style.margin = new RectOffset(2, 2, 2, 2);
            style.alignment = TextAnchor.MiddleCenter;
            float ratio = texture.height / (float)texture.width;
            if (GUILayout.Button("", style, GUILayout.Width(m_width), GUILayout.Height(m_width * ratio)))
            {
                if (toDoOnClick != null)
                    toDoOnClick.Invoke();
                else OpenInBrowser(texture);
            }
           
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (texture.isReadable && GUILayout.Button("Web", GUILayout.Width(m_width/2f)))
            {
                if (toDoOnClick != null)
                    toDoOnClick.Invoke();
                else OpenInBrowser(texture);
            }
            if (GUILayout.Button("Unity", GUILayout.Width(m_width/2f)))
            {
                if (toDoOnClick != null)
                    DeveloperNoteMenuEditor_DisplayImage.CreateWindow(texture, toDoOnClick.Invoke);
                else OpenInUnity(texture);
            }
            GUILayout.EndHorizontal(); 
        }


        static float m_width;
        static private Rect _rect;
        static DateTime m_lastSizeUpdate;
        private static float GetViewWidth()
        {
            float w = EditorGUIUtility.currentViewWidth;
            m_width = 250;
            return m_width;
            //if (Mathf.Abs(m_width - w) > 50)
            //    m_width = w;
            //return m_width;
        }

        public static void WarningAboutSizeB64()
        {

            GUILayout.Label("Git: Note that image take place in scene size if not in a prefab.");
        }
    }
   
}
