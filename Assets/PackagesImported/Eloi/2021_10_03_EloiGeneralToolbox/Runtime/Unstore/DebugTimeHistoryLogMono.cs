using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTimeHistoryLogMono : MonoBehaviour
{

    public string m_lastTickDate;
    public Eloi.StringClampHistory m_tickDateHistory = new Eloi.StringClampHistory();

    public void SaveTickNow() {
        m_lastTickDate = DateTime.Now.ToString();
        m_tickDateHistory.PushIn(m_lastTickDate);
    }
}
