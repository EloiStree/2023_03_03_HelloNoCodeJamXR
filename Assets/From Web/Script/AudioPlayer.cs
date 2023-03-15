using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class AudioPlayer : MonoBehaviour
{
    //public Slider audioSlider;
    public AudioSource audioSource;

    [HideInInspector]
    public AudioClip audioClip;

    //public TMP_Text ConsoleText;
    //public Image PlayImage, PauseImage;
    public Eloi.PrimitiveUnityEvent_Bool m_isPlayingChanged;
    public Eloi.PrimitiveUnityEvent_Bool m_isPausedChanged;
    public Eloi.PrimitiveUnityEvent_String m_onConsoleChanged;

    private bool isPaused = false;
    [Range(0,1f)]
    public float m_audioStatePercent;

    private void Start()
    {
        isPaused = false;

        IsPlaying(false);
    }

    private void IsPlaying(bool isPlaying)
    {
        m_isPlayingChanged.Invoke(!isPlaying);
        m_isPausedChanged.Invoke(isPlaying);
    }

    public void UpdateClip()
    {
        audioSource.clip = audioClip;

        //audioSlider.direction = Slider.Direction.LeftToRight;
        //audioSlider.minValue = 0;
        //audioSlider.maxValue = audioSource.clip.length;
    }

    public void PlayPauseAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            IsPlaying(false);
            isPaused = true;
        }
        else if (isPaused)
        {
            IsPlaying(true);
            audioSource.UnPause();
        }
        else
        {
            IsPlaying(true);
            audioSource.Play();
        }
    }

    void Update()
    {
        if (audioClip == null)
        {
            m_onConsoleChanged.Invoke("No Audio Clip Found!\nRecord Something First.");
        }

        m_audioStatePercent = GetComponent<AudioSource>().time;

        //if ((audioSlider.value == audioSlider.maxValue || audioSlider.value == audioSlider.minValue) && !audioSource.isPlaying)
        //{
        //    IsPlaying(false);
        //    isPaused = false;
        //}
    }
}