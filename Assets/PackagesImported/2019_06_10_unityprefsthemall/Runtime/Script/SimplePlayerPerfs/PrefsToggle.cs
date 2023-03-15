
using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class PrefsToggle : AbstractPlayerPrefs
{
    public Toggle m_linked;

 
   
    
    protected   void Reset()
    {
        m_linked = GetComponent<Toggle>();
    }

    public override void GetInfoToStoreAsString(out string infoToStore)
    {
        infoToStore= m_linked.isOn ? "1" : "0";
    }

    public override void SetWithStoredInfoFromString(string recoveredInfo)
    {
        m_linked.isOn = recoveredInfo == "1";
    }
}
