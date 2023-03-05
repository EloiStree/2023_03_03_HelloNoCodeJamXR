using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture2DToRendererMono : MonoBehaviour
{
    public Renderer m_target;
    public string m_textureName = "_Base";

    [Header("Log")]
    public Texture2D m_texture;
    public RenderTexture m_renderTexture;
    public void PushTexture2D(Texture2D texture)
    {
        m_texture = texture;
        m_target.material.SetTexture(m_textureName, texture);
    }
    public void PushTexture2D(Texture texture)
    {
        if (texture is Texture2D) PushTexture2D((Texture2D)texture);
        if (texture is RenderTexture) PushTexture2D((RenderTexture)texture);
    }
    public void PushTexture2D(RenderTexture texture)
    {
        m_target.material.SetTexture(m_textureName, texture);
        m_renderTexture = texture;
    }
    public void Reset()
    {
        m_target = GetComponent<Renderer>();
    }

    [ContextMenu("Set Base")]
    public void SetForURP_Base() { m_textureName = "_Base"; }
    [ContextMenu("Set Base Map")]
    public void SetForURP_BaseMap() { m_textureName = "_BaseMap"; }
    [ContextMenu("Set Main Tex")]
    public void SetForStandar_MainTex() { m_textureName = "_MainTex"; }
}
