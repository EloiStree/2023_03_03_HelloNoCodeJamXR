using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractTexture2DAsScreenshotImageMono : AbstractExctractVuforiaImageMono
{

    
    public int m_scaleCapture = 2;
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
        Texture2D t = ScreenCapture.CaptureScreenshotAsTexture(m_scaleCapture);
        m_disableUI.Invoke(false);
        texture =  t;
    }
    public override IEnumerator FetchCoroutine(Texture2D  texture)
    {
        m_disableUI.Invoke(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        texture =  ScreenCapture.CaptureScreenshotAsTexture(m_scaleCapture);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        m_disableUI.Invoke(false);
       
    }
}

public abstract class AbstractExctractVuforiaImageMono : MonoBehaviour {

    public abstract void Fetch(out Texture2D texture);
    public abstract IEnumerator FetchCoroutine(Texture2D textureFetch);

    public abstract Texture2D GetLastFetch();
}