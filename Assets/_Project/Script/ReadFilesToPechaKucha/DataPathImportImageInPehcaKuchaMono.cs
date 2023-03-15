using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DataPathImportImageInPehcaKuchaMono : MonoBehaviour
{

    public Eloi.AbstractMetaAbsolutePathDirectoryMono m_folderToImport;

    public Texture2D[] m_imageFound;

    public TextureArrayEvent m_onTextureFound;

    [System.Serializable]
    public class TextureArrayEvent : UnityEvent<Texture2D[]> { } 

    public void ImportImage() {

        m_folderToImport.GetPath(out string pathFolder);
        if ( !Directory.Exists(pathFolder) )
            Directory.CreateDirectory(pathFolder);
        string [] filePaths = Directory.GetFiles(pathFolder);

        filePaths = filePaths.OrderBy(k => k).ToArray();

        m_imageFound = new Texture2D[filePaths.Length];
        for (int i = 0; i < filePaths.Length; i++)
        {
            Eloi.MetaAbsolutePathFile file = new Eloi.MetaAbsolutePathFile(filePaths[i]);
            Eloi.E_FileAndFolderUtility.ImportTexture(file,out m_imageFound[i]);
        }
        m_onTextureFound.Invoke(m_imageFound);
    }
}
