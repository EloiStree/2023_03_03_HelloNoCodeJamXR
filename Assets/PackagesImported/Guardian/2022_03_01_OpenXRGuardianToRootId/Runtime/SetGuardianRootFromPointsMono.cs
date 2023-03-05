using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGuardianRootFromPointsMono : MonoBehaviour
{


    public Vector3[] m_guardiantAsPoints;
    public Vector3 m_worldPosition;
    public Quaternion m_worldRotation;
    public Transform m_debugRootFromPoints;
    public Eloi.ClassicUnityEvent_Vector3 m_guardianRootPosition;
    public Eloi.ClassicUnityEvent_Quaternion m_guardianRootRotation;

    public void SetPoints(Vector3[] points) {
        m_guardiantAsPoints = points;




        m_worldPosition = Vector3.zero;
        m_worldRotation = Quaternion.identity;

        if (points.Length==0) {

            m_worldPosition = Vector3.zero;
            m_worldRotation = Quaternion.identity;
        }

        if (points.Length == 1)
        {
            m_worldPosition = points[0];
            m_worldRotation = Quaternion.identity;
        }
        if (points.Length == 2)
        {
            m_worldPosition = points[0];
            m_worldRotation = Quaternion.LookRotation(points[1] - points[0], Vector3.up);
        }
        if (points.Length >= 3)
        {
            Vector3 dirA = points[1] - points[0];
            Vector3 dirB = points[1] - points[2];
            Vector3 dirUp = Vector3.Cross(dirB, dirB);
            Vector3 dirForward = dirA;
            //Vector3 dirRight = Vector3.Cross(dirUp, dirForward);
            Quaternion cartesianRot  = Quaternion.LookRotation(dirForward, dirUp);

            m_worldPosition = points[1];
            m_worldRotation = cartesianRot;
        }

        if (m_debugRootFromPoints) {
            m_debugRootFromPoints.position = m_worldPosition;
            m_debugRootFromPoints.rotation = m_worldRotation;
        }
        m_guardianRootPosition.Invoke(m_worldPosition);
        m_guardianRootRotation.Invoke(m_worldRotation);
    }
}
