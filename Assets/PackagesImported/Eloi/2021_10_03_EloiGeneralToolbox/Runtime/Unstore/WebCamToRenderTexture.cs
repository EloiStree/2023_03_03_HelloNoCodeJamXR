using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WebCamToRenderTexture : MonoBehaviour
{
	public int m_wantedWebcamIndexAtStart;
	public RenderTexture m_debugRenderTexture;
	public int m_preferWidth = 1920, m_preferHeight = 1080, m_preferFPS = 30;

	[Header("Push Out Listener")]
	public Eloi.ClassicUnityEvent_Texture2D m_texturePushOut;
	public Eloi.ClassicUnityEvent_RenderTexture m_textureRenderPushOut;

   

    [Header("Editor")]
	public string[] m_webcamAvailable;

	[Header("Debug")]
	public int m_initialWebcamIndex;
	public RenderTexture m_reusedRendererPushedContainer;
	public Texture2D m_texturedPushed;
	public WebCamTexture m_webcamTextureUsed;
	public int m_widthUsed;
	public int m_heightUsed;


	[ContextMenu("Refresh webcam")]
	public void RefreshWebcamList() {
		m_webcamAvailable = WebCamTexture.devices.Select(K => K.name ).ToArray();
	}

	void Start()
	{
		m_initialWebcamIndex = m_wantedWebcamIndexAtStart;
		SetWebCamTexture(m_wantedWebcamIndexAtStart);
	}

	void Update()
	{
		if (m_wantedWebcamIndexAtStart != m_initialWebcamIndex)
		{
			SetWebCamTexture(m_wantedWebcamIndexAtStart);
		}
		Graphics.Blit(m_webcamTextureUsed, m_debugRenderTexture);

		m_initialWebcamIndex = m_wantedWebcamIndexAtStart;
	}

	void SetWebCamTexture(int index)
	{
		if (m_webcamTextureUsed != null && m_webcamTextureUsed.isPlaying)
			m_webcamTextureUsed.Stop();
		WebCamDevice[] devices = WebCamTexture.devices;
		try
		{
			m_webcamTextureUsed = new WebCamTexture(devices[index].name, this.m_preferWidth, this.m_preferHeight, this.m_preferFPS);
		}
		catch (System.Exception e)
		{
			m_webcamTextureUsed = new WebCamTexture(devices[0].name, this.m_preferWidth, this.m_preferHeight, this.m_preferFPS);
		}
		m_webcamTextureUsed.Play();
	}

	public void SetResolution(int w, int h)
	{
		m_preferWidth = w;
		m_preferHeight = h;
	}


	[ContextMenu("Push Texture out")]
	public void PushOutTexture()
	{
		Texture2D t = GetTexture2DFromWebcamTexture(m_webcamTextureUsed);
		m_texturePushOut.Invoke(t);
		if (m_reusedRendererPushedContainer == null) { 
			RenderTexture rt = new RenderTexture(t.width, t.height,0, RenderTextureFormat.ARGB32);
			rt.enableRandomWrite = true;
			rt.Create();
			m_reusedRendererPushedContainer = rt;
		}
		Graphics.Blit(t, m_reusedRendererPushedContainer);
		//Graphics.CopyTexture(webcamTexture, rt);
		m_textureRenderPushOut.Invoke(m_reusedRendererPushedContainer);
	}
	public Texture2D GetTexture2DFromWebcamTexture(WebCamTexture webCamTexture)
	{

		m_widthUsed = webCamTexture.width;
		m_heightUsed = webCamTexture.height;
		// Create new texture2d
		if(m_texturedPushed==null)
			m_texturedPushed = new Texture2D(webCamTexture.width, webCamTexture.height);
		// Gets all color data from web cam texture and then Sets that color data in texture2d
		m_texturedPushed.SetPixels(webCamTexture.GetPixels());
		// Applying new changes to texture2d
		m_texturedPushed.Apply();
		return m_texturedPushed;
	}
	public Texture2D GetTexture2DFromWebcamTexture()
	{
		return GetTexture2DFromWebcamTexture(m_webcamTextureUsed);
	}
	void CreateRenderTxture(ref RenderTexture rt, int w, int h)
	{
		rt = new RenderTexture(w, h, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
		rt.enableRandomWrite = true;
		rt.Create();
	}

	void Create2DTexture(ref Texture2D tx, int w, int h)
	{
		tx = new Texture2D(w, h, TextureFormat.ARGB32, false);
		tx.Apply();
	}


}