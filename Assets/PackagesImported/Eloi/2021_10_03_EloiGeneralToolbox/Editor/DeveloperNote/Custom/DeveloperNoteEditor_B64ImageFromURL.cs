using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_B64ImageFromURL))]
    public class DeveloperNoteEditor_B64ImageFromURL : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_B64ImageFromURL myScript = (DeveloperNote_B64ImageFromURL)target;
            DeveloperNoteEditor_B64Image.DrawImage(myScript.m_image);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Open Given url", GUILayout.Width(250)))
            {
                Application.OpenURL(myScript.m_imageUrl);
            }
           
            GUILayout.EndHorizontal();
            DeveloperNoteEditor_B64Image.WarningAboutSizeB64();
            base.DrawDefaultInspector();
        }
    }
}
