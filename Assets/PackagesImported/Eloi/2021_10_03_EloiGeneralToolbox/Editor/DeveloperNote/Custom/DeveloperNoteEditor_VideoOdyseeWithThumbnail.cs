using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_VideoOdyseeWithThumbnail))]
    public class DeveloperNoteEditor_VideoOdyseeWithThumbnail : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_VideoOdyseeWithThumbnail myScript = (DeveloperNote_VideoOdyseeWithThumbnail)target;
           
            if (myScript.m_image != null)
                DeveloperNoteEditor_B64Image.DrawImage(myScript.m_image, Open);
            
            if (GUILayout.Button("Open On Odysee", GUILayout.Width(250)))
            {
                Application.OpenURL(myScript.m_odyseeUrl);
            }
            DeveloperNoteEditor_B64Image.WarningAboutSizeB64();
            base.DrawDefaultInspector();
        }
        private void Open()
        {
            DeveloperNote_VideoOdyseeWithThumbnail myScript = (DeveloperNote_VideoOdyseeWithThumbnail)target;
            Application.OpenURL(myScript.m_odyseeUrl);

        }
    }
}
