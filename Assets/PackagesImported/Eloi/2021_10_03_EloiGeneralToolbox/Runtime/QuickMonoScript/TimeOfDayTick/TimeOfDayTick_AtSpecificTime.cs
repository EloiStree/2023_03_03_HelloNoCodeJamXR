using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayTick_AtSpecificTime : MonoBehaviour
{

    public OverwatchTimeOfDayUnityEventRefreshable m_timeOfDay;
    public bool m_useUpdate = true;
    void Update()
    {
        if (m_useUpdate)
            RefreshTimePast();
    }

    void RefreshTimePast()
    {
        m_timeOfDay.RefreshWithNow();
    }
}
