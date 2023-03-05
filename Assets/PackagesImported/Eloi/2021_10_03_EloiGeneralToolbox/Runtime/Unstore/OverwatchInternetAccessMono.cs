using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OverwatchInternetAccessMono : MonoBehaviour
{
    public string m_url= "https://docs.github.com/en";
    public float m_timeBetweenCheck = 2;
    public bool m_hasInternet;
    public string m_lastCheck;
    [TextArea(0,10)]
    public string m_textFound;
    [TextArea(0, 10)]
    public string m_textError;
    public Eloi.PrimitiveUnityEventExtra_Bool m_onInternetAccessChanged;
    void Start()
    {
        StartCoroutine(CheckInternetIsThere());
    }

    IEnumerator CheckInternetIsThere()
    {
        while (true)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(m_url))
            {
                bool previousState = m_hasInternet;
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:

                        m_hasInternet = false;
                        m_textFound = "";
                        m_textError = ("Error: " + webRequest.error);
                        if (previousState)
                            m_onInternetAccessChanged.Invoke(false);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        m_hasInternet = false;
                        m_textFound = "";
                        m_textError = ( "HTTP Error: " + webRequest.error);
                        if (previousState)
                            m_onInternetAccessChanged.Invoke(false);
                        break;
                    case UnityWebRequest.Result.Success:
                        m_hasInternet = true;
                        m_textFound = ( "Received: " + webRequest.downloadHandler.text);
                        m_textError = "";
                        if (!previousState)
                            m_onInternetAccessChanged.Invoke(true);
                        break;
                }
                m_lastCheck = DateTime.Now.ToString();

                yield return new WaitForSeconds(m_timeBetweenCheck);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
