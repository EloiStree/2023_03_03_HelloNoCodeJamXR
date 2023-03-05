using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayTicksMono : MonoBehaviour
{

    public InvokeDelayTick[] m_ticks;

    void Start()
    {
        for (int i = 0; i < m_ticks.Length; i++)
        {
            m_ticks[i].Reset();
        }
    }
    
    void Update()
    {
        float td = Time.deltaTime;
        for (int i = 0; i < m_ticks.Length; i++)
        {
            m_ticks[i].RemoveTime(td, out bool  finished);
            if (finished)
                m_ticks[i].DoTheThing();
        }
        
    }
}
[System.Serializable]
public class InvokeDelayTick
{
    public string m_stepDescription;
    public UnityEvent m_whatToDo;
    public float m_whenToDoInSeconds = 0.1f;
    private float m_timeLeft;


    public void DoTheThing()
    {
        m_whatToDo.Invoke();
    }

    public void RemoveTime(float deltaTime, out bool finishedTriggered)
    {
        if (m_timeLeft <= 0) {
            finishedTriggered = false;
            return;
        }
        float tPrevious = m_timeLeft;
        m_timeLeft -= deltaTime;
        finishedTriggered = (tPrevious > 0 && m_timeLeft <= 0f);
    }

    public void Reset()
    {
        m_timeLeft = m_whenToDoInSeconds;
    }
}