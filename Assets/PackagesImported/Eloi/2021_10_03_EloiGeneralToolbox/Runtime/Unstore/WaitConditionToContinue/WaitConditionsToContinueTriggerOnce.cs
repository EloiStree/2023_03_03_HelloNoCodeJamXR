using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WaitConditionsToContinueTriggerOnce : MonoBehaviour
{

    public bool m_useTrimp = true;
    public bool m_useLowerCase = true;
    public Eloi.E_BooleanUtility.BoolConditionToCheck m_boolType;


    public bool m_triggered;
    public UnityEvent m_toDoWhenReady;

    public bool m_useUpdateCheck;
    public bool m_checkAtChanged=true;
    public void Update()
    {
        if (!m_useUpdateCheck)
            return;
        CheckConditionAndPushIfNeeded();
    }

    public void CheckConditionAndPushIfNeeded()
    {
        if (m_triggered)
            return;

            if (Eloi.E_BooleanUtility.IsConditionTrue(m_boolType, m_conditions.Select(k => k.m_isReady)))
            {
                TriggerAsChecked();
            }
    }

    private void TriggerAsChecked()
    {
        m_triggered = true;
        m_toDoWhenReady.Invoke();
    }

    public void SetKeyAsTrue(string keyName)
    {
        SetKeyAsTrue(keyName, true);
    }
    public void SetKeyAsTrue(string keyName, bool isReady)
    {
        for (int i = 0; i < m_conditions.Length; i++)
        {
            if (Eloi.E_StringUtility.AreEquals(in keyName, in m_conditions[i].m_keyName, in m_useTrimp, in m_useLowerCase))
            {

                m_conditions[i].m_isReady = isReady;
            }
        }
        if (m_checkAtChanged)
            CheckConditionAndPushIfNeeded();
    }
    public void SetKeyAsFalse(string keyName)
    {
        SetKeyAsTrue(keyName, false);
    }
   

    public KeyCondition[] m_conditions;


    [System.Serializable]
    public class KeyCondition
    {
        public string m_keyName;
        public bool m_isReady;
    }

}