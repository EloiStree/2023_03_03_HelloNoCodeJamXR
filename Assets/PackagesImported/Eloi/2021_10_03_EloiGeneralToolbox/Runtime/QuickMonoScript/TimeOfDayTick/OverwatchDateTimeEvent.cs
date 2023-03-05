using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OverwatchDateTime 
{
    public Eloi.SerializableDateTime m_timeOverwatched;
    public DateTime m_timeOverWatchedDate;
    public bool m_fromInclusive=false;
    public bool m_toInclusive=true;

    public void IsItTime(in DateTime from, in DateTime to, out bool isBetween) {
        m_timeOverWatchedDate = m_timeOverwatched.GetAsDate();
        Eloi.E_DateTime.IsBetween(in m_timeOverWatchedDate, in from, in to, out  isBetween, in m_fromInclusive, in m_toInclusive);
    }
}


[System.Serializable]
public class OverwatchDateTimeUnityEvent
{

    public UnityEvent m_toDoWhenTimeReached;
    public OverwatchDateTime m_overwatchTime;

    public void TriggerIfInTimeRange(in DateTime from, in DateTime to, out bool isBetween)
    {

        m_overwatchTime.IsItTime(in from, in to, out isBetween);
        if (isBetween)
            m_toDoWhenTimeReached.Invoke();
    }
}


[System.Serializable]
public class OverwatchDateTimeUnityEventRefreshable: OverwatchDateTimeUnityEvent
{

    private DateTime m_previous;
    private DateTime m_current;

    public void RefreshWith(in DateTime now, out bool isBetween)
    {
        m_previous = m_current;
        m_current = now;

        m_overwatchTime.IsItTime(in m_previous, in m_current, out isBetween);
        if (isBetween)
            m_toDoWhenTimeReached.Invoke();
    }
    public void RefreshWithNow(out bool isBetween)
    {
        RefreshWith(DateTime.Now, out isBetween);
    }
    public void RefreshWithNow()
    {
        RefreshWith(DateTime.Now, out bool isBetween);
    }
    public void RefreshWith(in DateTime now)
    {
        RefreshWith(now, out bool isBetween);
    }
}



[System.Serializable]
public class OverwatchTimeOfDay
{
    public Eloi.SerializableTimeOfDay m_timeOverwatched;
    public DateTime m_timeOverWatchedDate;
    public bool m_fromInclusive = false;
    public bool m_toInclusive = true;

    public void IsItTime(in DateTime from, in DateTime to, out bool isBetween)
    {
        m_timeOverWatchedDate = m_timeOverwatched.GetAsDateForToday();
        Eloi.E_DateTime.IsBetween(in m_timeOverWatchedDate, in from, in to, out isBetween, in m_fromInclusive, in m_toInclusive);
    }
}


[System.Serializable]
public class OverwatchTimeOfDayUnityEvent
{

    public UnityEvent m_toDoWhenTimeReached;
    public OverwatchTimeOfDay m_overwatchTime;

    public void TriggerIfInTimeRange(in DateTime from, in DateTime to, out bool isBetween)
    {

        m_overwatchTime.IsItTime(in from, in to, out isBetween);
        if (isBetween)
            m_toDoWhenTimeReached.Invoke();
    }
}
[System.Serializable]
public class OverwatchTimeOfDayUnityEventRefreshable : OverwatchTimeOfDayUnityEvent
{
    private DateTime m_previous;
    private DateTime m_current;

    public void RefreshWith(in DateTime now, out bool isBetween)
    {
        m_previous = m_current;
        m_current = now;

        m_overwatchTime.IsItTime(in m_previous, in m_current, out isBetween);
        if (isBetween)
            m_toDoWhenTimeReached.Invoke();
    }
    public void RefreshWithNow(out bool isBetween)
    {
        RefreshWith(DateTime.Now, out isBetween);
    }
    public void RefreshWithNow()
    {
        RefreshWith(DateTime.Now, out bool isBetween);
    }
    public void RefreshWith(in DateTime now)
    {
        RefreshWith(now, out bool isBetween);
    }
}