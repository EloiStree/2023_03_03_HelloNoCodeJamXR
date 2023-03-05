using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExportFileByOverridingMono : MonoBehaviour
{
    public Eloi.AbstractMetaAbsolutePathDirectoryMono m_directory;
    public Eloi.MetaFileNameWithExtension m_relativeFile;
    public void Export(string text) {
       Eloi.IMetaAbsolutePathFileGet file =  Eloi.E_FileAndFolderUtility.Combine(m_directory, m_relativeFile);
        string filePath = file.GetPath();
        Eloi.E_FilePathUnityUtility.GetDirectoryPathOf(in filePath , out string directoryPath);
        Directory.CreateDirectory(directoryPath);
        File.WriteAllText(filePath, text);
    }
}
