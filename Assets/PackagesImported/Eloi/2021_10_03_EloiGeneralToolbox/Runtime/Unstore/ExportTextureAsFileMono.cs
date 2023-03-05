using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportTextureAsFileMono : MonoBehaviour
{

    public Eloi.AbstractMetaAbsolutePathFileMono m_fileExportPath;

    public Texture2D m_lastSent;

    public void PushTexture(Texture2D texture) {
        m_lastSent = texture;
        Eloi.E_FileAndFolderUtility.ExportTextureAsPNG(m_fileExportPath, texture, true, true);
    }
}
