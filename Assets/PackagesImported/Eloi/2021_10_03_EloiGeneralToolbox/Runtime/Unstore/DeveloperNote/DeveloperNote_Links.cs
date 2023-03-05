using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperNote_Links : DeveloperNoteMono
{
    public Links m_whereToFindInfo = new Links();

    [System.Serializable]
    public class Links {

        public NameLink[] m_namedUrls = new NameLink[0];
        public void OpenLinks()
        {
            
            for (int i = 0; i < m_namedUrls.Length; i++)
            {
                if (!string.IsNullOrEmpty(m_namedUrls[i].m_urls))
                    Application.OpenURL(m_namedUrls[i].m_urls);
            }
        }
    }
    [System.Serializable]
    public class NameLink {
        public string m_linkName;
        public string m_urls;
    }


    [ContextMenu("Open Links")]
    public void OpenLinks()
    {
        m_whereToFindInfo.OpenLinks();
    }
}
