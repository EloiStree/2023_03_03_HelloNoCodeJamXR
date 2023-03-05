using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugDrawLinesFromTransformMono : MonoBehaviour
{

    public Transform[] m_points;
    public Color m_color = Color.yellow;
   
    void Update()
    {
        if (m_points.Length > 1) { 
            Vector3[] points = m_points.Select(k=>k.position).ToArray(); 
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, m_color, points);
        }
    }

}
