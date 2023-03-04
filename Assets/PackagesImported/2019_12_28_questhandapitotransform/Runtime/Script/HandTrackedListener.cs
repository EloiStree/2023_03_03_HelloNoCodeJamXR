using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandTrackedListener : MonoBehaviour
{

    public OVRHand m_handInfo;
    public SwitchStateBoolEvent m_isTracked;
    public SwitchStateBoolEvent m_highlyTracked;

    private OVRHand.TrackingConfidence m_currentState;
    OVRHand.TrackingConfidence m_previousState;
    private bool m_isTrackedState;
    bool m_isTrackedPreviousState;

    void Update()
    {
        m_currentState = m_handInfo.HandConfidence;
        m_isTrackedState = m_handInfo.IsTracked;

        if (m_isTrackedState != m_isTrackedPreviousState) {
            m_isTracked.Invoke(m_isTrackedState);
        }
        if (m_previousState != m_currentState) {
            m_highlyTracked.Invoke(m_currentState == OVRHand.TrackingConfidence.High);
        }

        m_previousState = m_currentState;
        m_isTrackedPreviousState = m_isTrackedState;
    }
    [System.Serializable]
    public class SwitchStateBoolEvent : UnityEvent<bool>{}
}
