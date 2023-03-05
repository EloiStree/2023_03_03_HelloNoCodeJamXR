using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class EndOfFrameTick : MonoBehaviour
    {

        public bool m_useEndOfFrame=true;
        public UnityEvent m_endOfFrameTick;

        public bool m_useLateUpdate;
        public UnityEvent m_lateUpdateTick;
        // Start is called before the first frame update
        IEnumerator Start()
        {
            while (true) {

                yield return new WaitForEndOfFrame();
                if(m_useEndOfFrame)
                     m_endOfFrameTick.Invoke();
            }
        
        }

        void LateUpdate()
        {
            if(m_useLateUpdate)
                m_lateUpdateTick.Invoke();
        }
    }
}
