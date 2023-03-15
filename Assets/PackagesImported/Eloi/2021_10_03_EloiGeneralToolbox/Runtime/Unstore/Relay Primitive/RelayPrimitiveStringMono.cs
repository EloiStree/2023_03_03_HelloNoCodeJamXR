using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi { 
[System.Serializable] public class RelayPrimitiveStringMono : AbstractRelayPrimitiveMono<string> {

        [ContextMenu("Repush given as value")]
        public new void RepushLastGivenValue()
        {
            base.RepushLastGivenValue();
        }

    }

    

}