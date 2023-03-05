using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PageCyclingSwitcher : MonoBehaviour
{

    public GameObject[] m_keyboards;
    public int m_index;


    [ContextMenu("Next")]
    public void Next() {

        m_index++;
        if (m_index >= m_keyboards.Length)
            m_index = 0;
        SetAt(m_index);
    }

    [ContextMenu("Previous")]
    public void Previous() {

        m_index--;
        if (m_index < 0) {
            m_index = m_keyboards.Length-1; 
        }
        SetAt(m_index);
    }

    private void SetAt(int index)
    {
        for (int i = 0; i < m_keyboards.Length; i++)
        {
            bool isOn = index == i;
            if (m_keyboards != null)
                m_keyboards[i].SetActive(isOn);
        }
    }
}
