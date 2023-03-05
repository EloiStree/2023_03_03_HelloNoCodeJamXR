using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugDrawLinesFromVector3Mono : MonoBehaviour
{
    public Vector3[] m_points;
    public Color m_color = Color.yellow;
    public bool m_drawEndToStart;

    void Update()
    {
        if (m_points.Length > 1)
        {
            Vector3[] points = m_points.Select(k => k).ToArray();
            Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, m_color, points);
            if (m_drawEndToStart) {
                Eloi.E_DrawingUtility.DrawLines(Time.deltaTime, m_color, new Vector3[] { m_points[m_points.Length - 1], m_points[0]});

            }
        }

    }

    public void SetPoints(Vector3[] points)
    {
        m_points = points;
    }
    public void SetPoints(List<Vector3> points)
    {
        m_points = points.ToArray();
    }

}
