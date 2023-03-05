using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUI2Display : MonoBehaviour
{
    [ContextMenu("Display")]
    public void SetToDisplay() => SetDisplayOn(true);
    [ContextMenu("Hide")]
    public void SetToHide() => SetDisplayOn(false);
    [ContextMenu("Switch")]
    public void SwitchState(){
        IsDisplaying(out bool state);
        SetDisplayOn(!state);
    }
    public abstract void SetDisplayOn(bool setAsDisplaying);
    public abstract void IsDisplaying(out bool isDisplaying);
    public bool IsDisplaying()
    {
        IsDisplaying(out bool isDisplaying);
        return isDisplaying;
    }

}