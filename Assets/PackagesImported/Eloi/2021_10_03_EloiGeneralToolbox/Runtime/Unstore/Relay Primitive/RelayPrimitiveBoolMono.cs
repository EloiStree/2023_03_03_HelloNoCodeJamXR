using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi { 
	[System.Serializable] public class RelayPrimitiveBoolMono : AbstractRelayPrimitiveMono<bool> {


        public Eloi.PrimitiveUnityEvent_Bool m_onTrue;
        public Eloi.PrimitiveUnityEvent_Bool m_onFalse;

        public override void NotifyChildren(in bool value)
        {
            base.NotifyChildren(value);
            if (value)
                m_onTrue.Invoke(value);
            else
                m_onFalse.Invoke(value);
        }
    }
}