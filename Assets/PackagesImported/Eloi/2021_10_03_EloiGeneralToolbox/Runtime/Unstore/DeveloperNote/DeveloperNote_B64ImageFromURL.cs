using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeveloperNote_B64ImageFromURL : DeveloperNote_B64Image
{
    public string m_imageUrl;

    
    [ContextMenu("Refresh image with Url")]
    private void RefreshImageWithUrl()
    {
        base.SetWithURL(m_imageUrl);
    }
}
