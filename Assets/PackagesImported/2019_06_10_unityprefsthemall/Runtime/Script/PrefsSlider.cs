using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PrefsSlider : QuickPrefsSaveBehviourAbstract
{
    public Slider m_linked;

    protected override void FindAndLinkcomponent()
    {
        m_linked = GetComponent<Slider>();
    }

    protected override string GetDataToSave()
    {
        return m_linked.value.ToString() ;


    }
    protected override void ResetDataWith(string savedInfo)
    {
        float value = 0;
        float.TryParse(savedInfo, out value);
        m_linked.value = value;
    }
    
}