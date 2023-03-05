using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_YoutubeVideoWithThumbnail))]
    public class DeveloperNoteEditor_YoutubeVideoWithThumbnail : Editor
    {

        //https://www.youtube.com/watch?v=s6TMa33niJo&t=133s
        public override void OnInspectorGUI()
        {
            DeveloperNote_YoutubeVideoWithThumbnail myScript = (DeveloperNote_YoutubeVideoWithThumbnail)target;
            if (myScript.m_image != null)
            DeveloperNoteEditor_B64Image.DrawImage(myScript.m_image, Open);
            DeveloperNoteEditor_B64Image.WarningAboutSizeB64();
            if (GUILayout.Button("Open On youtube")) {
                myScript.OpenYoutube();
            }
            base.DrawDefaultInspector();
        }
       
        private void Open()
        {
            DeveloperNote_YoutubeVideoWithThumbnail myScript = (DeveloperNote_YoutubeVideoWithThumbnail)target;
            myScript.OpenYoutube();
           
        }

    }
}
