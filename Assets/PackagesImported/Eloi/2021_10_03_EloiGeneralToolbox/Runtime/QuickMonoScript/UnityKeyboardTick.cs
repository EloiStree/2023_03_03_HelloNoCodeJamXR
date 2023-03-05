using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityKeyboardTick : MonoBehaviour
{
    public KeyCode m_keyboard;
    public UnityEvent m_down;
    public UnityEvent m_up;
    public bool m_useUpdate;
    public UnityEvent m_update;
 
    void Update()
    {
        if (Input.GetKeyDown(m_keyboard))
            m_down.Invoke(); 
        if (Input.GetKeyUp(m_keyboard))
            m_up.Invoke(); 
        if(m_useUpdate)
        if (Input.GetKey(m_keyboard))
            m_update.Invoke();
    }
}
