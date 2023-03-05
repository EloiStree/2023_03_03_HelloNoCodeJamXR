using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardImageDemoMono : MonoBehaviour
{
   
    public Texture2D texture;

    [TextArea(0,10)]
    public string m_b64PngTextVersion;

    [ContextMenu("Refresh")]
    void Refresh()
    {
        texture = Eloi.WindowClipboard2Image.Copy();
        //m_b64PngTextVersion = Eloi.E_StringByte64Utility.
    }

}
