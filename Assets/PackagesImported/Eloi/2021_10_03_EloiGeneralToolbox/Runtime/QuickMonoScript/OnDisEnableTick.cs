using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDisEnableTick : MonoBehaviour
{
    public UnityEvent m_enableTick;
    public UnityEvent m_disableTick;
    public void OnEnable()
    {
        if (m_enableTick != null)
            m_enableTick.Invoke();


    }

    public void OnDisable()
    {
        if (m_disableTick != null)
            m_disableTick.Invoke();


    }
}
