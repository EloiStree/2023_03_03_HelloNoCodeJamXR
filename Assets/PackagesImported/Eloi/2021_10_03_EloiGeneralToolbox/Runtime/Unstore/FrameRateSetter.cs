using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    public int m_choosedFrameRate;
    void Start()
    {
        SetFrameRateOfTheApp(m_choosedFrameRate);
    }

    public void SetFrameRateOfTheApp(int frame)
    {

        Application.targetFrameRate = frame;
    }
    public void SetFrameRateOfTheApp(string frameAsString)
    {
        try
        {
            SetFrameRateOfTheApp(int.Parse(frameAsString));
        }
        catch (Exception e) { }
    }

}
