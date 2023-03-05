using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayerPrefsMono : MonoBehaviour
{
    public string m_id;
    public Transform m_toAffect;
    public bool m_useOnAwakeDestroy=true;
    private void Awake()
    {
        if(m_useOnAwakeDestroy)
        Reload();
    }

    private void OnDestroy()
    {
        if(m_useOnAwakeDestroy)
        ExportSave();
    }

    private void Reload()
    {
        string jsonTransform = PlayerPrefs.GetString(m_id, "");

        TransformToStore t = JsonUtility.FromJson<TransformToStore>(jsonTransform);
        if (t != null) { 
            m_toAffect.position = t.m_position;
            m_toAffect.rotation = t.m_rotation;
            m_toAffect.localScale = t.m_localScale;
        }
    }
    public void ExportSave() {
        TransformToStore t = new TransformToStore(m_toAffect);
        PlayerPrefs.SetString(m_id, JsonUtility.ToJson(t));
    }

    private void Reset()
    {
       Eloi.E_GeneralUtility.GetTimeULongIdWithNow(out  ulong id);
        m_id=""+id;
        m_toAffect = transform; 
    }

    [System.Serializable]
    public class TransformToStore
    {
        public Vector3 m_position= new Vector3();
        public Quaternion m_rotation = Quaternion.identity;
        public Vector3 m_localScale= new Vector3();

        public TransformToStore()
        {
        }

        public TransformToStore(Transform toAffect)
        {
            m_position = toAffect.position;
            m_rotation = toAffect.rotation;
            m_localScale = toAffect.localScale;
        }
    }
}
