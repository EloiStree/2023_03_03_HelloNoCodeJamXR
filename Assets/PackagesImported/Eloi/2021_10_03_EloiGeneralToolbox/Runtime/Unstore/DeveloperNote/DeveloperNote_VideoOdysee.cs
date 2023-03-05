using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeveloperNote_VideoOdysee : DeveloperNoteMono
{
    public string m_odyseeUrl;
   
    [ContextMenu("Open Odysee Page")]
    public void OpenYoutube() {
        Application.OpenURL(m_odyseeUrl);
    }
}
