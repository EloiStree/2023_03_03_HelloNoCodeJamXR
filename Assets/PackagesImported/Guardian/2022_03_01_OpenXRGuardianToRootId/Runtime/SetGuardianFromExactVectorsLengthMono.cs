using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetGuardianFromExactVectorsLengthMono : MonoBehaviour
{
    public string m_idGeneratedFromLenght;

    public uint m_exactLenght;
    public Vector3[] m_points;

    public Eloi.PrimitiveUnityEvent_String m_idGenerated;
    public Eloi.PrimitiveUnityEvent_Bool m_idFound;


    public float m_floatMultiplicator=1000f;
    public void SetGuardianIdFromPoints(Vector3[] points) {
        m_points = points;

        if (points.Length == 0 )
        {
            m_exactLenght = 0;
        }
        else if (points.Length == 1)
        {
            m_exactLenght =(uint) Vector3.Distance(Vector3.zero, points[0] * m_floatMultiplicator);
        }
        else {

            uint l = 0;
            for (int i = 1; i < points.Length; i++)
            {
                l += (uint)(Vector3.Distance(points[i - 1], points[i ]) * m_floatMultiplicator) ;
            }
            m_exactLenght = l;
        }
        
        m_idGenerated.Invoke(m_exactLenght.ToString());
        m_idFound.Invoke(m_exactLenght != 0);
    }
}
