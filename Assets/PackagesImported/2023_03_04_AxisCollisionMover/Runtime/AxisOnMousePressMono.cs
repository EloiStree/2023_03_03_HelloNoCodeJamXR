using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AxisOnMousePressMono : MonoBehaviour
{

    public BoolEvent m_onPressingChanged;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { };


    public void OnMouseDown()
    {
        m_onPressingChanged.Invoke(true);
    }
    public void OnMouseUp()
    {

        m_onPressingChanged.Invoke(false);
    }
}
