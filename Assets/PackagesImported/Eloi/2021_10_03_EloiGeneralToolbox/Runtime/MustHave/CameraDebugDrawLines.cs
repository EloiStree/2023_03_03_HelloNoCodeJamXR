using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDebugDrawLines : MonoBehaviour
{
    public Camera m_camera;

    Vector3 m_lb = new Vector3(0, 0,1);
    Vector3 m_rb = new Vector3(1, 0, 1);
    Vector3 m_lt = new Vector3(0, 1, 1);
    Vector3 m_rt = new Vector3(1, 1, 1);

    Vector3 m_lbw = new Vector3(0, 0);
    Vector3 m_rbw = new Vector3(1, 0);
    Vector3 m_ltw = new Vector3(0, 1);
    Vector3 m_rtw = new Vector3(1, 1);
  
    void Update(){

        if(m_camera==null)
            return;
        m_lbw = m_camera.ViewportToWorldPoint(m_lb);
        m_rbw = m_camera.ViewportToWorldPoint(m_rb);
        m_ltw = m_camera.ViewportToWorldPoint(m_lt);
        m_rtw = m_camera.ViewportToWorldPoint(m_rt);
        Debug.DrawLine(m_lbw, m_rbw, Color.yellow);
        Debug.DrawLine(m_rtw, m_ltw, Color.yellow);
        Debug.DrawLine(m_rbw, m_rtw, Color.yellow);
        Debug.DrawLine(m_ltw, m_lbw, Color.yellow);

    }
}
