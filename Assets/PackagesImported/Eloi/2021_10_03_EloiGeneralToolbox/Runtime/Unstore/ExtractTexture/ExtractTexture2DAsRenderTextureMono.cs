using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractTexture2DAsRenderTextureMono : AbstractExctractVuforiaImageMono
{
    public RenderTexture m_target;

    public Eloi.PrimitiveUnityEventExtra_Bool m_disableUI;

    [Header("Debug")]
    public Texture2D m_imageExtract;

    public override Texture2D GetLastFetch()
    {
        return m_imageExtract;
    }
    [ContextMenu("Fetch")]
    public void Fetch()
    {
        Fetch(out m_imageExtract);
    }


    public override void Fetch(out Texture2D texture)
    {
        m_disableUI.Invoke(true);
        Eloi.E_Texture2DUtility.RenderTextureToTexture2D(in m_target, out texture);
       
        m_disableUI.Invoke(false); 
        m_imageExtract = texture;
    }
    public override IEnumerator FetchCoroutine(Texture2D texture)
    {
        m_disableUI.Invoke(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Eloi.E_Texture2DUtility.RenderTextureToTexture2D(in m_target, out texture);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        m_disableUI.Invoke(false);
        m_imageExtract = texture;
    }

}

