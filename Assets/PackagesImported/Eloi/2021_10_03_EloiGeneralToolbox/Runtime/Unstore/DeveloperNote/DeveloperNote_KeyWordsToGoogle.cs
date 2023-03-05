using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperNote_KeyWordsToGoogle : MonoBehaviour
{
    [TextArea(0,2)]
    [Tooltip("Split by , ; \\n")]
    public string m_keywords;
    char [] m_spliter = new char[] { ',',';', '\n'};

    string[] m_keywordsToSearch;

    private void RefreshKeyWorks()
    {
        m_keywordsToSearch = m_keywords.Replace(" ", "%20").Split(m_spliter);
    }

    [ContextMenu("Search On Google")]
    public void SearchOnGoogle()
    {

        RefreshKeyWorks();

        Application.OpenURL("https://www.google.com/search?q=" + string.Join("+", m_keywordsToSearch));
    }
    [ContextMenu("Search On Duck Duck")]
    public void SearchOnDuckDuck()
    {

        RefreshKeyWorks();
        Application.OpenURL("https://duckduckgo.com/?q=" + string.Join("+", m_keywordsToSearch));
    }
    [ContextMenu("Search On All")]
    public void SearchOnAll()
    {
        SearchOnGoogle();
        SearchOnDuckDuck();
    }
}
