using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using be.eloistree.generaltoolbox;
using Eloi;
using System.Text.RegularExpressions;
using System;

public class UI2Display_NamedPagesGroup : MonoBehaviour
{
    public List<Page> m_pageInChildren = new List<Page>();

    [ContextMenu("Refresh children")]
    public void RefreshPageInChildren() {

        Transform[] children = this.gameObject.GetComponentsInChildren<Transform>(true);
        m_pageInChildren.Clear();
        for (int i = 0; i < children.Length; i++)
        {
            Eloi.NameIdRefTag name = children[i].GetComponent<Eloi.NameIdRefTag>();
            AbstractUI2Display display = children[i].GetComponent<AbstractUI2Display>();
            if (name!=null && display != null) {
                m_pageInChildren.Add(new Page(name, display) { m_lastRefreshName = name.GetName()});
            }
        }
    }


    public void SetDisplayWithRegex(string regex)
    {
        foreach (var item in m_pageInChildren)
        {
            if (item != null) { 
                Regex r = new Regex(regex);
                item.m_pageToDisplay.SetDisplayOn( r.IsMatch(item.GetNameId().ToLower()));

            }
        }
    }
    public void SetDisplayWithContain(string textToFind)
    {
        textToFind = textToFind.ToLower();
        foreach (var item in m_pageInChildren)
        {
            if(item!=null)
            item.m_pageToDisplay.SetDisplayOn(item.GetNameId().ToLower().IndexOf(textToFind) >-1);
        }

    }
    public void SetDisplayWithEqual(string textToEqual)
    {
        textToEqual = textToEqual.ToLower();
        foreach (var item in m_pageInChildren)
        {
            if (item != null)
            {
                string t = item.GetNameId().ToLower();
                item.m_pageToDisplay.SetDisplayOn(t.Length == textToEqual.Length && item.GetNameId().ToLower().IndexOf(textToEqual) == 0);
            }
        }
    }
    public void SetDisplayWith(StringIdScriptable stringId)
    {
        foreach (var item in m_pageInChildren)
        {
            if (item != null)
            {
                string t = item.GetNameId().ToLower();
                item.m_pageToDisplay.SetDisplayOn(stringId == item.m_nameTag.m_associatedIdName );
            }
        }
    }


    public void GetAllPage(out List<Page> pageInChildren) {
         pageInChildren = m_pageInChildren;
    }

    [ContextMenu("Disable all")]
    public void DisableAll()
    {
        foreach (var item in m_pageInChildren)
        {
            item.m_pageToDisplay.SetToHide();
        }
    }
    [ContextMenu("Activate all")]
    public void ActivateAll()
    {
        foreach (var item in m_pageInChildren)
        {
            item.m_pageToDisplay.SetToDisplay();
        }
    }



    [System.Serializable]
    public class Page {
        public string m_lastRefreshName;
        public Eloi.NameIdRefTag m_nameTag;
        public AbstractUI2Display m_pageToDisplay;
        public Page()
        {
            m_nameTag = null;
            m_pageToDisplay = null;
        }
        public Page(NameIdRefTag nameTag, AbstractUI2Display pageToDisplay)
        {
            m_nameTag = nameTag;
            m_pageToDisplay = pageToDisplay;
        }

        public string GetNameId()
        {
            return m_nameTag.GetName();
        }
    }
}
