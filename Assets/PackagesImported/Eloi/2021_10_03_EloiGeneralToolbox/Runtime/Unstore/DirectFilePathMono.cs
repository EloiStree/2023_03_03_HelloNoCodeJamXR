using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectFilePathMono : Eloi.AbstractMetaAbsolutePathFileMono
{

    public Eloi.MetaAbsolutePathDirectory m_folderPath;
    public Eloi.MetaFileNameWithExtension m_fileName;


    public void SetPath(string path) {
        Eloi.MetaAbsolutePathFile pathRef = new MetaAbsolutePathFile(path);
        Eloi.E_FileAndFolderUtility.SplitInfo(pathRef,
            out IMetaAbsolutePathDirectoryGet dir,
            out IMetaFileNameWithExtensionGet fileInfo);
        m_folderPath.SetPath(dir.GetPath());
        fileInfo.GetFileNameWithoutExtension(out string fileName);
        fileInfo.GetExtensionWithoutDot(out string fileExtension);
        m_fileName.SetFileName(fileName, fileExtension);
    }
public override void GetPath(out string path)
{
        if (m_folderPath.IsEmpty() && m_fileName.IsEmpty())
        { 
            path= "";
            return;
        }

        IMetaAbsolutePathDirectoryGet d = m_folderPath;
               IMetaFileNameWithExtensionGet f = m_fileName;
         path =E_FileAndFolderUtility.Combine(in d, in  f).GetPath();
}

public override string GetPath()
{
        GetPath(out string path);
        return path;
}

}
