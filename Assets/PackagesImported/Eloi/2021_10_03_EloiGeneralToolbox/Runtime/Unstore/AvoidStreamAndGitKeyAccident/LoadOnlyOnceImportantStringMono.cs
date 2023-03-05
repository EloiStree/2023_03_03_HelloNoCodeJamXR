using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnlyOnceImportantStringMono : AbstractImportantStringMono
{
    public AbstractImportantStringMono m_source;
    private string m_loaded="";

    public override void GetStringValue(out string value)
    {
        if (m_source == null) {
            value = "";
            return;
        }

        if (m_loaded!=null &&  m_loaded.Length > 0) { 
            value = m_loaded;
            return;
        }
        m_source.GetStringValue(out m_loaded);
        value = m_loaded;
    }

    
}
