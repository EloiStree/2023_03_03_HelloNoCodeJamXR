using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringHistoryDebugMono : MonoBehaviour
{
    public Eloi.StringClampHistory m_debugHistory;

    public void PushIn(string id)
    {
        m_debugHistory.PushIn(id);
    }
    public void PushIn(char id)
    {
        m_debugHistory.PushIn(""+id);
    }
    //public void Clear() {
    //    m_debugHistory.Clear();
    //}
}
