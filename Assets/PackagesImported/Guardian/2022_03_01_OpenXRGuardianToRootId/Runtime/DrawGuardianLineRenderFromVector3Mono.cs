using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGuardianLineRenderFromVector3Mono : MonoBehaviour
{
    public LineRenderer m_lineRenderer;
    public Vector3[] m_pointsReceived;
    private void Awake()
    {
        SetGuardianWithVector3(m_pointsReceived);
    }

    public void SetGuardianWithVector3(Vector3[] points) {

        m_pointsReceived = points;
        if (!m_lineRenderer)
            return;
        if (points == null || points.Length < 2)
            return;
        m_lineRenderer.positionCount = points.Length+1;
        for (int i = 0; i < points.Length; i++)
        {
            m_lineRenderer.SetPosition(i, points[i]);
        }
        m_lineRenderer.SetPosition(points.Length, points[0]) ;


    }

    private void Reset()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        if(m_lineRenderer)
        m_lineRenderer.positionCount=(0);
    }


}
