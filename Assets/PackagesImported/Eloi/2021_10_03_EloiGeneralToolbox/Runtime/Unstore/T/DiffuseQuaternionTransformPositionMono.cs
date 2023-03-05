using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffuseQuaternionTransformPositionMono : MonoBehaviour
{
    public Transform m_observedTransform;
    public Space m_worldSpaceUse;
    public Eloi.ClassicUnityEvent_Quaternion m_onDiffusedRotation;

    public bool m_useUpdate = true;

    public virtual Quaternion GetCurrentRotation()
    {
        if (m_worldSpaceUse == Space.World)
            return m_observedTransform.rotation;
        else
            return m_observedTransform.localRotation;
    }

    public void Update()
    {
        m_onDiffusedRotation.Invoke(GetCurrentRotation());
    }
    private void Reset()
    {
        m_observedTransform = this.transform;
    }

}
