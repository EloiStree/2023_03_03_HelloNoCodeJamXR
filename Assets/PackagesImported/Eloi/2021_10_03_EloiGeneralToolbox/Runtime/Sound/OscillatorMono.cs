using System;
using UnityEngine;

///Source: https://youtu.be/GqHFGMy_51c
public class OscillatorMono : MonoBehaviour
{

    [SerializeField] double m_frequency = 440;
    [SerializeField] double m_gain = 0.05;
    private double m_increment;
    private double m_phase;
    private double m_sampling_frequency = 48000;

    public float m_maxGain = 0.1f;
    [Range(0f, 1f)]
    [SerializeField] float m_volume;
    [SerializeField] bool m_isActive;
    public void SetVolume(float volumeInPourcent) {
        m_volume = volumeInPourcent;
        m_gain = m_maxGain * m_volume;
        CheckBoundary();
    }

    internal void SetFrequency(float frequency)
    {
        m_frequency = frequency;
        CheckBoundary();
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!m_isActive)
            return;
        CheckBoundary();

        m_increment = m_frequency * 2 * Math.PI / m_sampling_frequency;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            m_phase = m_phase + m_increment;
            data[i] = (float)(m_gain * Math.Sin(m_phase));
            if (channels == 2)
                data[i + 1] = data[i];
            if (m_phase > 2 * Math.PI) m_phase = 0;
        }
    }

    internal void SetActiveStateAs(bool isActive)
    {
        m_isActive = isActive;
    }

    public void SetGain(float volume, float maxGain)
    {
        m_maxGain = maxGain;
        SetVolume(volume);
        CheckBoundary();
    }

    private void CheckBoundary()
    {
        if (m_frequency > m_sampling_frequency)
            m_frequency = m_sampling_frequency;
        if (m_frequency < 0)
            m_frequency = 0;
        if (m_gain > m_maxGain)
            m_gain = m_maxGain;
        if (m_gain < 0f)
            m_gain = 0f;
        if (m_maxGain > 1f)
            m_maxGain = 1f;
        if (m_maxGain < 0f)
            m_maxGain = 0f;
    }
    public void SetOscillatorFull(bool isActive, float volume, float maxGain, float frequence)
    {
        SetGain(volume, maxGain);
        SetFrequency(frequence);
        SetActiveStateAs(isActive);
        CheckBoundary();
    }
    private void OnValidate()
    {
        SetVolume(m_volume);
        CheckBoundary();
    }

    public enum Octave:int { _0, _1, _2, _3, _4, _5, _6, _7, _8 }

    public enum Note:int { C, Cd, D, Dd, E, F, Fd, G, Gd, A, Ad, B }
    public enum LatinNote:int {
        UtqueantLaxis, ResonareFibris, MiraGestorum, FamuliTuorum, SolvePolluti, LabiiReatum, SancteIohannes
    }
    public enum LatinNoteAlias : int { Ut,Re, Mi, Fa, So, La, Si}

    public float[,] m_noteFrequenc = new float[,] {

{16.35f, 32.70f, 65.41f, 130.81f, 261.63f, 523.25f              ,    1046.50f ,2093.0f , 4186.0f    },
{   17.32f, 34.65f, 69.30f, 138.59f,    277.18f,    554.37f     ,    1108.73f ,2217.5f , 4434.9f    },
{18.35f,    36.71f, 73.42f, 146.83f,    293.66f,    587.33f     ,    1174.66f ,2349.3f , 4698.6f    },
{   19.45f, 38.89f, 77.78f, 155.56f,    311.13f,    622.25f     ,    1244.51f ,2489.0f , 4978.0f    },
{20.60f,    41.20f, 82.41f, 164.81f,    329.63f,    659.25f     ,    1318.51f ,2637.0f , 5274.0f    },
{21.83f,    43.65f, 87.31f, 174.61f,    349.23f,    698.46f     ,    1396.91f ,2793.8f , 5587.7f    },
{23.12f,    46.25f, 92.50f, 185.00f,    369.99f,    739.99f     ,    1479.98f ,2960.0f , 5919.9f    },
{24.50f,    49.00f, 98.00f, 196.00f,    392.00f,    783.99f     ,    1567.98f ,3136.0f , 6271.9f    },
{25.96f,    51.91f, 103.83f,    207.65f,    415.30f,    830.61f ,    1661.22f ,3322.4f , 6644.9f    },
{27.50f,    55.00f, 110.00f,    220.00f,    440.00f,    880.00f ,    1760.00f ,3520.0f , 7040.0f    },
{29.14f,    58.27f, 116.54f,    233.08f,    466.16f,    932.33f ,    1864.66f ,3729.3f , 7458.6f    },
{ 30.87f,   61.74f, 123.47f,    246.94f,    493.88f,    987.77f ,    1975.53f ,3951.1f , 7902.1f    }

    };
    public void SetFrequencyWithNote(Note note, Octave octave)
    {
        int x = (int) octave, y= (int) note;
        m_frequency  = m_noteFrequenc[y, x];

    }


    public void SetFrequencyWithNote(LatinNoteAlias note, Octave octave)
    {
        Convert(note, out Note n);
        SetFrequencyWithNote(n, octave);

    } 
    public void SetFrequencyWithNote(LatinNote note, Octave octave)
    {
        Convert(note, out Note n);
        SetFrequencyWithNote(n, octave);

    }

    private void Convert(LatinNoteAlias note, out Note n)
    {
        switch (note)
        {
            case LatinNoteAlias.Ut:
                n = Note.C;
                break;
            case LatinNoteAlias.Re:
                n = Note.D;
                break;
            case LatinNoteAlias.Mi:
                n = Note.E;
                break;
            case LatinNoteAlias.Fa:
                n = Note.F;
                break;
            case LatinNoteAlias.So:
                n = Note.G;
                break;
            case LatinNoteAlias.La:
                n = Note.A;
                break;
            case LatinNoteAlias.Si:
                n = Note.B;
                break;
            default:
                n = Note.A;
                break;
        }
    }
    private void Convert(LatinNote note, out Note n)
    {
        switch (note)
        {
            case LatinNote.UtqueantLaxis:
                n = Note.C;
                break;
            case LatinNote.ResonareFibris:
                n = Note.D;
                break;
            case LatinNote.MiraGestorum:
                n = Note.E;
                break;
            case LatinNote.FamuliTuorum:
                n = Note.F;
                break;
            case LatinNote.SolvePolluti:
                n = Note.G;
                break;
            case LatinNote.LabiiReatum:
                n = Note.A;
                break;
            case LatinNote.SancteIohannes:
                n = Note.B;
                break;
            default:
                n = Note.A;
                break;
        }
    }
}
