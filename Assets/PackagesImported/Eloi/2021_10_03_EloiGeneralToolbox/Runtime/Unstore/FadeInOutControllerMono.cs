using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeInOutControllerMono : MonoBehaviour
{

    public float m_pourcentOpacity = 0;
    public float m_pourcentSpeed = 0.5f;
    public float m_wantedPourcentOpacity = 0;
    public Eloi.PrimitiveUnityEvent_Float m_fadeChange;
    public UnityEvent m_fadeInReach;
    public UnityEvent m_fadeOutReach;

    [ContextMenu("GoFadeIn")]
    public void GoFadeIn_Transparent()
    {
        m_wantedPourcentOpacity = 0;
    }
    [ContextMenu("GoFadeOut")]
    public void GoFadeOut_Opaque()
    {
        m_wantedPourcentOpacity = 1;
    }
    [ContextMenu("GoFadeIn With Reset")]
    public void GoFadeInWithReset_Transparent()
    {
        m_pourcentOpacity = 1;
        m_wantedPourcentOpacity = 0;
    }
    [ContextMenu("GoFadeOut With Reset")]
    public void GoFadeOutWithReset_Opaque()
    {
        m_pourcentOpacity = 0;
        m_wantedPourcentOpacity = 1;
    }
    [ContextMenu("SetFadeIn")]
    public void SetFadeIn_Transparent()
    {
        m_wantedPourcentOpacity = 0;
        m_pourcentOpacity = 0;
        m_fadeChange.Invoke(m_pourcentOpacity);
        m_fadeInReach.Invoke();
    }
    [ContextMenu("SetFadeOut")]
    public void SetFadeOut_Opaque()
    {
        m_wantedPourcentOpacity = 1;
        m_pourcentOpacity = 1;
        m_fadeChange.Invoke(m_pourcentOpacity);
        m_fadeOutReach.Invoke();
    }

    private void Update()
    {
        float previousValue = m_pourcentOpacity;
        if (m_wantedPourcentOpacity != m_pourcentOpacity)
        {
            if (m_wantedPourcentOpacity == 1)
            {
                m_pourcentOpacity += Time.deltaTime * m_pourcentSpeed;
                if (m_pourcentOpacity > m_wantedPourcentOpacity)
                {
                    m_pourcentOpacity = m_wantedPourcentOpacity;

                }
            }
            if (m_wantedPourcentOpacity == 0)
            {
                m_pourcentOpacity -= Time.deltaTime * m_pourcentSpeed;
                if (m_pourcentOpacity < m_wantedPourcentOpacity)
                {

                    m_pourcentOpacity = m_wantedPourcentOpacity;

                }
            }
           
        }
        m_fadeChange.Invoke(m_pourcentOpacity);

        if (previousValue < 1f && m_pourcentOpacity >= 1)
            m_fadeOutReach.Invoke();
        if (previousValue >0f && m_pourcentOpacity <= 0)
            m_fadeInReach.Invoke();
    }


    public void GoToFadeIn(bool inverse = false)
    {
        if (inverse)
            GoFadeIn_Transparent();
        else
            GoFadeOut_Opaque();
    }
    public void GoToFadeOut(bool inverse = false)
    {
        if (inverse)
            GoFadeOut_Opaque();
        else
            GoFadeIn_Transparent();
    }
}
