using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditAnchorTagMono : MonoBehaviour
{
    public Eloi.PrimitiveUnityEventExtra_Bool m_onDisplayRequest;
    public void Display()
    {
        m_onDisplayRequest.Invoke(true);
    }

    public void Hide()
    {
        m_onDisplayRequest.Invoke(false);
    }
}
