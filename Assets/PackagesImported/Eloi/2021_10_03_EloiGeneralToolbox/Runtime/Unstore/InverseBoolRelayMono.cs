using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class InverseBoolRelayMono : MonoBehaviour
    {
        public Eloi.PrimitiveUnityEvent_Bool m_inverseValue;
        public void PushBoolean(bool value) { m_inverseValue.Invoke(!value);  }
    }
}
