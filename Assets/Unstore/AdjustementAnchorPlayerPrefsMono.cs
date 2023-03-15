using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AdjustementAnchorPlayerPrefsMono : MonoBehaviour
{
    public string m_randomId;
    public AdjustementAnchorMono m_toAffect;

    void OnEnable()
    {
        if (PlayerPrefs.HasKey(m_randomId)) { 
           string json = PlayerPrefs.GetString(m_randomId, "");
            if (json.Trim().Length > 0) {
                m_toAffect.m_adjustement= JsonUtility.FromJson<AdjustementAnchorValue>(json);
                m_toAffect.RefreshPosition();
            }
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetString(m_randomId, JsonUtility.ToJson(m_toAffect.m_adjustement) );
    }

    private void Reset()
    {
        m_randomId = Guid.NewGuid().ToString();
        m_toAffect = GetComponent<AdjustementAnchorMono>();
        if (m_toAffect == null)
            m_toAffect = this.AddComponent<AdjustementAnchorMono>();
    }
}
