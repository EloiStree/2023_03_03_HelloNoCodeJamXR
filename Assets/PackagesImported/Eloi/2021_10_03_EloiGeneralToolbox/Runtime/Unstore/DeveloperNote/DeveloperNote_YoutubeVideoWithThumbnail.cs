using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeveloperNote_YoutubeVideoWithThumbnail : DeveloperNote_B64ImageFromURL
{
    public string m_youtubeVideoId;
     string m_previousYoutubeVideoId;
    public ThumbnailType m_thumbnailType= ThumbnailType.SdDefault;
    public enum ThumbnailType { Default,
        HqDefault,
        MqDefault,
        SdDefault,
        MaxResDefault, 
        _0, _1, _2, _3
    }
    

    [ContextMenu("Open Youtube page")]
    public void OpenYoutube() {
        Application.OpenURL("https://www.youtube.com/watch?v="+m_youtubeVideoId);
    }

    [ContextMenu("Download Thumbnail")]
    public void DownloadImageFrom() {

        CheckForIdInGivenText();

        //Source:https://stackoverflow.com/questions/2068344/how-do-i-get-a-youtube-video-thumbnail-from-the-youtube-api
        string url = "https://img.youtube.com/vi/" + m_youtubeVideoId + "/default.jpg";
        switch (m_thumbnailType)
        {
            case ThumbnailType.Default:
                url=("https://img.youtube.com/vi/" + m_youtubeVideoId + "/default.jpg"); break;
            case ThumbnailType.HqDefault:
                url = ("https://img.youtube.com/vi/" + m_youtubeVideoId + "/hqdefault.jpg"); break;
            case ThumbnailType.MqDefault:
                url = ("https://img.youtube.com/vi/" + m_youtubeVideoId + "/mqdefault.jpg"); break;
            case ThumbnailType.SdDefault:
                url = ("https://img.youtube.com/vi/" + m_youtubeVideoId + "/sddefault.jpg"); break;
            case ThumbnailType.MaxResDefault:
                url = ("https://img.youtube.com/vi/" + m_youtubeVideoId + "/maxresdefault.jpg");
                break;
            case ThumbnailType._0:
                url = ("https://img.youtube.com/vi/" + m_youtubeVideoId + "/0.jpg");
                break;
            case ThumbnailType._1:
                url = ("https://img.youtube.com/vi/" + m_youtubeVideoId + "/1.jpg");
                break;
            case ThumbnailType._2:
                url = ("https://img.youtube.com/vi/" + m_youtubeVideoId + "/2.jpg");
                break;
            case ThumbnailType._3:
                url = ("https://img.youtube.com/vi/" + m_youtubeVideoId + "/3.jpg");
                break;
            default:
                break;
        }
        base.m_imageUrl = url;
        SetWithURL(url);
    }
    protected override void OnValidate()
    {
        base.OnValidate();
        CheckForIdInGivenText();
        if (!m_youtubeVideoId .Equals(m_previousYoutubeVideoId)) {
            m_previousYoutubeVideoId = m_youtubeVideoId;
            DownloadImageFrom();
        }

    }
    
    private void CheckForIdInGivenText()
    {
        //https://www.youtube.com/watch?v=dQw4w9WgXcQ
        if (m_youtubeVideoId.IndexOf("youtube.com/watch?v=") > -1)
        {
            int startIndex = m_youtubeVideoId.LastIndexOf("v=");
            m_youtubeVideoId = m_youtubeVideoId.Substring(startIndex + 2);

            RemoveLastPart();

        }
        //https://youtu.be/dQw4w9WgXcQ
        if (m_youtubeVideoId.IndexOf("youtu.be/") > -1)
        {
            int startIndex = m_youtubeVideoId.LastIndexOf("/");
            m_youtubeVideoId = m_youtubeVideoId.Substring(startIndex + 1);
            RemoveLastPart();
        }
    }

    private void RemoveLastPart()
    {
        int andIndex = m_youtubeVideoId.LastIndexOf("&");
        if (andIndex > 0)
            m_youtubeVideoId = m_youtubeVideoId.Substring(0, andIndex);
        andIndex = m_youtubeVideoId.LastIndexOf("?");
        if (andIndex > 0)
            m_youtubeVideoId = m_youtubeVideoId.Substring(0, andIndex);
    }
}

