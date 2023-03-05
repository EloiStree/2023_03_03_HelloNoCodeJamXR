using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnApplicationQuitTick : MonoBehaviour
{
    public UnityEvent m_tick;

    void OnApplicationQuit()
    {
        if (m_tick != null)
            m_tick.Invoke();
    }
}
