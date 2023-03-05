using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_QuickCoroutineUtility : MonoBehaviour
    {

        public static IEnumerator DoWhile(CoroutineLoopInfo info)
        {

            yield return new WaitForSeconds(info.m_initialTime);
            while (!info.m_requestToBeKilled)
            {
                yield return new WaitForEndOfFrame();
                yield return new WaitForSeconds(info.m_timeBetweenLoop);
                if (info.m_isActive)
                {
                    info.m_whatToDo.Invoke();
                }
            }
            yield break;
        }
    }

    [System.Serializable]
    public class CoroutineLoopInfo
    {

        public float m_initialTime = 1;
        public float m_timeBetweenLoop = 5;
        public bool m_isActive = true;
        public bool m_requestToBeKilled;
        public Action m_whatToDo;

    }
}