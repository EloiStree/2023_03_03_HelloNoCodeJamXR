using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRawImagePlus : MonoBehaviour
{
    public RawImage m_target;


    public void SetTransparent(float transparenceInPourcent)
    {
        Color c = m_target.color;
        c.a = transparenceInPourcent;
        m_target.color = c;
    }
    public void SetOpacity(float opacityInPourcent)
    {
        Color c = m_target.color;
        c.a = 1f - opacityInPourcent;
        m_target.color = c;
    }

    private void Reset()
    {
        m_target = GetComponent<RawImage>();
    }
}
