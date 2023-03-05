using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI2Display_ActivateGameObjectsMirror : AbstractUI2Display
{
    public bool m_isDisplaying;
    public GameObject[] toMirrorDisplayValue;
    public GameObject[] toMirrorInverseDisplayValue;

    public override void IsDisplaying(out bool isDisplaying)
    {
        isDisplaying = m_isDisplaying;
    }

    public override void SetDisplayOn(bool setAsDisplaying)
    {
      //  Eloi.E_DebugLog.C("Disable All Start");
        Eloi.E_GeneralUtility.SetAllActive(ref toMirrorDisplayValue, setAsDisplaying);
        Eloi.E_GeneralUtility.SetAllActive(ref toMirrorInverseDisplayValue, !setAsDisplaying);
        m_isDisplaying = setAsDisplaying;
       // Eloi.E_DebugLog.D("Disable All End");
    }

    private void Reset()
    {
        toMirrorDisplayValue = new GameObject[] { this.gameObject };
    }
}
