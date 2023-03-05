using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseBoolStateRelayMono : MonoBehaviour
{
    public bool m_state;
    public Eloi.PrimitiveUnityEvent_Bool m_relayValue;
    public void SetState(bool value) { m_relayValue.Invoke(value); }

    [ContextMenu("SwitchState")]
    public void SwitchState()
    {
        m_state = !m_state;
        SetState(m_state);
    }
   
}
