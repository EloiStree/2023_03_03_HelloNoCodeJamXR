using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PechaKuchaInputToEventMono : MonoBehaviour
{

    public PechaKuchaInput m_input;
    public UnityEvent m_resetAndPlay;
    public UnityEvent m_resetAndStop;
    public UnityEvent m_previousSlide;
    public UnityEvent m_nextSlide;
    public UnityEvent m_switchPause;

    // Start is called before the first frame update
    void Start()
    {
        m_input = new PechaKuchaInput();
        m_input.Enable();
        m_input.ClassicInput.Enable();
        m_input.ClassicInput.ResetAndPlay.performed += ResetAndPlay;
        m_input.ClassicInput.ResetAndStop.performed += (obj) => { m_resetAndStop.Invoke(); };
        m_input.ClassicInput.PreviousSlide.performed += (obj) => { m_previousSlide.Invoke(); };
        m_input.ClassicInput.NextSlide.performed += (obj) => { m_nextSlide.Invoke(); };
        m_input.ClassicInput.SwitchPause.performed += (obj) => { m_switchPause.Invoke(); };


    }

    private void ResetAndPlay(InputAction.CallbackContext obj)
    {
        m_resetAndPlay.Invoke();
    }

}
