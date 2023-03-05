using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContinusTick : MonoBehaviour
{
    public float m_startTime = 5;
    public float m_repeatTime = 20;
    public UnityEvent m_tick;

    public float m_countDown;
    void Awake()
    {
        m_countDown = m_startTime;
    }



    void Update()
    {
        m_countDown -= Time.deltaTime;
        if (m_countDown <=0)
        {
            m_countDown = m_repeatTime;
            m_tick.Invoke();
        }


    }
}
