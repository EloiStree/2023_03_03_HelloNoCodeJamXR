using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eloi;
public class UI_EnumPagesManagerStringNavigation : MonoBehaviour
{
    public UI_EnumPagesManagerStringId m_target;
    public string m_pageName;


    [ContextMenu("Next Page")]
    public void SetFocusNextPage()
    {
        if (m_target == null)
            return;
        m_target.m_pages.GetNextPageOf(in m_pageName, out string next);
        m_target.SetWith(next);
        m_pageName = next;
    }
    [ContextMenu("Previous Page")]
    public void SetFocusPreviousPage()
    {
        if (m_target == null)
            return;
        m_target.m_pages.GetPreviousOf(in m_pageName, out string previous);
        m_target.SetWith(previous);
        m_pageName = previous;
    }
    [ContextMenu("Set As Random page")]
    public void SetFocusRandomPage()
    {
        if (m_target == null)
            return;
        m_target.m_pages.GetEnumIdList(out string[] key);
        E_UnityRandomUtility.GetRandomOf(out string choosed, in key);
        m_target.SetWith(choosed);
        m_pageName = choosed;

    }

    private void OnValidate()
    {
        if (m_target == null)
            return;
        m_target.SetWith(m_pageName);
    }
}
