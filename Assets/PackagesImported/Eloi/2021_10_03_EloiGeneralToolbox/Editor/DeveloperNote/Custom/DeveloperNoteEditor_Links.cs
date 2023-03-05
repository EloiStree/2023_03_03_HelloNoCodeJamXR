using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_Links))]
    public class DeveloperNoteEditor_Links : Editor
    {
        public override void OnInspectorGUI()
        {
            DeveloperNote_Links myScript = (DeveloperNote_Links)target;
            DrawLinks(myScript);

            base.DrawDefaultInspector();
        }

        public static void DrawLinks(DeveloperNote_Links myScript, string titleMaintButton=null)
        {
            //GUILayout.BeginHorizontal();
            //if (GUILayout.Button(titleMaintButton==null? "Open all Link(s)": titleMaintButton))
            //{
            //    myScript.OpenLinks();
            //}

            //GUILayout.EndHorizontal();
            foreach (var item in myScript.m_whereToFindInfo.m_namedUrls)
            {

                GUILayout.BeginHorizontal();
                GUILayout.Space(10);
                if (!string.IsNullOrEmpty(item.m_urls) && GUILayout.Button(item.m_linkName.Length==0? item.m_urls: item.m_linkName))
                    Application.OpenURL(item.m_urls);

                GUILayout.Space(10);
                GUILayout.EndHorizontal();

            }
           
            
           
        }
    }
}
