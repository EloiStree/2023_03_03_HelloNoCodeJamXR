using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI2Display_ThroughUnityEvent : AbstractUI2Display
{

    public bool m_isDisplaying;
    public UnityEvent m_onDisplay;
    public UnityEvent m_onHide;

    public override void IsDisplaying(out bool isDisplaying)
    {
      isDisplaying=  m_isDisplaying;
    }

    public override void SetDisplayOn(bool setAsDisplaying)
    {
        m_isDisplaying = setAsDisplaying;
        if (m_isDisplaying)
        {
            m_onDisplay.Invoke();
        }
        else
        {
            m_onHide.Invoke();
        }
    }
    

}
