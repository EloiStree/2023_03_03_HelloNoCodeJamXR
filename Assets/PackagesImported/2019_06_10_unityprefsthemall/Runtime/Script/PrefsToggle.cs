using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class PrefsToggle : QuickPrefsSaveBehviourAbstract
{
    public Toggle m_linked;

 
    protected override string GetDataToSave()
    {
        return m_linked.isOn?"1":"0" ;


    }
    protected override void ResetDataWith(string savedInfo)
    {
        m_linked.isOn = savedInfo == "1";
    }
    
    protected  override void FindAndLinkcomponent()
    {
        m_linked = GetComponent<Toggle>();
    }
}
