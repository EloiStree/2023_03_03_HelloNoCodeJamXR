using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransparentOfRendererMono : MonoBehaviour
{
    public Renderer m_targetRenderer;
    public Material m_targetMaterial;
    public void SetTransparence(float pourcentTransparency) {
        if (m_targetRenderer)
        {
            Color c = m_targetRenderer.material.color;
            c.a = pourcentTransparency;
            m_targetRenderer.material.color = c;
        }
        if (m_targetMaterial)
        {
            Color c = m_targetMaterial.color;
            c.a = pourcentTransparency;
            m_targetMaterial.color = c;
        }

    }
}
