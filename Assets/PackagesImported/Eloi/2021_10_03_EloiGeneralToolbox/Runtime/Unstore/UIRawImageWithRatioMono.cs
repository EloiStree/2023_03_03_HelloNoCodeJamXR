using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIRawImageWithRatioMono : MonoBehaviour
{
    public RawImage m_imageToAffect;
    public AspectRatioFitter m_ratioToAffect;
    public UnityEvent m_toDoIfNull;
    public void ApplyTexture(Texture texture)
    {
        if (texture is Texture2D)
            ApplyTexture((Texture2D)texture);
        else if (texture is RenderTexture)
            ApplyTexture((RenderTexture)texture);
    }
    public void ApplyTexture(Texture2D texture) {
        if (texture == null) {
            m_toDoIfNull.Invoke();
            return;
        }
        m_imageToAffect.texture = texture;
        m_ratioToAffect.aspectRatio = texture.width / (float)texture.height;
    }
    public void ApplyTexture(RenderTexture texture)
    {
        if (texture == null)
        {
            m_toDoIfNull.Invoke();
            return;
        }
        m_imageToAffect.texture = texture;
        m_ratioToAffect.aspectRatio = texture.width / (float)texture.height;
    }
    public Texture2D GetTextureUsed() {
        if (m_imageToAffect.mainTexture == null)
            return null;
        else return (Texture2D) m_imageToAffect.mainTexture;
    }

    private void Reset()
    {
        m_imageToAffect = GetComponent<RawImage>();
        m_ratioToAffect = GetComponent<AspectRatioFitter>();

    }
}
