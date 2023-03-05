using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi { 
public class E_DateTime 
{



        public static void GetTimeOfDayAsDateTime(out DateTime date, in int hours = 0, in int minutes = 0, in int seconds = 0, in int milliseconds = 0)
        {
            DateTime now = DateTime.Now;
            date = new DateTime(now.Year, now.Month, now.Day, hours, minutes, seconds, milliseconds);

        }

        public static void IsBetween(in DateTime time, in DateTime start, in DateTime end, out bool isBetween)
            => isBetween = (time >= start && time <= end);

        public static DateTime Get1970Date()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0);
        }
        public static DateTime Get2000Date()
        {
            return new DateTime(2000, 1, 1, 0, 0, 0);
        }
        public static DateTime GetHarambeDate()
        {
            //The day were everything change forever...
            return new DateTime(2016, 05, 28, 0, 0, 0);
        }
        public double GetSecondsTimeSince1970()
        {
            return DateTime.Now.Subtract(Get1970Date()).TotalSeconds;
        }

        public static void IsBetween(in DateTime time, in DateTime start, in DateTime end, out bool isBetween, in bool startInclusive, in bool endInclusive)
        {
            if (start == end)
            {
                if (startInclusive && time == start)
                {
                    isBetween = true;
                    return;
                }
                if (endInclusive && time == end)
                {
                    isBetween = true;
                    return;
                }
            }




            if (startInclusive && endInclusive)
                isBetween = (time >= start && time <= end);
            else if (startInclusive && !endInclusive)
                isBetween = (time >= start && time < end);
            else if (!startInclusive && endInclusive)
                isBetween = (time > start && time <= end);
            else if (!startInclusive && !endInclusive)
                isBetween = (time > start && time < end);
            else
                isBetween = (time >= start && time <= end);
        }

       
        public static void GetDayClampBorder(in DateTime targetDate, out DateTime morning0000Oclock, out DateTime night2359Oclock)
        {
            morning0000Oclock = new DateTime(targetDate.Year, targetDate.Month, targetDate.Day, 0, 0, 0, 0, 0);
            night2359Oclock = new DateTime(targetDate.Year, targetDate.Month, targetDate.Day, 23, 59, 59, 999);
        }

        public static void Lerp(in DateTime from, in DateTime to, out DateTime date, in float percent)
        {
            Lerp(in from, in to, out date, (double)percent);
        }
        public static void Lerp(in DateTime from, in DateTime to, out DateTime date, in double percent)
        {
            TimeSpan t = to - from;

            if (t.TotalDays > 999)
            {
                date = from.AddSeconds(t.TotalSeconds * percent);

            }
            else 
            {
                date = from.AddMilliseconds(t.TotalMilliseconds * percent);

            }

        }
        public static void GetTimestamp(out long secondsSince1970, bool useUTC)
        {
            if (useUTC)
                secondsSince1970 = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            else
                secondsSince1970 = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        }
        public static void GetTimestampFrom(in DateTime date, out long secondsSince1970)
        {
                secondsSince1970 = new DateTimeOffset(date).ToUnixTimeSeconds();
        }
    }

/// <summary>
/// In most application I am doing for clients, the application must run over week and months. I need to be able to check what the application will look like at that precise time.
/// </summary>
public class E_SettableDateTime {

     static AbstractDateTimeManager m_dateTimeNowInstance;
    public static void SetDateTimeManager(AbstractDateTimeManager dateTimeManager) {
        if (dateTimeManager != null)
            m_dateTimeNowInstance = dateTimeManager;
    }

    public static void GetDateTimeManager(out AbstractDateTimeManager dateTimeNowInstance) {
        if (m_dateTimeNowInstance == null)
            m_dateTimeNowInstance = new ClassicCSharpDateTime();
        dateTimeNowInstance = m_dateTimeNowInstance;
    }

    public DateTime Now
    {
        get {
            GetDateTimeManager(out AbstractDateTimeManager now);
            return now.GetTimeNow();
        }
    }
    public  void GetTimeNow(out DateTime now) {
        GetDateTimeManager(out AbstractDateTimeManager nowManager);
        nowManager.GetTimeNow(out now);
    }
    public DateTime GetTimeNow() {
        GetDateTimeManager(out AbstractDateTimeManager nowManager);
        return nowManager.GetTimeNow();
    }
}

public abstract class AbstractDateTimeManager {

    public abstract void GetTimeNow(out DateTime now);
    public abstract DateTime GetTimeNow();
}


public class ClassicCSharpDateTime : AbstractDateTimeManager
{
    public bool m_useUTC;

    public override void GetTimeNow(out DateTime now)
    {
        if(m_useUTC)
            now = DateTime.UtcNow;
        else 
            now = DateTime.Now;
    }

    public override DateTime GetTimeNow()
    {
        if (m_useUTC)
            return DateTime.UtcNow;
        else
            return DateTime.Now;
    }
}


[Serializable]
public class LerpDateTimeManager : AbstractDateTimeManager
{

    public SerializableDateTime m_from;
    public SerializableDateTime m_to;

    [Range(0f,1f)]
    public double m_lerpPercent;

    public override void GetTimeNow(out DateTime now)
    {
        E_DateTime.Lerp(m_from.GetAsDate(), m_to.GetAsDate(), out now, in m_lerpPercent);
    }

    public override DateTime GetTimeNow()
    {
            GetTimeNow(out DateTime now);
            return now;
    }
}




[System.Serializable]
public class UnityDateTimeEvent : UnityEvent<DateTime> { }
[System.Serializable]
public class UnitySerializableDateEvent : UnityEvent<DateTime> { }
[System.Serializable]
public struct SerializableDateTime : IComparable
{


    public uint m_year;
    public byte m_month_1_12;
    public byte m_day_1_31;
    public byte m_hour_0_23;
    public byte m_minute_0_59;
    public byte m_second_0_59;

        public SerializableDateTime(uint year, byte month_1_12 = 1, byte day_1_31 = 1, byte hour_0_23 = 0, byte minute_0_59 = 0, byte second_0_59 = 0)
        {
            m_year = year;
            m_month_1_12 = month_1_12;
            m_day_1_31 = day_1_31;
            m_hour_0_23 = hour_0_23;
            m_minute_0_59 = minute_0_59;
            m_second_0_59 = second_0_59;
        }
        public SerializableDateTime(DateTime date)
        {
            m_year = (uint)date.Year;
            m_month_1_12 = (byte)date.Month;
            m_day_1_31 = (byte)date.Day;
            m_hour_0_23 = (byte)date.Hour;
            m_minute_0_59 = (byte)date.Minute;
            m_second_0_59 = (byte)date.Second;
        }

        public static SerializableDateTime Now { get {
                SerializableDateTime now = new SerializableDateTime();
                now.SetWithDate(DateTime.Now);
                return now;
            } }

        public int CompareTo(object obj)
    {
        if (obj is SerializableDateTime)
        {
            SerializableDateTime d = (SerializableDateTime)obj;
            GetAsDate(out DateTime dOrigine);
            d.GetAsDate(out DateTime toCompare);
            return dOrigine <= toCompare ? -1 : 1;
        }
        return 0;
    }

    public void GetAsDate(out DateTime date)
    {
        date = new DateTime((int)m_year, m_month_1_12, m_day_1_31, m_hour_0_23, m_minute_0_59, m_second_0_59);
    }
    public DateTime GetAsDate()
    {
        GetAsDate(out DateTime result);
        return result;
    }
    public void SetWithDate(in DateTime date)
    {
        m_year = (uint)date.Year;
        m_month_1_12 = (byte)date.Month;
        m_day_1_31 = (byte)date.Day;
        m_hour_0_23 = (byte)date.Hour;
        m_minute_0_59 = (byte)date.Minute;
        m_second_0_59 = (byte)date.Second;

    }
}



    [System.Serializable]
    public struct SerializableTimeOfDay : IComparable
    {
        public byte m_hour_0_23;
        public byte m_minute_0_59;
        public byte m_second_0_59;
        public ushort m_millisecond_0_999;

        public SerializableTimeOfDay( byte hour_0_23 = 0, byte minute_0_59 = 0, byte second_0_59 = 0, ushort millisecond_0_999 = 0)
        {
            m_hour_0_23 = hour_0_23;
            m_minute_0_59 = minute_0_59;
            m_second_0_59 = second_0_59;
            m_millisecond_0_999 = millisecond_0_999;
        }

        public int CompareTo(object obj)
        {
            if (obj is SerializableTimeOfDay)
            {
                SerializableTimeOfDay d = (SerializableTimeOfDay)obj;
                GetAsDateForToday(out DateTime dOrigine);
                d.GetAsDateForToday(out DateTime toCompare);
                return dOrigine <= toCompare ? -1 : 1;
            }
            return 0;
        }
        public void GetAsDateForToday( out DateTime date)
        {
            GetAsDateFor(DateTime.Now, out date);
        }
        public DateTime GetAsDateForToday()
        {
            GetAsDateFor(DateTime.Now, out DateTime result);
            return result;
        }
        public void GetAsDateFor(in DateTime targetDay, out DateTime date)
        {
            date = new DateTime(targetDay.Year, targetDay.Month, targetDay.Day, m_hour_0_23, m_minute_0_59, m_second_0_59, m_millisecond_0_999);
        }
        public DateTime GetAsDateFor(in DateTime targetDay)
        {
            GetAsDateFor(in targetDay, out DateTime result);
            return result;
        }
        public void SetWithDate(in DateTime date)
        {
            m_hour_0_23 = (byte) date.Hour;
            m_minute_0_59 = (byte) date.Minute;
            m_second_0_59 = (byte) date.Second;
            m_millisecond_0_999 = (ushort) date.Millisecond;
        }
    }





}