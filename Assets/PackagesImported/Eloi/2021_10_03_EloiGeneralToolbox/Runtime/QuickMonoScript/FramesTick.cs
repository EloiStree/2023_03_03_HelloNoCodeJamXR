using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class FramesTick : MonoBehaviour
    {
        public FrameEvent[] m_framesAction = new FrameEvent[] {
            new FrameEvent(){ m_frameIndex =0 },
            new FrameEvent(){ m_frameIndex =1 },
            new FrameEvent(){ m_frameIndex =2 },
            new FrameEvent(){ m_frameIndex =3 }
        };

        [System.Serializable]
        public class FrameEvent {
            public int m_frameIndex=0;
            public UnityEvent m_toDo;
        }
        public long m_frame = 0;
        public long m_stopAtFrame = 20;

        public bool m_launchAtAwake=true; 
        public void Awake()
        {
            if (m_launchAtAwake)
                TriggerCoroutine();
        }

        [ContextMenu("Trigger Tick Coroutine")]
        public void TriggerCoroutine() {
            StartCoroutine(FrameTrigger());
        }

        private IEnumerator FrameTrigger()
        {
            while (m_frame < m_stopAtFrame) { 
                for (int i = 0; i < m_framesAction.Length; i++)
                {
                    if (m_frame == m_framesAction[i].m_frameIndex) {
                        m_framesAction[i].m_toDo.Invoke();
                    }
                }
                yield return new WaitForEndOfFrame();
                m_frame++;
            }
        }

    }
}
