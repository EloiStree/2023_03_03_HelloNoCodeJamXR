using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractTexture2DFromCameraImageMono : AbstractExctractVuforiaImageMono
{

    public Camera m_target;

    [Header("Debug")]
    public Texture2D m_imageExtract;
    
    [ContextMenu("Fetch")]
    public void Fetch()
    {
        m_imageExtract = GetTextureFromCamera(m_target);
    }
    public override void Fetch(out Texture2D received)
    {
        m_imageExtract = GetTextureFromCamera(m_target);
        received = m_imageExtract;
    }
    public override IEnumerator FetchCoroutine(Texture2D textureFetch)
    {
        Fetch(out textureFetch);
        yield return null;
    }
    private static Texture2D GetTextureFromCamera(Camera mCamera)
    {
        RenderTexture previousRenderer;
        Rect rect = new Rect(0, 0, mCamera.pixelWidth, mCamera.pixelHeight);
        RenderTexture renderTexture = new RenderTexture(mCamera.pixelWidth, mCamera.pixelHeight, 24);
        Texture2D screenShot = new Texture2D(mCamera.pixelWidth, mCamera.pixelHeight, TextureFormat.RGBA32, false);

        previousRenderer = mCamera.targetTexture;
        mCamera.targetTexture = renderTexture;
        mCamera.Render();

        RenderTexture.active = renderTexture;

        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();


        mCamera.targetTexture= previousRenderer;
        RenderTexture.active = null;
        return screenShot;
    }
    public override Texture2D GetLastFetch()
    {
        return m_imageExtract;
    }

}
