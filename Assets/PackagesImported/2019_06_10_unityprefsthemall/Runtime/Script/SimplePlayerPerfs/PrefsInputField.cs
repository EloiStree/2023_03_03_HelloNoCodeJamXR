
using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PrefsInputField : AbstractPlayerPrefs
{
    public InputField m_linked;

    public override void GetInfoToStoreAsString(out string infoToStore)
    {
        infoToStore= m_linked.text;
    }

    public override void SetWithStoredInfoFromString(string recoveredInfo)
    {
        m_linked.text = recoveredInfo;
    }

    protected override void Reset()
    {
        base.Reset();
        m_linked = GetComponent<InputField>();
    }

  
}

