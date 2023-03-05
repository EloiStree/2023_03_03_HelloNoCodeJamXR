using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileImport_FromAbstractPathMono : MonoBehaviour
{
    public Eloi.AbstractMetaAbsolutePathFileMono m_filePath;
   
        public Eloi.ClassicUnityEvent_Texture2D m_textureFetched;
        public Texture2D m_lastImported;
        public Texture2D m_defaultIfNotFound;
        
    [ContextMenu("Import")]
    public void Import()
        {
        Texture2D toPush = m_defaultIfNotFound;
        try
        {
            Eloi.E_FileAndFolderUtility.ImportTexture(m_filePath, out toPush);
        }
        catch (Exception) {  
        }
            m_lastImported = toPush;
            m_textureFetched.Invoke(toPush);
        }
    }

