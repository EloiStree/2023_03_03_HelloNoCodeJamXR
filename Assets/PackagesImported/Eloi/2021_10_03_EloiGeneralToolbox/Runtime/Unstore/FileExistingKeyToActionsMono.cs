using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eloi;
using System.IO;
using UnityEngine.Events;
namespace Eloi
{
    public class FileExistingKeyToActionsMono : MonoBehaviour
    {
        public AbstractMetaAbsolutePathFileMono m_filePath;
        public TextAsset m_fileByDefault;
        public Eloi.PrimitiveUnityEventExtra_Bool m_actionIfExisting;

        [ContextMenu("Check if file exists")]
        public void CheckIfFileExistByPushingEvent()
        {
            m_actionIfExisting.Invoke(DoesKeyFileExistAndIsValide());
        }
        public bool DoesKeyFileExistAndIsValide()
        {
            string path = m_filePath.GetPath();
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                return Eloi.E_StringUtility.AreEquals(m_fileByDefault.text, text, false, true);
            }
            return false;
        }

        [ContextMenu("Create  key")]
        public void CreateKey()
        {
            Eloi.E_FileAndFolderUtility.ExportByOverriding(m_filePath, m_fileByDefault.text);
        }
       
    }

}
