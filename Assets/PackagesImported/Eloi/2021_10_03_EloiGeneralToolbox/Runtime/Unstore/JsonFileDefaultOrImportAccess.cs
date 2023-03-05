using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
   

    [System.Serializable]
    public class JsonFileDefaultOrImportAccess<T> : MonoBehaviour
    {
        public AbstractMetaAbsolutePathFileMono m_filePath;
        public T m_default;
        public T m_imported;
        public ImportedEvent m_onImportedEvent;
        [System.Serializable]
        public class ImportedEvent : UnityEvent<T> { }

        [ContextMenu("Import")]
        public void Import()
        {
            Eloi.E_FileAndFolderUtility.ImportOrCreateThenImport(
                out string imported, m_filePath, GetDefault);
            m_imported = JsonUtility.FromJson<T>(imported);
            m_hasBeenImported = true;
            m_onImportedEvent.Invoke(m_imported);
        }

        public void OverrideFile(T whatToStore)
        {
            string textToUse = JsonUtility.ToJson(whatToStore, true);
            Eloi.E_FileAndFolderUtility.ExportByOverriding(m_filePath, textToUse);
        }

        [ContextMenu("Reset to Zero")]
        public void ResetToDefault() {
            GetDefault(out string t);
            Eloi.E_FileAndFolderUtility.ExportByOverriding(m_filePath, t);
        }

        private void GetDefault(out string textToUse)
        {
            textToUse = JsonUtility.ToJson(m_default, true);
        }
        [SerializeField] bool m_hasBeenImported;
        public bool HasBeenImported() {
            return m_hasBeenImported;
        }
    }
}
