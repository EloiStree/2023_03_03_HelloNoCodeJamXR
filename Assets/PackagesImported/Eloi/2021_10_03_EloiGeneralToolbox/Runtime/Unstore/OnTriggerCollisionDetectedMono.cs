using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerCollisionDetectedMono : MonoBehaviour
{

    public LayerMask m_maskAllowed = ~0;
    public UnityEvent m_collisionDetected;
    

    void OnTriggerEnter(Collider collider) 
    {
        if (IsInLayerLayerMask(collider.gameObject.layer, in m_maskAllowed))
           m_collisionDetected.Invoke();
    }
    public static bool IsInLayerLayerMask(in int layer, in LayerMask layermask)
    {
        return layermask == (layermask | (1 << layer));
    }
}
