using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class CoroutineLoopTick : MonoBehaviour
    {
        public float m_timeBeforeFirstTick=0.1f;
        public float m_timeBetweenTick=1f;
        public UnityEvent m_tick;

        public Coroutine m_loop;


        public void OnEnable()
        {
            if (m_loop != null) {
                StopCoroutine(m_loop);
                m_loop = null;
            }
            m_loop =  StartCoroutine(Loop());
        }
        public void OnDisable()
        {
            StopCoroutine(m_loop);
        }
        IEnumerator Loop()
        {
            yield return new WaitForSeconds(m_timeBeforeFirstTick);
            m_tick.Invoke();
            while (true) {

                yield return new WaitForEndOfFrame();
                yield return new WaitForSeconds(m_timeBetweenTick);
                m_tick.Invoke();

            }  
        }

    }
}
