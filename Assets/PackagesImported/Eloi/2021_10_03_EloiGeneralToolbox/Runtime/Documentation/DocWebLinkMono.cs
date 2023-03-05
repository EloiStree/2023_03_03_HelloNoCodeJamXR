using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocWebLinkMono : MonoBehaviour
{
    
    public Documentation.WebLink m_webLink;

    [ContextMenu("Open Url")]
    public void OpenUrl() {
        Application.OpenURL(m_webLink.m_urlTarget);
    }
}
public class Documentation {
    [System.Serializable]
    public class WebLink {

        public string m_descriptionName = "";
        public string m_urlTarget = "";
    }


    [System.Serializable]
    public class CodeFoundOnWeb {


        [TextArea(0, 2)] public string m_description;

        [TextArea(0, 10)] public string m_code="";
        public string m_sourceUrl="";
    }
}