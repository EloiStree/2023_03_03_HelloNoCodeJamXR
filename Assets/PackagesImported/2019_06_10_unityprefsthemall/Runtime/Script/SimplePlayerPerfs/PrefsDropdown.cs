
using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class PrefsDropdown : AbstractPlayerPrefs
{
    public Dropdown m_linked;


    protected override void Reset()
    {
        base.Reset();
        m_linked = GetComponent<Dropdown>();
    }

   

    public override void GetInfoToStoreAsString(out string infoToStore)
    {
        infoToStore=m_linked.value.ToString();
    }

    public override void SetWithStoredInfoFromString(string recoveredInfo)
    {
        int value = 0;
        int.TryParse(recoveredInfo, out value);
        m_linked.value = value;
    }
}
