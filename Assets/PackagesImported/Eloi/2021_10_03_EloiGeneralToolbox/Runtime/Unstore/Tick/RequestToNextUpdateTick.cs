using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RequestToNextUpdateTick : MonoBehaviour
{
    public UnityEvent m_tick;

    public bool m_tickRequested;
    [ContextMenu("Tick")]
    public void RequestTick() => m_tickRequested = true;
    void Update()
    {
        if (m_tickRequested) {
            m_tickRequested = false;
            m_tick.Invoke();
        }
        
    }
}
