using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_KeyWordsToGoogle))]
    public class DeveloperNoteEditor_KeyWordsToGoogle : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_KeyWordsToGoogle myScript = (DeveloperNote_KeyWordsToGoogle)target;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Google"))
            {
                myScript.SearchOnGoogle();
            }
            if (GUILayout.Button("Duck Duck"))
            {
                myScript.SearchOnDuckDuck();
            }
            if (GUILayout.Button("All"))
            {
                myScript.SearchOnAll();
            }
            GUILayout.EndHorizontal();
            base.DrawDefaultInspector();
        }
    }
}
