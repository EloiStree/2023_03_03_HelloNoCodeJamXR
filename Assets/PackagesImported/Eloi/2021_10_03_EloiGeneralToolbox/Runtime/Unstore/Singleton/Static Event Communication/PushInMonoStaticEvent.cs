
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public  class PushInMonoStaticEvent : MonoBehaviour
    {
        public  void NotifyEveryWhere(string eventId)
        {
            MonoStaticEvent.NotifyEveryWhere(eventId, this.gameObject);
        }
        public  void NotifyEveryWhere(Eloi.StringIdScriptable eventId)
        {
            MonoStaticEvent.NotifyEveryWhere(eventId,this.gameObject);
        }

    }
}
