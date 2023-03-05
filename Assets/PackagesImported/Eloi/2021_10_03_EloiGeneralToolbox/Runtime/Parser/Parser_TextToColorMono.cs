using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser_TextToColorMono : MonoBehaviour
{
    public Eloi.ClassicUnityEvent_Color m_colorFound;
    public void TryToPushTextAsColor(string text)
    {
        float r = 0, g = 0, b = 0, a = 0;
        string[] tokens = text.Split(':');
        if (tokens.Length == 4)
        {
            if (float.TryParse(tokens[0], out r)
                && float.TryParse(tokens[1], out g)
                && float.TryParse(tokens[2], out b)
                && float.TryParse(tokens[3], out a))
            {

                if (r > 1f || g > 1f || b > 1f || a > 1f)
                {
                    r /= 255f;
                    g /= 255f;
                    b /= 255f;
                    a /= 255f;
                }
                Color c = new Color(r, g, b, a);
                m_colorFound.Invoke(c);
                return;
            }
        }
         if (tokens.Length == 3)
        {
            if (float.TryParse(tokens[0], out r)
                && float.TryParse(tokens[1], out g)
                && float.TryParse(tokens[2], out b))
            {

                if (r > 1f || g > 1f || b > 1f )
                {
                    r /= 255f;
                    g /= 255f;
                    b /= 255f;
                }
                Color c = new Color(r, g, b, 1f);
                m_colorFound.Invoke(c);
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
