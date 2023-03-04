using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PechaKuchaLogicMono : MonoBehaviour
{

    public Material m_materialToAffect;

    public Texture2D m_defaultTexture;
    public Texture2D m_ifNullTexture;
    public string m_textureName= "_BaseMap";

    public Slide[] m_20x20_Slide = new Slide[20];
    public float m_timeBetweenSlide=20f;

    [Header("Debug don't touch")]
    public int m_slideIndexToDisplay;
    public float m_timeLeftBeforeNextSlide=20;
    public bool m_isPlaying = false;

    public PauseSwitchChangeEvent m_slidePauseStateChanged;
    public TimeLeftChangeEvent m_timeLeftInSecondChanged;
    public TimeLeftChangeEvent m_timeLeftInPercentChanged;
    public SlideChangeEvent m_onSlideChanged;

    public SlideIndexChangeEvent m_onSlideIndexChanged;
    [System.Serializable]
    public class PauseSwitchChangeEvent : UnityEvent<bool> { };
    [System.Serializable]
    public class SlideIndexChangeEvent : UnityEvent<int> { };
    [System.Serializable]
    public class TimeLeftChangeEvent : UnityEvent<float> { };
    [System.Serializable]
    public class SlideChangeEvent : UnityEvent<Texture2D> { };



    [System.Serializable]
    public class Slide {
        public Texture2D m_slide;
    }

    void Start()
    {
        m_isPlaying = true;
        m_timeLeftBeforeNextSlide = m_timeBetweenSlide;
        SetWithIndex(0);
        SetDisplayTextureWithDefault();
    }

    private void SetDisplayTexture(Texture2D texture)
    {
        m_materialToAffect.SetTexture(m_textureName, texture);
        m_onSlideChanged.Invoke(texture);
    }

    public void SetWithIndex(int index) {
        m_slideIndexToDisplay = index;

        if (m_slideIndexToDisplay < 0 || m_slideIndexToDisplay > m_20x20_Slide.Length-1)
        {
            SetDisplayTextureWithDefault();
            if (m_slideIndexToDisplay > m_20x20_Slide.Length - 1)
                m_slideIndexToDisplay = m_20x20_Slide.Length - 1;
            if (m_slideIndexToDisplay < 0)
                m_slideIndexToDisplay = 0;
        }
        else { 

            if (m_20x20_Slide[m_slideIndexToDisplay].m_slide == null)
                SetDisplayTexture(m_ifNullTexture);
            else 
                SetDisplayTexture(m_20x20_Slide[m_slideIndexToDisplay].m_slide);
        }
        m_onSlideIndexChanged.Invoke(m_slideIndexToDisplay);
    }

    [ContextMenu("Previous")]
    public void Previous()
    {
        m_slideIndexToDisplay -= 1;
        m_timeLeftBeforeNextSlide = m_timeBetweenSlide;
        SetWithIndex(m_slideIndexToDisplay);


    }
    [ContextMenu("Next")]
    public void Next()
    {
        int previous = m_slideIndexToDisplay;


        m_slideIndexToDisplay += 1;
        m_timeLeftBeforeNextSlide = m_timeBetweenSlide;

        if (previous == m_20x20_Slide.Length - 2 && m_slideIndexToDisplay == m_20x20_Slide.Length - 1) {
            Stop();
        }
        SetWithIndex(m_slideIndexToDisplay);
    }
    [ContextMenu("Reset To Zero and stop")]

    public void ResetToZeroAndStop()
    {
        SetWithIndex(0);
        Stop();
    }
    [ContextMenu("RestartAndPlay")]

    public void RestartAndPlay()
    {
        SetWithIndex(0);
        Play();
    }

    [ContextMenu("Play")]
    public void Play() => SetAsPlaying(true);

    [ContextMenu("Stop")]
    public void Stop() => SetAsPlaying(false);


    public void SetAsPlaying(bool isPlaying)
    {

        m_isPlaying = isPlaying;
        m_slidePauseStateChanged.Invoke(m_isPlaying);
    }

    [ContextMenu("Switch pause state")]
    public void SwitchPauseState()
    {

        SetAsPlaying( !m_isPlaying);
    }



    private void SetDisplayTextureWithDefault()
    {
        SetDisplayTexture(m_defaultTexture);
    }

    private void Update()
    {
        if (!m_isPlaying)
            return;

        float timePasted = Time.deltaTime;
        m_timeLeftBeforeNextSlide -= timePasted;
        if (m_timeLeftBeforeNextSlide < 0f) {
            Next();
            m_timeLeftBeforeNextSlide = m_timeBetweenSlide;
        }

        if (m_timeLeftBeforeNextSlide < 0) {
            m_timeLeftBeforeNextSlide = 0;
        }
        m_timeLeftInSecondChanged.Invoke(m_timeLeftBeforeNextSlide);
        m_timeLeftInPercentChanged.Invoke(m_timeLeftBeforeNextSlide / m_timeBetweenSlide);
    }
}
