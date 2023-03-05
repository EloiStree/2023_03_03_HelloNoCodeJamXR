using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAvailableImportantStringMono : AbstractImportantStringMono
{
    public List<AbstractImportantStringMono> m_priorityImport= new List<AbstractImportantStringMono>();
    public string m_defaultItNotFound = "";
    public override void GetStringValue(out string value)
    {
        for (int i = 0; i < m_priorityImport.Count; i++)
        {

            if (m_priorityImport[i] != null) {
                m_priorityImport[i].GetStringValue(out string valueTemp);
                if (valueTemp.Trim().Length >= 0)
                {
                    value = valueTemp;
                    return;
                }
            }
        }
        value = m_defaultItNotFound;
    }
}
