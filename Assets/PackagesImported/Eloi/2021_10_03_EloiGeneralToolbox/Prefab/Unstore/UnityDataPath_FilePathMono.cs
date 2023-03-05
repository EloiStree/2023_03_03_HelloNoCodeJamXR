using Eloi;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UnityDataPath_FilePathMono : Eloi.AbstractMetaAbsolutePathFileMono
{
    public Eloi.MetaRelativePathDirectory m_subfolders;
    public Eloi.MetaFileNameWithExtension m_fileName;

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
    [ContextMenu("Try to open Path builded in Editor")]
    public void TryToOpenEditorDebugPathFolder()
    {

        Application.OpenURL(Path.GetDirectoryName(m_debugPath));
    }

    public override void GetPath(out string path)
    {
        IMetaAbsolutePathDirectoryGet dir;
        dir = new MetaAbsolutePathDirectory(Application.dataPath);
        #if UNITY_EDITOR 
                dir =  new MetaAbsolutePathDirectory(Application.persistentDataPath);
#endif
        IMetaAbsolutePathFileGet pathResult = Eloi.E_FileAndFolderUtility.Combine(dir, m_subfolders, m_fileName);
        pathResult.GetPath(out path);
        m_debugPath = path;
    }

    public override string GetPath()
    {
        GetPath(out string p);
        return p;
    }

    public void CreateEmptyFileAtDestinationIfNotExisting()
    {
        GetPath(out string p);
        if (!File.Exists(p))
            File.CreateText(p);
    }
    public void CreateFileAtDestinationIfNotExisting(string text)
    {
        GetPath(out string p);
        if (!File.Exists(p))
            File.WriteAllText(p, text);
    }
}

