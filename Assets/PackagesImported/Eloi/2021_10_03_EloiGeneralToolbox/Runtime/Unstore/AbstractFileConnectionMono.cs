using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class AbstractFileConnectionMono : MonoBehaviour
    {

        public Eloi.AbstractMetaAbsolutePathFileMono m_fileTarget;
        public void SetText(string text)
        {
            Eloi.E_FileAndFolderUtility.ExportByOverriding(m_fileTarget, text);
        }
        public void GetText(out string text)
        {
            Eloi.E_FileAndFolderUtility.ImportFileAsText(m_fileTarget, out text);
        }
        public string GetText()
        {
            Eloi.E_FileAndFolderUtility.ImportFileAsText(m_fileTarget, out string text);
            return text;
        }



    }
}
