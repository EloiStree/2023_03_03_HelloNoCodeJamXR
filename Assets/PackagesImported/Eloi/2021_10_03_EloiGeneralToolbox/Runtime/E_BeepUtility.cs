using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_BeepUtility : MonoBehaviour
{
    //https://www.youtube.com/watch?v=RJVIuWrNlEg&list=PLvUgPgA2Kp_-BLkAUzR-NTA7FDowf9Ig5&index=12

    

    public static void SetOscillatorTo(float volume, float frequency)
    {
        GetOrCreateOscillator(out OscillatorMono oscillator);
        oscillator.SetVolume(volume);
        oscillator.SetFrequency(frequency);
    }

    public static void SetOscillatorGainTo(float volume, float maxGain)
    {
        GetOrCreateOscillator(out OscillatorMono oscillator);
        oscillator.SetGain(volume, maxGain);
    }
    public static void SetOscillatorVolume(float volumeInPourcent) {

        GetOrCreateOscillator(out OscillatorMono oscillator);
        oscillator.SetVolume(volumeInPourcent);
    }
    public static void SetOscillatorOff()
    {

        GetOrCreateOscillator(out OscillatorMono oscillator);
        oscillator.SetActiveStateAs(false);
    }
    public static void SetOscillatorState(bool setAsActive)
    {

        GetOrCreateOscillator(out OscillatorMono oscillator);
        oscillator.SetActiveStateAs(setAsActive);
    }

    public static void CreateOscillatorForDuration(float duration, float frequence, float volume = 1f, float maxGain = 0.1f)
    {
        GameObject g = new GameObject(string.Format("Oscillation:t{0:0.00} f{1:0} Vol{2} Gain{3} ", duration, frequence, volume, maxGain));
        Destroy(g, duration);
        g.AddComponent<AudioSource>();
        OscillatorMono o = g.AddComponent<OscillatorMono>();
        o.SetGain(volume, maxGain);
        o.SetActiveStateAs(true);
        o.SetFrequency(frequence);
    }
    public static void CreateOscillatorForDuration(float duration, OscillatorMono.Note note, OscillatorMono.Octave octave = OscillatorMono.Octave._2, float volume = 1f, float maxGain = 0.1f)
    {
        CreateOscillatorForDuration(duration, volume, maxGain, out OscillatorMono oscillator);
        oscillator.name += " "+note + " / " + octave;
        oscillator.SetFrequencyWithNote(note, octave);

    }
    public static void CreateOscillatorForDuration(float duration, OscillatorMono.LatinNote note, OscillatorMono.Octave octave = OscillatorMono.Octave._2, float volume = 1f, float maxGain = 0.1f)
    {
        CreateOscillatorForDuration(duration, volume, maxGain, out OscillatorMono oscillator);
        oscillator.name += " " + note + " / " + octave;
        oscillator.SetFrequencyWithNote(note, octave);

    }
    public static void CreateOscillatorForDuration(float duration, OscillatorMono.LatinNoteAlias note, OscillatorMono.Octave octave = OscillatorMono.Octave._2, float volume = 1f, float maxGain = 0.1f)
    {
        CreateOscillatorForDuration(duration, volume, maxGain, out OscillatorMono oscillator);
        oscillator.name += " " + note + " / " + octave;
        oscillator.SetFrequencyWithNote(note, octave);

    }
    public static void CreateOscillatorForDuration(
        float duration, 
        float volume ,
        float maxGain , 
        out OscillatorMono oscillator)
    {
        GameObject g = new GameObject(string.Format("Oscillation:t{0:0.00} Vol{1} Gain{2} ", duration, volume, maxGain));
        Destroy(g, duration);
        g.AddComponent<AudioSource>();
        oscillator = g.AddComponent<OscillatorMono>();
        oscillator.SetGain(volume, maxGain);
        oscillator.SetActiveStateAs(true);
        

    }



    public  static void GetOrCreateOscillator(out OscillatorMono oscillator) {
      
        if (m_instanceInScene == null)
        {
            GameObject g = new GameObject("Oscillator (created at runtime)");
            g.AddComponent(typeof(AudioSource));

            m_instanceInScene = (OscillatorMono) g.AddComponent(typeof(OscillatorMono));
            m_instanceInScene.SetActiveStateAs(true);
            

        }
        oscillator = m_instanceInScene;
    }
    public void OverrideOscillatorInScene(OscillatorMono oscillator) {
        m_instanceInScene = oscillator;
    }

    internal static void SetOscillatorFull(bool isActive, float volume, float maxGain, float frequence)
    {
        GetOrCreateOscillator(out OscillatorMono o);
        o.SetOscillatorFull(isActive, volume, maxGain, frequence);
    }

    private static OscillatorMono m_instanceInScene;
}
}