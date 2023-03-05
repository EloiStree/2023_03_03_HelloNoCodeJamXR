using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomContinusTick : MonoBehaviour
{
    public float m_startTime = 3;
    public float m_repeatTimeMin = 3;
    public float m_repeatTimeMax = 6;
    public UnityEvent m_tick;

    public float m_countDown;
    void Awake()
    {
        m_countDown = m_startTime;
    }

    void Update()
    {
        m_countDown -= Time.deltaTime;
        if (m_countDown <= 0)
        {
            m_countDown = UnityEngine.Random.Range(m_repeatTimeMin, m_repeatTimeMax);
            m_tick.Invoke();
        }


    }
}
