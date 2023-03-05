using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class OnTheGoMonoStaticEvent : MonoBehaviour
    {

        public List<MonoStaticEvent> m_staticEvents;
        public List<NameId2MonoStaticEvent> m_namedIdStaticEvents;
        public bool m_autoListenAwakeDestroy = true;

        public void NotifyEventEverywhere(Eloi.StringIdScriptable eventId) => MonoStaticEvent.NotifyEveryWhere(eventId.GetValue(),this.gameObject);
        public void NotifyEventEverywhere(string eventId) => MonoStaticEvent.NotifyEveryWhere(eventId,this.gameObject);

        void Awake()
        {
            if (m_autoListenAwakeDestroy) {
                foreach (var item in m_staticEvents)
                {
                    item.AddAsStaticListener();
                }
                foreach (var item in m_namedIdStaticEvents)
                {
                    item.AddAsStaticListener(gameObject);
                }
            }
        }

        private void OnDestroy()
        {
            if (m_autoListenAwakeDestroy) { 
                foreach (var item in m_staticEvents)
                {
                    item.RemoveAsStaticListener();
                }
                foreach (var item in m_namedIdStaticEvents)
                {
                    item.RemoveAsStaticListener();
                }
            }
        }

    }
}
