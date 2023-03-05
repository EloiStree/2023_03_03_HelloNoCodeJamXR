using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffuseVector3TransformPositionMono : MonoBehaviour
{
    public Transform m_observedTransform;
    public Space m_worldSpaceUse;
    public Eloi.ClassicUnityEvent_Vector3 m_onDiffusedPosition;
    public bool m_useUpdate=true;

    public virtual Vector3 GetCurrentPosition()
    {
        if (m_worldSpaceUse == Space.World)
            return m_observedTransform.position;
        else
            return m_observedTransform.localPosition;
    }
    public void Update()
    {
        if(m_useUpdate)
            m_onDiffusedPosition.Invoke(GetCurrentPosition());
    }
    private void Reset()
    {
        m_observedTransform = this.transform;
    }
}
