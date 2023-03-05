using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PrefsInputField : QuickPrefsSaveBehviourAbstract
{
    public InputField m_linked;


    protected override void FindAndLinkcomponent()
    {
        m_linked = GetComponent<InputField>();
    }

    protected override string GetDataToSave()
    {
        return m_linked.text;


    }
    protected override void ResetDataWith(string savedInfo)
    {
        m_linked.text = savedInfo;
    }
}

