using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace be.eloistree.generaltoolbox
{
    public class QuickRotateMono : MonoBehaviour
    {

        public Transform m_toAffect;
        public Vector3 m_rotation;
        public Space m_rotationType;
       
        void Update()
        {
            m_toAffect.Rotate(m_rotation * Time.deltaTime , m_rotationType) ;
        }
    }
}
