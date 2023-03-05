using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeveloperNote_YoutubeVideo : DeveloperNoteMono
{
    public string m_youtubeVideoId;
    public ThumbnailType m_thumbnailType= ThumbnailType.Default;
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

    protected override void OnValidate()
    {
        base.OnValidate();
        CheckForIdInGivenText();
    }
    private void CheckForIdInGivenText()
    {
        if (m_youtubeVideoId == null || m_youtubeVideoId.Length <= 0)
            return;

        //https://www.youtube.com/watch?v=dQw4w9WgXcQ
        if (m_youtubeVideoId.IndexOf("youtube.com/watch?v=") > -1)
        {
            int startIndex = m_youtubeVideoId.LastIndexOf("v=");
            m_youtubeVideoId = m_youtubeVideoId.Substring(startIndex + 2);
        }
        //https://youtu.be/dQw4w9WgXcQ
        if (m_youtubeVideoId.IndexOf("youtu.be/") > -1) {
            int startIndex = m_youtubeVideoId.LastIndexOf("/");
            m_youtubeVideoId = m_youtubeVideoId.Substring(startIndex + 1);
        }
    }
}
