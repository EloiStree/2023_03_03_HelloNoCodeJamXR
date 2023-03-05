using Eloi;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FromFileImportantStringMono : AbstractImportantStringMono
{
    public Eloi.AbstractMetaAbsolutePathFileMono m_whereToFindTheFile;
    public bool m_createIfNotThere;
    public string m_defaultValue = "";

    public override void GetStringValue(out string value)
    {
        m_whereToFindTheFile.GetPath(out string path);

        if (m_createIfNotThere)
        {
            if (!File.Exists(path))
                 File.WriteAllText(path,m_defaultValue);
            value = File.ReadAllText(path);
        }
        else {
            if (!File.Exists(path))
                value = m_defaultValue;
            else value = File.ReadAllText(path);

        }
    }

    
}
