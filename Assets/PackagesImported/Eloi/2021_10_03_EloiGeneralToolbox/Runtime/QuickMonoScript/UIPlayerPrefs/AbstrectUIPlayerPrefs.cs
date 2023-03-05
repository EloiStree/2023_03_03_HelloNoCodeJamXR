using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public abstract class AbstrectUIPlayerPrefs : MonoBehaviour
    {
        public string m_id;
        public Eloi.PrimitiveUnityEvent_String m_onLoad;
        // Start is called before the first frame update

        public abstract void GetInfoToStoreAsString(out string infoToStore);
        public abstract void SetWithStoredInfoFromString(string recoveredInfo);
        void Awake()
        {
            string t = "";
            if (PlayerPrefs.HasKey(m_id))
                t = PlayerPrefs.GetString(m_id);
            else GetInfoToStoreAsString(out t);
            SetWithStoredInfoFromString(t);
            m_onLoad.Invoke(t);
        }

        private void OnDestroy()
        {
            SaveInputField();
        }

        private void SaveInputField()
        {
            GetInfoToStoreAsString(out string infoToStore);
            PlayerPrefs.SetString(m_id, infoToStore);
        }

        private void OnApplicationPause(bool pause)
        {
            SaveInputField();

        }
        private void OnApplicationQuit()
        {

            SaveInputField();
        }


        protected virtual void Reset()
        {
            GenerateId();
        }

        [ContextMenu("Generate New ID")]
        private void GenerateId()
        {
            Eloi.E_UnityRandomUtility.GetRandomGUID(out string id);
            m_id = "" + id;
        }
    }
}
