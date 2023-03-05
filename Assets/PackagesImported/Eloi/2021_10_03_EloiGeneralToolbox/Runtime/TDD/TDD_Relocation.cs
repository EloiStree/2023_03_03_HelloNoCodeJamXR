using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eloi;

namespace Eloi
{


    public class TDD_Relocation : MonoBehaviour
    {

        public Transform m_root;
        public Transform m_source;
        public Transform m_sourceToLocal;
        public Transform m_localToWorld;

        public Vector3 m_rootPosition;
        public Quaternion m_rootRotation;

        public Vector3 m_directionPosition;
        public Quaternion m_directionRotation;


        void Update()
        {
            m_rootPosition = m_root.position;
            m_rootRotation = m_root.rotation;
            m_directionPosition = m_source.position;
            m_directionRotation = m_source.rotation;

            E_RelocationUtility.GetWorldToLocal_DirectionalPoint(
               in m_directionPosition, in m_directionRotation,
               in m_rootPosition, in m_rootRotation,
               out Vector3 lp, out Quaternion lr);

            m_sourceToLocal.position = lp;
            m_sourceToLocal.rotation = lr;

            E_RelocationUtility.GetLocalToWorld_DirectionalPoint(
                in lp, in lr,
                in m_rootPosition, in m_rootRotation,
                out Vector3 wp, out Quaternion wr);

            m_localToWorld.position = wp;
            m_localToWorld.rotation = wr;


        }
    }
}