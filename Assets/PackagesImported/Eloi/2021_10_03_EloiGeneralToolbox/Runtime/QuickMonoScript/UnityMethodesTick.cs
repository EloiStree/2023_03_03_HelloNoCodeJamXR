using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi {
    public class UnityMethodesTick : MonoBehaviour
    {
        public UnityEvent m_onAwake = new UnityEvent();
        public UnityEvent m_onStart = new UnityEvent();
        public UnityEvent m_onEnable = new UnityEvent();
        public UnityEvent m_onDisable = new UnityEvent();
        public UnityEvent m_onDestroy = new UnityEvent();
        public UnityEvent m_onApplicationQuit = new UnityEvent();


        public void Awake() {
             m_onAwake.Invoke();
        } 
        public void Start()
        {
            m_onStart.Invoke();
        }
        public void OnEnable(){
                 m_onEnable.Invoke();
        }
        public void OnDisable()
                {
                   m_onDisable.Invoke();
        }
        public void OnDestroy()
                    {
                       m_onDestroy.Invoke();
        }
        public void OnApplicationQuit()
                        {
                            m_onApplicationQuit.Invoke();
        }

    }
}
