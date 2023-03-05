using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_VideoOdysee))]
    public class DeveloperNoteEditor_VideoOdysee : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_VideoOdysee myScript = (DeveloperNote_VideoOdysee)target;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Open on Odysee"))
            {
                Application.OpenURL(myScript.m_odyseeUrl);
            }
            GUILayout.EndHorizontal();
            base.DrawDefaultInspector();
        }
    }
}
