using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AwakeTick : MonoBehaviour
{
    public UnityEvent m_tick;
    void Awake()
    {
        Tick();
    }

    [ContextMenu("Tick")]
    public void Tick() {
        if (m_tick != null)
            m_tick.Invoke();
    }
   
}
