using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{

    [System.Serializable]
    public class MonoStaticEvent
    {
        public delegate void ToCallWhenInvoke();
        public static Dictionary<string, ToCallWhenInvoke> m_staticListener = new Dictionary<string, ToCallWhenInvoke>();

        public string m_eventId;
        public UnityEvent m_toDoOnTrigger;
        public static EventNotification m_listenToAllGlobalEvent;
        public delegate void EventNotification(string eventNameId);

        public static void AddAllGlobalEventListener(EventNotification listener)
        {
            m_listenToAllGlobalEvent += listener;

        }
        public static void RemoveAllGlobalEventListener(EventNotification listener)
        {

            m_listenToAllGlobalEvent -= listener;
        }

        public static bool m_debugSource=false;
        public static void NotifyEveryWhere(string eventId,in  GameObject source)
        {
            if (m_debugSource)
                Debug.Log("EVENT + SOURCE:" + eventId, source);
            if (m_staticListener.ContainsKey(eventId))
                if (m_staticListener[eventId] != null)
                    m_staticListener[eventId]();
            if(m_listenToAllGlobalEvent!=null)
                m_listenToAllGlobalEvent(eventId);
        }



        public static void NotifyEveryWhere(StringIdScriptable eventId, in GameObject source)
        {
            NotifyEveryWhere(eventId.GetValue(), in source);
        }
        public static void NotifyEveryWhere(StringIdScriptable eventId)
        {
            NotifyEveryWhere(eventId.GetValue(), null);
        }

        public MonoStaticEvent()
        {
            m_eventId = "";
        }

        public MonoStaticEvent(string eventId)
        {
            m_eventId = eventId;
        }

        public static void AddEventListener(StringIdScriptable eventId, ToCallWhenInvoke toDo)
        {
            AddEventListener(eventId.GetValue(), toDo);
        }
        public static void AddEventListener(string eventId, ToCallWhenInvoke toDo)
        {
            if (!m_staticListener.ContainsKey(eventId))
                m_staticListener.Add(eventId, null);
            if (m_staticListener.ContainsKey(eventId))
                m_staticListener[eventId] -= toDo;
            if (m_staticListener.ContainsKey(eventId))
                m_staticListener[eventId] += toDo;
        }
        public static void RemoveEventListener(StringIdScriptable eventId, ToCallWhenInvoke toDo)
        {
            RemoveEventListener(eventId.GetValue(), toDo);
        }
        public static void RemoveEventListener(string eventId, ToCallWhenInvoke toDo)
        {

            if (!m_staticListener.ContainsKey(eventId))
                return;
            if (m_staticListener.ContainsKey(eventId))
                m_staticListener[eventId] -= toDo;

        }

        public void AddAsStaticListener()
        {
            if (!m_staticListener.ContainsKey(m_eventId))
                m_staticListener.Add(m_eventId, null);
            if (m_staticListener.ContainsKey(m_eventId))
                m_staticListener[m_eventId] -= TriggerLocalEvent;
            if (m_staticListener.ContainsKey(m_eventId))
                m_staticListener[m_eventId] += TriggerLocalEvent;
        }

        public string GetEventId()
        {
            return m_eventId;
        }

        public void RemoveAsStaticListener()
        {
            if (!m_staticListener.ContainsKey(m_eventId))
                return;
            if (m_staticListener.ContainsKey(m_eventId))
                m_staticListener[m_eventId] -= TriggerLocalEvent;
        }

        public void NotifyEverywhere()
        {
            MonoStaticEvent.NotifyEveryWhere(m_eventId,null);
        }
        public void TriggerLocalEvent()
        {
            m_toDoOnTrigger.Invoke();
        }
    }


    [System.Serializable]
    public class NameId2MonoStaticEvent
    {

        public Eloi.StringIdScriptable m_eventId;
        public UnityEvent m_toDoOnTrigger;
        private GameObject m_source;

        public NameId2MonoStaticEvent()
        {
            m_eventId = null;
        }

        public NameId2MonoStaticEvent(Eloi.StringIdScriptable eventId)
        {
            m_eventId = eventId;
        }

        public void AddAsStaticListener(in GameObject source)
        {
            m_source = source;
            if (!MonoStaticEvent.m_staticListener.ContainsKey(GetEventId()))
                MonoStaticEvent.m_staticListener.Add(GetEventId(), null);
            if (MonoStaticEvent.m_staticListener.ContainsKey(GetEventId()))
                MonoStaticEvent.m_staticListener[GetEventId()] += TriggerLocalEvent;
        }
        public void RemoveAsStaticListener()
        {
            if (!MonoStaticEvent.m_staticListener.ContainsKey(GetEventId()))
                return;
            if (MonoStaticEvent.m_staticListener.ContainsKey(GetEventId()))
                MonoStaticEvent.m_staticListener[GetEventId()] -= TriggerLocalEvent;
        }

        public string GetEventId()
        {
            return m_eventId.GetValue();
        }

        public void NotifyEverywhereIfEquals(in GameObject source, in StringIdScriptable id, in bool ignoreCase, bool useTrim)
        {
            if (id == m_eventId)
            {
                NotifyEverywhere(in source);
            }
            else
            {
                NotifyEverywhereIfEquals(in source, id.GetValue(), ignoreCase, useTrim);
            }

        }
        public void NotifyEverywhereIfEquals( in GameObject source ,string id, bool ignoreCase = true, bool useTrim = true)
        {
            if (Eloi.E_StringUtility.AreEquals(
                    id, m_eventId.GetValue(), ignoreCase, useTrim))
                NotifyEverywhere(in source);
        }
        public void NotifyEverywhere()
        {
            MonoStaticEvent.NotifyEveryWhere(GetEventId(), in m_source);
        }
        public void NotifyEverywhere(in GameObject source)
        {
            MonoStaticEvent.NotifyEveryWhere(GetEventId(),in source);
        }
        public void TriggerLocalEvent()
        {
            m_toDoOnTrigger.Invoke();
        }
    }
}
