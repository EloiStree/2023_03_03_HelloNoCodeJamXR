using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class ImportOrCreateTextFileMono : MonoBehaviour
    {
        public Eloi.AbstractMetaAbsolutePathFileMono m_fileToLoad;
        public TextAsset m_defaultTextIfNotExisting;
        public Eloi.PrimitiveUnityEvent_String m_onTextImported;

        [ContextMenu("Import")]
        public void Import()
        {
            bool fileExist = E_FileAndFolderUtility.IsExisting(m_fileToLoad);

            if (!fileExist)
                E_FileAndFolderUtility.CreateFile(m_fileToLoad, m_defaultTextIfNotExisting.text);
            E_FileAndFolderUtility.ImportFileAsText(m_fileToLoad, out string text);
            m_onTextImported.Invoke(text);

        }
    }
}
