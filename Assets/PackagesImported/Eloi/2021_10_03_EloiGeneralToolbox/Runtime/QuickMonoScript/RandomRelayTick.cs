using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomRelayTick : MonoBehaviour
{

    [Range(0,1)]
    public float m_randomValuePercent=0.1f;
    public UnityEvent m_tickToPush;

    [ContextMenu("Try to push")]
    public void TryToPushTick()
    {
        TryToPushTickWithPercent(m_randomValuePercent);
    }
    public void TryToPushTickWithPercent(float percent)
    {
        Eloi.E_UnityRandomUtility.GetRandomN2M(0f, 1f, out float r);
        if (r < percent) {
            m_tickToPush.Invoke();
        }

    }
}
