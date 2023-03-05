using System;
using UnityEngine;
using Eloi;

public class TimeOfDayTick_AtSpecificDate : MonoBehaviour
{

    public OverwatchDateTimeUnityEventRefreshable m_timeOfDay;
    public bool m_useUpdate=true;
    void Update()
    {
        if(m_useUpdate)
        RefreshTimePast();
    }

    void RefreshTimePast()
    {
        m_timeOfDay.RefreshWithNow();
    }
}
