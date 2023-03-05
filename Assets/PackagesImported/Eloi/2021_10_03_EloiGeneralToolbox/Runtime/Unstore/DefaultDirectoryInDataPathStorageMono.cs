using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eloi;
using System.IO;

public class DefaultDirectoryInDataPathStorageMono : Eloi.AbstractMetaAbsolutePathDirectoryMono
{
    public Eloi.MetaRelativePathDirectory m_subfolders;

    public string m_debugPath;

    [ContextMenu("Verify Path builded in Editor")]
    public void GetEditorDebugPath()
    {
        GetPath(out string p);
    }
    [ContextMenu("Verify Path builded in Editor")]
    public void TryToOpenEditorDebugPath()
    {

        Application.OpenURL(m_debugPath);
    }
   


    public void SetRelativeFolderPath(string relativePath) {
        m_subfolders.SetPath(relativePath);
    }


    public override void GetPath(out string path)
    {
        IMetaAbsolutePathDirectoryGet dir = new MetaAbsolutePathDirectory(Application.dataPath);
        dir = E_FileAndFolderUtility.GetParent(in dir);
        IMetaAbsolutePathDirectoryGet pathResult = Eloi.E_FileAndFolderUtility.Combine(dir, m_subfolders);
        pathResult.GetPath(out path);
        m_debugPath = path;
    }

    public override string GetPath()
    {
        this.GetPath(out string p);
        return p;
    }


}
