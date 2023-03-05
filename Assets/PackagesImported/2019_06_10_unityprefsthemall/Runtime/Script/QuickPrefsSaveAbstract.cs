using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuickPrefsSaveAbstract : MonoBehaviour
{
    public string m_id="";
    public const string keysType = "0123456789ABCDEFGHIJKLMNOPQRSTUVXYZ";

    [Header("Debug")]
    public string m_savedValue;
    public string m_loadedValue;
    public string m_editorValue;
    public static string GenerateId(int lenght=124 ) {
        string key="";
        for (int i = 0; i < lenght; i++)
        {
            key += keysType[UnityEngine.Random.Range(0, keysType.Length)];
        }
        return key;
    }
    protected abstract string GetDataToSave();
    protected abstract void ResetDataWith(string savedInfo);

    public void Save() {
        m_savedValue = GetDataToSave();
        PlayerPrefs.SetString(m_id, m_savedValue);

    }
    public void Load()
    {
        string stored = m_loadedValue = PlayerPrefs.GetString(m_id);
        ResetDataWith(stored);
    }
    public void Load( string valueToLoad)
    {
        
        ResetDataWith(valueToLoad);
    }

    public void ResetToEditorValue() {
        Load(m_editorValue);
    }

    public void SetManualyTheId(string id, bool withReloadCheck = true) {
        m_id = id;
        if(withReloadCheck)
            Load();
    }
    public string GetTheId() {
        return m_id;
    }

    public void OnEnable()
    {
        Load();

    }
    public void OnDisable()
    {
        Save();

    }
    public void OnDestroy()
    {
        Save();
    }

    public void OnApplicationPause(bool pause)
    {
        Save();
    }

    public void Reset()
    {
        CheckThatIdIsDefined();
    }
    public void OnValidate()
    {
        CheckThatIdIsDefined();
        m_editorValue = GetDataToSave();
    }

    private void CheckThatIdIsDefined()
    {
        if (string.IsNullOrEmpty(m_id))
            m_id = GenerateId();
    }

}
public abstract class QuickPrefsSaveBehviourAbstract : QuickPrefsSaveAbstract
{
    protected void Awake()
    {
        FindAndLinkcomponent();
    }

    protected new void OnValidate()
    {
        base.OnValidate();
        FindAndLinkcomponent();
    }
    protected new void Reset()
    {
        base.Reset();
        FindAndLinkcomponent();
    }

    protected abstract void FindAndLinkcomponent();
}
