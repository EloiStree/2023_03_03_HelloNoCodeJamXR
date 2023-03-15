using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsContextIsActive : Eloi.AbstractStringContextToPlayerPref
{
    public GameObject m_linkedGameObject;
    public bool m_defaultValue=true;
    public override void GetInfoToStoreAsString(out string infoToStore)
    {
        infoToStore = m_linkedGameObject.activeSelf ? "1" : "0";
    }

    public override void SetWithStoredInfoFromString(string recoveredInfo)
    {
        recoveredInfo = recoveredInfo.Trim();
        if(recoveredInfo !=null && recoveredInfo.Length == 1)
            m_linkedGameObject.SetActive( recoveredInfo[0] == '1');
        else
            m_linkedGameObject.SetActive(m_defaultValue);

    }
    public new void Reset()
    {
        base.Reset();
        m_linkedGameObject = gameObject;
    }
    [ContextMenu("Open file where store info")]
    public new void OpenFileIfUsingFile()
    {
        base.OpenFileIfUsingFile();
    }

}
