using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI2Display_ActivateGameobjectsComplete : AbstractUI2Display
{
    public bool m_isDisplaying;
    public GameObject[] toMirrorDisplayValue;
    public GameObject[] toMirrorInverseDisplayValue;
    public GameObject[] toActivateOnDisplay;
    public GameObject[] toActivateOnHide;

    public override void IsDisplaying(out bool isDisplaying)
    {
        isDisplaying = m_isDisplaying;
    }

    public override void SetDisplayOn(bool setAsDisplaying)
    {
        if(setAsDisplaying)
            Eloi.E_GeneralUtility.SetAllActive(ref toActivateOnDisplay);
        else
            Eloi.E_GeneralUtility.SetAllDisable(ref toActivateOnHide);


        Eloi.E_GeneralUtility.SetAllActive(ref toMirrorDisplayValue, setAsDisplaying);
        Eloi.E_GeneralUtility.SetAllActive(ref toMirrorInverseDisplayValue,! setAsDisplaying);


    }

    private void Reset()
    {
        toMirrorDisplayValue = new GameObject[] { this.gameObject };
    }
}
