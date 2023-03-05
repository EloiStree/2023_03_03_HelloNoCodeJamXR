using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnablerMono : MonoBehaviour
{
    [Range(0f,1f)]
    public float m_percentChangeToAppear = 0.1f;
    public Eloi.PrimitiveUnityEvent_Bool m_setOn;
    public GameObject[] m_toActive;

    public bool m_onAwake = true;
    public bool m_onEnable = true;
    public bool m_useStaticChance = true;
    void Awake()
    {
        if (m_onAwake)
        CheckIfNeedToAppear();
    }
    void OnEnable()
    {
        if (m_onEnable)
            CheckIfNeedToAppear();
    }
    public float m_previousValue;
    [ContextMenu("Refresh")]
    private void CheckIfNeedToAppear()
    {
        if (m_useStaticChance)
            RandomEnablerSetFromStatic.GetPercentChance(out m_percentChangeToAppear);
        Eloi.E_UnityRandomUtility.GetRandom_0_1(out float value);
        bool isOn = value < m_percentChangeToAppear;
        m_previousValue = value;
        m_setOn.Invoke(isOn);
        for (int i = 0; i < m_toActive.Length; i++)
        {
            if (m_toActive[i] != null)
                m_toActive[i].SetActive(isOn);
        }

    }

    private void Reset()
    {
        m_toActive = new GameObject[] { this.gameObject };


    }

}
