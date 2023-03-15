using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eloi
{
    public abstract class AbstractPlayerPrefs : MonoBehaviour
    {
        public string m_uniqueId;
        public string m_subfolder="P";
        public Eloi.PrimitiveUnityEvent_String m_onLoad;
        public StorageType m_storageType = StorageType.PersistentDataPath;
        public enum StorageType { 
            PlayerPrefs, DataPath, PersistentDataPath
        }


        public abstract void GetInfoToStoreAsString(out string infoToStore);
        public abstract void SetWithStoredInfoFromString(string recoveredInfo);
        protected void Awake()
        {
            ReloadInfoStoredAndPushItBack();
        }

        public void ReloadInfoStoredAndPushItBack()
        {
            if (m_storageType == StorageType.PlayerPrefs) { 
                string t = "";
                if (PlayerPrefs.HasKey(m_uniqueId))
                    t = PlayerPrefs.GetString(m_uniqueId);
                else GetInfoToStoreAsString(out t);

                SetWithStoredInfoFromString(t);
                m_onLoad.Invoke(t);
            }
            else
            {
                string folderPath = GetFilePathWhereToStore();
                MetaAbsolutePathFile p = new MetaAbsolutePathFile(folderPath);
                Eloi.E_FileAndFolderUtility.ImportFileAsText(p, out string text,"");
                SetWithStoredInfoFromString(text);
                m_onLoad.Invoke(text);
            }
        }

        public void SaveAbstractInfoFromText()
        {
            if (m_storageType == StorageType.PlayerPrefs)
            {
                GetInfoToStoreAsString(out string infoToStore);
                PlayerPrefs.SetString(m_uniqueId, infoToStore);
            }
            else
            {
                GetInfoToStoreAsString(out string infoToStore);
                string folderPath = GetFilePathWhereToStore();
                MetaAbsolutePathFile p = new MetaAbsolutePathFile(folderPath);
                Eloi.E_FileAndFolderUtility.ExportByOverriding(p, infoToStore);
            }

        }

        private string GetFilePathWhereToStore()
        {
            string folderPath = Application.persistentDataPath;
            if (m_storageType == StorageType.DataPath)
            {
                folderPath = Application.dataPath;
            }
            Eloi.E_StringByte64Utility.Base64EncodeUsingUTF8FileSafe(m_uniqueId, out string idB64);
            Eloi.E_FilePathUnityUtility.MeltPathTogether(out folderPath, folderPath , m_subfolder , idB64);
            return folderPath;
        }

        private void OnDestroy()
        {
            SaveAbstractInfoFromText();
        }
        private void OnApplicationPause(bool pause)
        {
            SaveAbstractInfoFromText();

        }
        private void OnApplicationQuit()
        {

            SaveAbstractInfoFromText();
        }


        protected virtual void Reset()
        {
            GenerateId();
        }

        [ContextMenu("Generate New ID")]
        private void GenerateId()
        {
            Eloi.E_UnityRandomUtility.GetRandomGUID(out string id);
            m_uniqueId = "" + id;
        }

        public void Save()
        {
            SaveAbstractInfoFromText();
        }
        public void Load()
        {
            ReloadInfoStoredAndPushItBack();
        }

        public void SaveAndReload() {
            Save();Load();
        }
    }
}
