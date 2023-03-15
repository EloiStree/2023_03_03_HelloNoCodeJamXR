

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eloi
{
    public abstract class AbstractStringContextToPlayerPref : MonoBehaviour
    {
        public string m_uniqueIdOfPlayerPrefs;
        public string m_subfolder = "C";
        public Eloi.PrimitiveUnityEvent_String m_onLoad;
        public StorageType m_storageType = StorageType.PersistentDataPath;
        public enum StorageType
        {
            PlayerPrefs, DataPath, PersistentDataPath
        }


        #region Set Context of the environment
        public string m_currentContextId;
        public void SetCurrentContextId(string contextId) =>
            m_currentContextId = contextId;

        public void GetCurrentContextId(out string contextId) =>
            contextId = m_currentContextId;


        public string GetCurrentContextId()
        {
            return m_currentContextId;
        }

        #endregion

        #region Set and Get the information that need to be save or load
        public abstract void GetInfoToStoreAsString(out string infoToStore);
        public abstract void SetWithStoredInfoFromString(string recoveredInfo);
        #endregion


        public virtual void OpenFileIfUsingFile() {
            if (m_storageType != StorageType.PlayerPrefs) {
                string p = GetFilePathWhereToStore();
                string d = Path.GetDirectoryName(p);

                Application.OpenURL(d);
                Debug.Log(p);
            }
        }

        public void GetUniqueIdWithContext(out string id) {
             id = m_uniqueIdOfPlayerPrefs+"_"+m_currentContextId;
        }

        public void ReloadInfoStoredAndPushItBack()
        {
             GetUniqueIdWithContext(out string currentID);
            if (m_storageType == StorageType.PlayerPrefs)
            {
                string t = "";
                if (PlayerPrefs.HasKey(currentID))
                    t = PlayerPrefs.GetString(currentID);
                else GetInfoToStoreAsString(out t);

                SetWithStoredInfoFromString(t);
                m_onLoad.Invoke(t);
            }
            else
            {
                string folderPath = GetFilePathWhereToStore();
                MetaAbsolutePathFile p = new MetaAbsolutePathFile(folderPath);
                Eloi.E_FileAndFolderUtility.ImportFileAsText(p, out string text, "");
                SetWithStoredInfoFromString(text);
                m_onLoad.Invoke(text);
            }
        }

        public void SaveAndLoadNewContext(string newContext) {
            Save();
            SetCurrentContextId(newContext);
            Load();
        }

        [ContextMenu("Save")]
        public virtual void Save() { SaveAbstractInfoFromText(); }
        [ContextMenu("Load")]
        public virtual void Load() { ReloadInfoStoredAndPushItBack(); }

        public void SaveAbstractInfoFromText()
        {
            GetUniqueIdWithContext(out string currentID);
            if (m_storageType == StorageType.PlayerPrefs)
            {
                GetInfoToStoreAsString(out string infoToStore);
                PlayerPrefs.SetString(currentID, infoToStore);
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
            GetUniqueIdWithContext(out string currentID);
            string folderPath = Application.persistentDataPath;
            if (m_storageType == StorageType.DataPath)
            {
                folderPath = Application.dataPath;
            }
            Eloi.E_StringByte64Utility.Base64EncodeUsingUTF8FileSafe(currentID, out string idB64);
            Eloi.E_FilePathUnityUtility.MeltPathTogether(out folderPath, folderPath, m_subfolder, idB64);
            return folderPath;
        }


        #region Link to Unity Mono methode
        public bool m_useAutoReloadAwake = false;
        public bool m_useAutoSave = true;
        protected void Awake()
        {
            if(m_useAutoReloadAwake)
                ReloadInfoStoredAndPushItBack();
        }
        private void OnDestroy()
        {
            if (m_useAutoSave) 
                SaveAbstractInfoFromText();
        }
        private void OnApplicationPause(bool pause)
        {
            if (m_useAutoSave)
                SaveAbstractInfoFromText();

        }
        private void OnApplicationQuit()
        {

            if (m_useAutoSave)
                SaveAbstractInfoFromText();
        }
        protected virtual void Reset()
        {
            GenerateId();
        } 
        #endregion

        [ContextMenu("Generate New ID")]
        private void GenerateId()
        {
            Eloi.E_UnityRandomUtility.GetRandomGUID(out string id);
            m_uniqueIdOfPlayerPrefs = "" + id;
        }
    }
}




  

