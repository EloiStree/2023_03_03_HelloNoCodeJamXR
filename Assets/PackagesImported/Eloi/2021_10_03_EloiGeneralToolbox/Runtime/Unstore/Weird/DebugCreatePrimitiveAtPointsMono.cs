using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DebugCreatePrimitiveAtPointsMono : MonoBehaviour
    {

        public string m_primitiveName = "Anchor Point";
        public PrimitiveType m_primitiveToCreate;
        public float m_primitiveSize = 0.05f;

        public void CreatePrimitiveAtPoints(Vector3[] points ) {

            foreach (var item in points)
            {
                 GameObject gamo=    GameObject.CreatePrimitive(m_primitiveToCreate);
                gamo.name = m_primitiveName;
                gamo.transform.position = item;
                gamo.transform.localScale = Vector3.one * m_primitiveSize;
            }
        
        
        }
    }
}
