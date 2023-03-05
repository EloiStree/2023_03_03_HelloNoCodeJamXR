using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayTick : MonoBehaviour
{
    public bool m_onAwake;
    public bool m_onStart=true;
    public bool m_onEnable;
    public float m_timeWhenToTick=0.2f;
    public UnityEvent m_tick;

    void Awake()
    {
        if (m_onAwake) LaunchDelayedTick();
    }
    void Start()
    {
        if (m_onStart) LaunchDelayedTick();
    }
    void OnEnable()
    {
        if (m_onEnable) LaunchDelayedTick();
    }

    [ContextMenu("LaunchDelayedTick")]
    public void LaunchDelayedTick()
    {
        Invoke("Tick", m_timeWhenToTick);

    }

    [ContextMenu("Tick")]
    void Tick()
    {
        m_tick.Invoke();
    }
}
