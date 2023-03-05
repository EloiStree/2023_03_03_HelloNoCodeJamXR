using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DebugDrawCameraFieldOfViewMono : MonoBehaviour
{


    public Camera m_target;
    public Color m_lineColor = Color.green;
    public bool m_drawMiddleLine;
    public Color m_lineMiddle = Color.red;

    private void Update()
    {
        if (m_target != null)
        {
            DrawLine(new Vector2(0, 0));
            DrawLine(new Vector2(0, 1));
            DrawLine(new Vector2(1, 0));
            DrawLine(new Vector2(1, 1));
            if(m_drawMiddleLine)
            DrawLine(new Vector2(0.5f, 0.5f), m_lineMiddle);
        }
    }
    private void DrawLine(Vector2 pt )
    { 
        DrawLine(pt, m_lineColor); 
    }
        private void DrawLine(Vector2 pt, Color color)
    {
        Vector3 start = m_target.ViewportToWorldPoint(new Vector3(pt.x, pt.y, m_target.nearClipPlane));
        Vector3 end = m_target.ViewportToWorldPoint(new Vector3(pt.x, pt.y, m_target.farClipPlane));
        Debug.DrawLine(start, end, m_lineColor, Time.deltaTime);
    }

     void Reset()
    {
        m_target = Camera.main;
        if (m_target == null)
            m_target = GetComponent<Camera>();
    }
}
