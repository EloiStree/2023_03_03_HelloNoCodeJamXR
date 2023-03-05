using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eloi
{
    public class DeveloperNote_MarkDown : MonoBehaviour
    {
        [TextArea(0,20)]
        public string m_markdown;

        [ContextMenu("OpenInBrowser")]
        public void OpenInBrowser()
        {
            OpenMarkDownInBrowser(m_markdown);
        }
        public static void OpenMarkDownInBrowser(string text)
        {
            string path = Application.temporaryCachePath + "/Markdown.html";
            string image = "<html><body><div markdown=\"block\">" + text + "</div></body></html>";
            File.WriteAllText(path, image);
            Application.OpenURL(path);
        }

        [ContextMenu("Open as File")]
        public void OpenMarkDownAsFile()
        {
            OpenMarkDownAsFile(m_markdown);
        }
        [ContextMenu("Open as Markdown File")]
        public void OpenMarkDownAsMarkdownFile()
        {
            OpenMarkDownAsFile(m_markdown,"md");
        }

      

        public static void OpenMarkDownAsFile(string text, string fileExtensionNoDot="mddd")
        {
            string path = Application.temporaryCachePath + "/Markdown."+ fileExtensionNoDot;
            string image =  text ;
            File.WriteAllText(path, image);
            Application.OpenURL(path);
        }
    }
}
