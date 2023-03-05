using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtractGuardianFromOVRBoundaryMono : MonoBehaviour
{

    public bool m_isBoundaryConfigured;
    public Vector3[] m_guardianPoints;


    public BoolEvent m_onBoundaryConfigured;
    public Vector3ArrayEvent m_onGuardiantPushed;
    public bool m_pushAtStart=true;

    private void Start()
    {
        if (m_pushAtStart)
            PushPointsFromGuardian();
    }

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    [System.Serializable]
    public class Vector3ArrayEvent : UnityEvent<Vector3[]> { }

    [ContextMenu("PushPointsFromGuardian")]
    public void PushPointsFromGuardian() {

            m_isBoundaryConfigured = OVRManager.boundary.GetConfigured();
            if (m_isBoundaryConfigured)
            {
                m_guardianPoints = OVRManager.boundary.GetGeometry(OVRBoundary.BoundaryType.OuterBoundary);
            }
            else m_guardianPoints = new Vector3[0];

            m_onBoundaryConfigured.Invoke(m_isBoundaryConfigured);
            m_onGuardiantPushed.Invoke(m_guardianPoints);
        }
}
