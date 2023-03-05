using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AFKDetectionMono : MonoBehaviour
{
    public NotifyAFK[] m_afkObserved;
    public UnityEvent m_activityDetected;


    [SerializeField] float m_timeSinceLastInteraction;
    float m_previousTime ;


    void Update()
    {
        m_previousTime = m_timeSinceLastInteraction;
        m_timeSinceLastInteraction += Time.deltaTime;
        if (m_previousTime != m_timeSinceLastInteraction) { 
            for (int i = 0; i < m_afkObserved.Length; i++)
            {
                m_afkObserved[i].IsAfkReach(in m_previousTime, in m_timeSinceLastInteraction, out bool afkReachNow, out bool afk);
                if (afkReachNow)
                    m_afkObserved[i].NotifyAfk();
            }
        }
    }

    [ContextMenu("Notify Activity")]
    public void NotifyRecentActivity() {

        ResetTimers();
        m_activityDetected.Invoke();
    }

    public void ResetTimers()
    {
        m_previousTime = 0;
        m_timeSinceLastInteraction =0;
    }
}
[System.Serializable]
public class NotifyAFK
{
    public float m_notifyIfTimeOver = 10;
    public UnityEvent m_notifyPossibleAfk;

    public void IsAfkReach(in float previousTimeInSecond, in float timeInSecond, out bool afkReachNow, out bool afkReach) {
        if (previousTimeInSecond != timeInSecond)
        {
            afkReach = timeInSecond > m_notifyIfTimeOver;
            afkReachNow = previousTimeInSecond < m_notifyIfTimeOver && timeInSecond >= m_notifyIfTimeOver  ;
        }
        else {
            afkReach = false;
            afkReachNow = false;
        }
       
    }
    public void NotifyAfk() {
        m_notifyPossibleAfk.Invoke();
    }
}
