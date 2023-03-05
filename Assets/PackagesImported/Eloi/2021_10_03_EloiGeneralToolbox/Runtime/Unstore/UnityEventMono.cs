using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace be.eloistree.generaltoolbox
{
    public class UnityEventMono : MonoBehaviour
    {
        public UnityEvent m_toDoOnTriggered;

        [ContextMenu("Invoke Event")]
        public void Invoke() {
            m_toDoOnTriggered.Invoke();
        }
    }
}
