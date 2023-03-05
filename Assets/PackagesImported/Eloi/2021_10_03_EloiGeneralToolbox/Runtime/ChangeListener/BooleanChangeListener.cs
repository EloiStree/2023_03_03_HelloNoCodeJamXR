using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class BooleanChangeListener 
{
    [SerializeField] BooleanChangeObserver m_observer= new BooleanChangeObserver();

    public void SetBoolean(in bool value)
    {
        SetBoolean(in value, out bool tmp);
    }
    public void SetBoolean(in bool value, out bool changed)
    {
        m_observer.SetBoolean(in value, out changed);
        if (changed)
        {
            NotifyChangeToChildren(value);
        }
    }
    protected abstract void NotifyChangeToChildren(bool newValue);

    public void GetBoolean(out bool value) => m_observer.GetBoolean(out value);
    public bool GetBoolean()
    {
        return m_observer.GetBoolean();
    }

}


[System.Serializable]
public class DefaultBooleanChangeListener : BooleanChangeListener
{
    public Eloi.PrimitiveUnityEvent_Bool m_onChanged;
    public BooleanChanged m_onChangedDelegate;
    public delegate void BooleanChanged(bool newValue);
    protected override void NotifyChangeToChildren(bool newValue)
    {
        m_onChanged.Invoke(newValue);
        if (m_onChangedDelegate != null)
            m_onChangedDelegate(newValue);
    }
}
[System.Serializable]
public class DefaultOnOffBooleanChangeListener : BooleanChangeListener
{
    public Eloi.PrimitiveUnityEvent_Bool m_onChanged;
    public BooleanChanged m_onChangedDelegate;
    public UnityEvent  m_onChangedTrue;
    public UnityEvent m_onChangedFalse;
    public delegate void BooleanChanged(bool newValue);
    protected override void NotifyChangeToChildren(bool newValue)
    {
        m_onChanged.Invoke(newValue);
        if (m_onChangedDelegate != null)
            m_onChangedDelegate(newValue);
        if (newValue)
            m_onChangedTrue.Invoke();
        else
            m_onChangedFalse.Invoke();
    }
}
[System.Serializable]
public class DelegateChangeListener : BooleanChangeListener
{
    BooleanChanged m_onChangedDelegate;
    public delegate void BooleanChanged(bool newValue);
    protected override void NotifyChangeToChildren(bool newValue)
    {
        if (m_onChangedDelegate != null)
            m_onChangedDelegate(newValue);
    }
    public void AddListener(BooleanChanged listener) { m_onChangedDelegate += listener; }
    public void RemoveListener(BooleanChanged listener) { m_onChangedDelegate -= listener; }
}

[System.Serializable]
public class BooleanChangeObserver {

    [SerializeField] bool m_booleanState;
    public void SetBoolean(in bool value, out bool changed) {
        changed = value != m_booleanState;
        m_booleanState = value;
    }
    public void GetBoolean(out bool value) => value = m_booleanState;
    public bool GetBoolean() { 
    return  m_booleanState;
    }
}


