using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGlobalGameVolumeMono : MonoBehaviour
{
    [Range(0f,1f)]
    public float m_volume = 1;
    public bool m_usePlayerPref;
    public void SetSoundTo(float volumeInPourcent)
    {
        m_volume = volumeInPourcent;
        AudioListener.volume = volumeInPourcent;
    }
    public void OnValidate()
    {
        if(Application.isEditor && Application.isPlaying)
         AudioListener.volume= m_volume;
    }

    public void Start()
    {
        if(m_usePlayerPref)
            LoadVolumePref();
    }
    public void OnEnable()
    {
        if (m_usePlayerPref)
            LoadVolumePref();
    }
    public void OnDisable()
    {
        if (m_usePlayerPref)
            SaveVolumePref();
    }
    public void OnDestroy()
    {
        if (m_usePlayerPref)
            SaveVolumePref();
    }

    private void LoadVolumePref()
    {
        float volume = PlayerPrefs.GetFloat("PlayerGameVolume");
        SetSoundTo(volume);
    }


    private void SaveVolumePref()
    {
        PlayerPrefs.SetFloat("PlayerGameVolume", AudioListener.volume);
    }
}
