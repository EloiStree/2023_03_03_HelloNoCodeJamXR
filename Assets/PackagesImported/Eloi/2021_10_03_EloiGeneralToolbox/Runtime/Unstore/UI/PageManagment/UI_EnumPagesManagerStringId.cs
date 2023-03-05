using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_EnumPagesManagerStringId : MonoBehaviour
{

    public StringIdEnumPages m_pages;

    public void SetWith(string pageName)
    {
        m_pages.SetWith(pageName);

    }
}



[System.Serializable]
public class StringIdEnumPages : AbstractEnumPages<string>
{
    public void SetWith(string pageName)
    {
        GetPage(pageName, out bool found, out AbstractEnumPage<string> page);
        DeactivateAll();
        page.SetOnOff(true);

    }

    public void GetPage(in string pageName, out bool found, out AbstractEnumPage<string> page) {
        bool timeAndIgnoreCase = true;
        GetPages(out AbstractEnumPage<string>[] pages);
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i] != null && Eloi.E_StringUtility.AreEquals(pages[i].GetPageId(), pageName, in timeAndIgnoreCase, in timeAndIgnoreCase))
            {
                page = pages[i];
                found = true;
                return;
            }
        }
        found = false;
        page = null;
        return ;
    }

    public void GetEnumIdList(out string[] key)
    {
        GetPages(out AbstractEnumPage<string>[] pages);
        key = pages.Select(k => k.GetPageId()).ToArray();
    }

    public void GetPreviousOf(in string pageName, out string previous)
    {
        previous = "";
        GetPages(out AbstractEnumPage<string>[] pages);
        if (pages.Length == 0)
            return;
        GetPageIndex(in pageName, out bool found, out uint index);
        index--;
        if (index <= 0)
            index = (uint)pages.Length - 1;
        previous = pages[index].GetPageId();
    }

    public void GetNextPageOf(in string pageName, out string next)
    {
        next = "";
        GetPages(out AbstractEnumPage<string>[] pages);
        if (pages.Length == 0)
            return;
        GetPageIndex(in pageName, out bool found, out uint index);
        index++;
        if (index >= pages.Length - 1)
            index = 0;
        next = pages[index].GetPageId();

    }
    public void GetPageIndex(in string pageName,out  bool found, out uint index) {
        GetPage(pageName, out found, out AbstractEnumPage<string> page);
        GetPages(out AbstractEnumPage<string>[] pages);

        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i] == page)
            {
                index =(uint) i;
                return;
            }
        }
        index = 0;
        return;
    }



}

[System.Serializable]
public class EnumIdEnumPages<Q> : AbstractEnumPages<Q> where Q : Enum
{

}


[System.Serializable]
public class AbstractEnumPages<T>
{
    [SerializeField] AbstractEnumPage<T>[] m_pages;

    public void GetPages(out AbstractEnumPage<T>[] pages) {
        pages = m_pages;
    }
    
    public void DeactivateAll()
    {
        for (int i = 0; i < m_pages.Length; i++)
        {
            if (m_pages[i] != null)
                m_pages[i].SetOnOff(false);
        }
    }
    public void ActivateAll()
    {
        for (int i = 0; i < m_pages.Length; i++)
        {
            if (m_pages[i] != null)
                m_pages[i].SetOnOff(true);
        }
    }
}
[System.Serializable]
public class AbstractEnumPage<T>
{
    [SerializeField] T m_pageIdKey;
    [SerializeField] GameObject [] m_toTurnOnOff;

    public void SetOnOff(bool setOn) {
        for (int i = 0; i < m_toTurnOnOff.Length; i++)
        {
            if(m_toTurnOnOff[i]!=null)
            m_toTurnOnOff[i].SetActive(setOn);
        }
    }

    public T GetPageId() { return m_pageIdKey;  }

}