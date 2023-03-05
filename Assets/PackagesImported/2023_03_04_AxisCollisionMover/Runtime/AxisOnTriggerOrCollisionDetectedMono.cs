
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AxisOnTriggerOrCollisionDetectedMono : MonoBehaviour
{

    public LayerMask m_maskAllowed = ~0;
    public UnityEvent m_collisionEnterDetected;
    public UnityEvent m_collisionExitDetected;
    public BoolEvent m_collisionDetected;
    public bool m_useTrigger=true;
    public bool m_useCollision;


    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { };


    public void OnCollisionEnter(Collision collision)
    {
        if (!m_useCollision) return;
        if (IsInLayerLayerMask(collision.gameObject.layer, in m_maskAllowed))
        {
            m_collisionEnterDetected.Invoke();
            m_collisionDetected.Invoke(true);
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (!m_useCollision) return;
        if (IsInLayerLayerMask(collision.gameObject.layer, in m_maskAllowed))
        {
            m_collisionExitDetected.Invoke();
            m_collisionDetected.Invoke(false);
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        if (!m_useTrigger) return;
        if (IsInLayerLayerMask(collider.gameObject.layer, in m_maskAllowed))
        {
            m_collisionEnterDetected.Invoke();
            m_collisionDetected.Invoke(true);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (!m_useTrigger) return;
        if (IsInLayerLayerMask(collider.gameObject.layer, in m_maskAllowed))
        {
            m_collisionExitDetected.Invoke();
            m_collisionDetected.Invoke(false);
        }
    }

    public static bool IsInLayerLayerMask(in int layer, in LayerMask layermask)
    {
        return layermask == (layermask | (1 << layer));
    }
}
