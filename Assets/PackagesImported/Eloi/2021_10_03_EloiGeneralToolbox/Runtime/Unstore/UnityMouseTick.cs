using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi { 
public class UnityMouseTick : MonoBehaviour
{
    public MouseTrackEvent m_left = new MouseTrackEvent() { m_indexNumber=0};
    public MouseTrackEvent m_middle = new MouseTrackEvent() { m_indexNumber = 2 };
    public MouseTrackEvent m_right = new MouseTrackEvent() { m_indexNumber = 1 };


    [System.Serializable]
    public class MouseTrackEvent {
        public int m_indexNumber;
        public UnityEvent m_down;
        public UnityEvent m_up;
        public bool m_useUpdate;
        public UnityEvent m_update;
    }
    

    private void Update()
    {
        CheckMouseFor(in m_left);
        CheckMouseFor(in m_middle);
        CheckMouseFor(in m_right);
    }

    private void CheckMouseFor(in MouseTrackEvent mouseButton)
    {
        if (Input.GetMouseButtonDown(mouseButton.m_indexNumber))
            mouseButton.m_down.Invoke();
        if (Input.GetMouseButtonUp(mouseButton.m_indexNumber))
            mouseButton.m_up.Invoke();
        
        if (mouseButton.m_useUpdate &&
            Input.GetMouseButton(mouseButton.m_indexNumber))
            mouseButton.m_update.Invoke();
    }
}

}