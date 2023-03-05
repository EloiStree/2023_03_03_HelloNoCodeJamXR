using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class PrefsScrollbar: QuickPrefsSaveBehviourAbstract
{
    public Scrollbar m_linked;


    protected override void FindAndLinkcomponent()
    {
        m_linked = GetComponent<Scrollbar>();
    }

    protected override string GetDataToSave()
    {
        return m_linked.value.ToString();


    }
    protected override void ResetDataWith(string savedInfo)
    {
        float value = 0;
        float.TryParse(savedInfo, out value);
        m_linked.value = value;
    }
}

