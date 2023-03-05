using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_YoutubeVideo))]
    public class DeveloperNoteEditor_YoutubeVideo : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_YoutubeVideo myScript = (DeveloperNote_YoutubeVideo)target;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Open on Youtube"))
            {
                myScript.OpenYoutube();
            }
            GUILayout.EndHorizontal();
            base.DrawDefaultInspector();
        }
    }
}
