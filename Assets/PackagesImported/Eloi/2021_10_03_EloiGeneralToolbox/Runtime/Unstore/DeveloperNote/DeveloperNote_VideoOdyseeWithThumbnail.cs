using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DeveloperNote_VideoOdyseeWithThumbnail : DeveloperNote_B64ImageFromURL
{
    public string m_odyseeUrl;
    string m_previousOdyseeUrl;

    protected override void OnValidate()
    {
        base.OnValidate();
        

    }

    public string GetUrl( string thumbnailUrl,int quality, int width=0, int height=0)
    {
        Eloi.E_CodeTag.NeedHelp.DontKnowHowToCodeThat("I don't know how to code this part");
        //Source: https://github.com/OdyseeTeam/odysee-android/blob/042fc4daff8a60a4430e06c7b83ad6fff7b2bf56/app/src/main/java/com/odysee/app/model/Claim.java#L555
        if (width != 0 && height != 0)
        {
            return  string.Format("https://thumbnails.odysee.com/optimize/s:{0}:{1}/quality:{2}/plain/{3}", width, height, quality, thumbnailUrl);
        }
        return string.Format("https://thumbnails.odysee.com/optimize/quality:{0}/plain/{1}",  quality, thumbnailUrl);
    }
}
