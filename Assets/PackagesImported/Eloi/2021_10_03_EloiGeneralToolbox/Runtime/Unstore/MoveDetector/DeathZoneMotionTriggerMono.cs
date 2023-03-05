using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class DeathZoneMotionTriggerMono : MonoBehaviour
    {
        public Transform m_observed;
        public bool m_usePosition=true;
        public float m_minDistanceDeathZone = 0.01f;

        public bool m_useRotation = true;
        public float m_minAngleDeathZone = 5;
        public UnityEvent  m_movedListener;

        public float m_distance;
        public float m_angle;

        public Vector3 m_previousPosition =  Vector3.zero;
        public Vector3 m_currentPosition = Vector3.zero;
        public Quaternion m_previousRotation = Quaternion.identity;
        public Quaternion m_currentRotation = Quaternion.identity;

        public void Update()
        {
            if (m_usePosition)
            {
                m_currentPosition = m_observed.position;
            }
            if (m_useRotation)
            {
                m_currentRotation = m_observed.rotation;
            }
            m_distance = Vector3.Distance(m_previousPosition, m_currentPosition);
            m_angle = Quaternion.Angle(m_previousRotation, m_currentRotation);

            bool isOutOfDeathZone = false;
            if ( m_distance > m_minDistanceDeathZone) {

                m_previousPosition = m_currentPosition;
                if(m_usePosition)
                isOutOfDeathZone = true;
            }
            if ( m_angle > m_minAngleDeathZone) {

                m_previousRotation = m_currentRotation;
                if (m_useRotation)
                    isOutOfDeathZone = true;
            }

            if(isOutOfDeathZone)
                m_movedListener.Invoke();
            
        }
    }
}
