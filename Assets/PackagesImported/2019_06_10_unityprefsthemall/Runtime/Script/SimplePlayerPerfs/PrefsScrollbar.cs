
using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class PrefsScrollbar: AbstractPlayerPrefs
{
    public Scrollbar m_linked;

    public override void GetInfoToStoreAsString(out string infoToStore)
    {
        infoToStore = m_linked.value.ToString(); ;
    }

    public override void SetWithStoredInfoFromString(string recoveredInfo)
    {
        float value = 0;
        float.TryParse(recoveredInfo, out value);
        m_linked.value = value;
    }

    protected  new void Reset()
    {
        base.Reset();
        m_linked = GetComponent<Scrollbar>();
    }

   
}

