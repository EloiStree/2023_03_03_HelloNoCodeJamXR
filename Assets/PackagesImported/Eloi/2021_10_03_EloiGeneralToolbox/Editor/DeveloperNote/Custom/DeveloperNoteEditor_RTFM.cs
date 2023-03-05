using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_RTFM))]
    public class DeveloperNoteEditor_RTFM : Editor
    {
        public override void OnInspectorGUI()
        {
            DeveloperNote_RTFM myScript = (DeveloperNote_RTFM)target;

            DeveloperNoteEditor_Links.DrawLinks(myScript, "Read the manuals");
          
            base.DrawDefaultInspector();
        }
    }
}
