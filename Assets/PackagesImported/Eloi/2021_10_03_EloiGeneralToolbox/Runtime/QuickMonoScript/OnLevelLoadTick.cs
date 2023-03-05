using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class OnLevelLoadTick : MonoBehaviour
    {
        public void OnLevelWasLoaded(int level)
        { 
            m_tick.Invoke();
        }
        public UnityEvent m_tick;
        [ContextMenu("Tick")]
        public void Tick()
        {
            m_tick.Invoke();
        }
    }
}
