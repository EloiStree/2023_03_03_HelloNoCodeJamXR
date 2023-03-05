using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Eloi
{
    public static class E_DownloadImage 
    {
        public static void TryToLoadImageFromDataOrURI_Direct(string url, out Texture2D image)
        {
            image = null;
            url = url.Trim();
            if (E_Base64ToImage.IsDataBased(url))
            {
                E_Base64ToImage.TryBase64StringToImage(url, out bool converted, out image);
                return;
            }
            if (File.Exists(url)) {
                if (E_StringUtility.EndWith(url, ".png") || E_StringUtility.EndWith(url, ".jpg") || E_StringUtility.EndWith(url, ".jpeg"))
                {
                    byte[] bytes = File.ReadAllBytes(url);
                    image = new Texture2D(2, 2, TextureFormat.ARGB32, true);
                    image.LoadImage(bytes);
                    return;
                }
                else {
                    string fileContent = File.ReadAllText(url);
                    if (E_Base64ToImage.IsDataBased(fileContent))
                    {
                        E_Base64ToImage.TryBase64StringToImage(fileContent, out bool converted, out image);
                        return;
                    }
                }
            }

            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    byte[] bytes = webClient.DownloadData(url);
                    image = new Texture2D(2, 2, TextureFormat.ARGB32, true);
                    image.LoadImage(bytes);
                    return;
                }
                catch (Exception ) {}

                try
                {
                    string text = webClient.DownloadString(url);
                    if (E_Base64ToImage.IsDataBased(text))
                    {
                        E_Base64ToImage.TryBase64StringToImage(text, out bool converted, out image);
                        return;
                    }
                }
                catch (Exception) { }
        }
        }
        

        public static IEnumerator TryToLoadImageFromDataOrURI_Coroutine(string dataOrUri, ImageLoaderCallback downloadInfo)
        {
            dataOrUri = dataOrUri.Trim();

            if (dataOrUri == null || dataOrUri.Length <= 0)
            {
                downloadInfo.m_pathOrUrlUsed = "";
                downloadInfo.SetAsNotDownloaded("No uri given.");
                downloadInfo.NotifyWhatWasDownloaded();
                yield break;
            }

            if (E_Base64ToImage.IsDataBased(dataOrUri))
            {
                E_Base64ToImage.TryBase64StringToImage(dataOrUri, out bool converted, out Texture2D img);
                downloadInfo.m_downloaded = img;
                if (img != null)
                {
                    downloadInfo.SetAsDownloaded(img);
                    downloadInfo.NotifyWhatWasDownloaded();
                    yield break;
                }
                else
                {
                    downloadInfo.SetAsNotDownloaded("Did not convert the image as base64 but is base64");
                    downloadInfo.NotifyWhatWasDownloaded();
                    yield break;
                }
            }


            downloadInfo.m_pathOrUrlUsed = dataOrUri;
            if (File.Exists(dataOrUri))
                dataOrUri = "file:///" + dataOrUri;
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(dataOrUri))
            {
                yield return uwr.SendWebRequest();

                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    downloadInfo.SetAsNotDownloaded(uwr.error);
                    downloadInfo.NotifyWhatWasDownloaded();
                }
                else
                {
                    string text = uwr.downloadHandler.text;
                    if (E_Base64ToImage.IsDataBased(text))
                    {
                        E_Base64ToImage.TryBase64StringToImage(text, out bool converted, out Texture2D img);
                        downloadInfo.m_downloaded = img;
                        if (img != null)
                        {
                            downloadInfo.SetAsDownloaded(img);
                            downloadInfo.NotifyWhatWasDownloaded();
                            yield break;
                        }
                        else
                        {
                            downloadInfo.SetAsNotDownloaded("Did not convert the image as base64 but is base64");
                            downloadInfo.NotifyWhatWasDownloaded();
                            yield break;
                        }
                    }

                    downloadInfo.SetAsDownloaded(DownloadHandlerTexture.GetContent(uwr));
                    downloadInfo.NotifyWhatWasDownloaded();
                    yield break;
                }
            }
        }
    }


    [System.Serializable]
    public class ImageLoaderCallback
    {
        public string m_pathOrUrlUsed;
        public bool m_finishDownloading;
        public Texture2D m_downloaded;
        public string m_error;

        public void SetAsNotDownloaded(string error)
        {
            m_finishDownloading = true;
            m_error = error;
            NotifyWhatWasDownloaded();
        }

        public bool HadError()
        {
            return m_error != null && m_error.Length > 0;
        }

        public void SetAsDownloaded(Texture2D texture)
        {
            m_finishDownloading = true;
            m_downloaded = texture;
            NotifyWhatWasDownloaded();
        }


        internal void NotifyWhatWasDownloaded()
        {
            if (m_toDoWhenDownloaded != null )
                m_toDoWhenDownloaded(this);
        }

        public CallBack m_toDoWhenDownloaded;
        public delegate void CallBack(ImageLoaderCallback info);
    }


}
