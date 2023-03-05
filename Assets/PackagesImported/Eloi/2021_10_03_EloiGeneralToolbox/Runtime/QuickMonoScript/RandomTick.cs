using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomTick : MonoBehaviour
{
    public float m_startTime;
    public float m_minTime, m_maxTime;
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
            m_countDown = UnityEngine.Random.Range(m_minTime, m_maxTime);
            m_tick.Invoke();
        }
    }
}
