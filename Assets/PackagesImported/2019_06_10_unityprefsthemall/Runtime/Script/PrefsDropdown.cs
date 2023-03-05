using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class PrefsDropdown : QuickPrefsSaveBehviourAbstract
{
    public Dropdown m_linked;


    protected override void FindAndLinkcomponent()
    {
        m_linked = GetComponent<Dropdown>();
    }

    protected override string GetDataToSave()
    {
        return m_linked.value.ToString();


    }
    protected override void ResetDataWith(string savedInfo)
    {
        int value = 0;
        int.TryParse(savedInfo, out value);
        m_linked.value = value;
    }
}
