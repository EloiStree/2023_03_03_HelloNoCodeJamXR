using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    public bool m_playAtStart;
    void Start()
    {
        // Get the AudioSource component attached to this game object
        audioSource = GetComponent<AudioSource>();
    }


    [ContextMenu("Jouer du son")]
    public void PlaySound()
    {
        // Set the audio clip to play
        audioSource.clip = audioClip;

        // Play the audio clip
        audioSource.Play();
    }
}
