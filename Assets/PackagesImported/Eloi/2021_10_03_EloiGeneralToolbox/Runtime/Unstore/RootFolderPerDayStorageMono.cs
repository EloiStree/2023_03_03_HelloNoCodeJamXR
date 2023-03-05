using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootFolderPerDayStorageMono : Eloi.AbstractMetaAbsolutePathDirectoryMono
{
    public Eloi.MetaRelativePathDirectory m_subfolders;
    public string m_debugPath;

    [ContextMenu("Verify Path builded in Editor")]
    public void TryToOpenEditorDebugPath()
    {
        Application.OpenURL(m_debugPath);
    }
    
    public override void GetPath(out string path)
    {

        Eloi.E_FileAndFolderUtility.GetExecutableOrProjectRoot(out string rootpath);
        IMetaAbsolutePathDirectoryGet dir = new MetaAbsolutePathDirectory(rootpath);
        IMetaRelativePathDirectoryGet date = new MetaRelativePathDirectory( DateTime.Now.ToString("yyyy_MM_dd"));
        dir = E_FileAndFolderUtility.GetParent(in dir);
        IMetaAbsolutePathDirectoryGet pathResult = Eloi.E_FileAndFolderUtility.Combine(dir, m_subfolders, date);
        pathResult.GetPath(out path);
        m_debugPath = path;
    }

    public override string GetPath()
    {
        GetPath(out string p);
        return p;
    }

}
