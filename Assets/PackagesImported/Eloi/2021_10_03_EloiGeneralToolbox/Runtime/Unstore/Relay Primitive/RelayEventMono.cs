using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class RelayEventMono : MonoBehaviour
    {
        public RelayEvent m_relay;
        public void PushEvents()
        {
            m_relay.PushEvents();
        }
    }

    [System.Serializable]
    public class RelayEvent
    {
        public Action m_devListener;
        public UnityEvent m_eventListener;
        public void PushEvents()
        {
            if (m_devListener != null)
                m_devListener.Invoke();
            m_eventListener.Invoke();
        }
    }
}
