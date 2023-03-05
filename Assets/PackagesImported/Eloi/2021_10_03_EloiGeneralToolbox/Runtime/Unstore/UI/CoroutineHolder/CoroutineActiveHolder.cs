using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{

    [System.Serializable]
    public class CoroutineActiveHolder
    {
        public Coroutine m_coroutine;
        public MonoBehaviour m_monoHoldingTheCoroutine;
        public IEnumerator m_currentEnumerator;
        public CoroutineActiveHolder(MonoBehaviour monoHolder, IEnumerator methodToHold, bool startState)
        {
            m_monoHoldingTheCoroutine = monoHolder;
            m_currentEnumerator = methodToHold;
            if (startState == false)
                StopCoroutineForNow();
            else ResetCoroutineWithCurrentOne();
        }

        public void ResetCoroutineWith(IEnumerator methodDoHold)
        {
            if (m_coroutine != null && m_currentEnumerator != null)
            {
                m_monoHoldingTheCoroutine.StopCoroutine(m_currentEnumerator);
                m_currentEnumerator = null;
                m_monoHoldingTheCoroutine = null;
            }
            m_currentEnumerator = methodDoHold;
            m_coroutine =
                m_monoHoldingTheCoroutine.StartCoroutine(methodDoHold);
        }
        public void ResetCoroutineWithCurrentOne()
        {
            if (m_coroutine != null)
            {
                m_monoHoldingTheCoroutine.StopCoroutine(m_currentEnumerator);
            }
            m_coroutine =
                m_monoHoldingTheCoroutine.StartCoroutine(m_currentEnumerator);
        }
        public void StopCoroutineForNow()
        {
            if (m_currentEnumerator != null && m_monoHoldingTheCoroutine)
                m_monoHoldingTheCoroutine.StopCoroutine(m_currentEnumerator);
        }
    }
    [System.Serializable]
    public class BoolSwitchableCoroutine
    {
        public CoroutineActiveHolder m_coroutineHolder = null;
        public Eloi.PrimitiveUnityEvent_Bool m_observeBoolState = new Eloi.PrimitiveUnityEvent_Bool();

        public BoolSwitchableCoroutine(MonoBehaviour whoHoldTheCoroutine, IEnumerator methodToHold, bool startState)
        {
            if (whoHoldTheCoroutine == null)
                throw new Exception("You can't create it without a coroutine to holded");
            if (methodToHold == null)
                throw new Exception("You need a method to hold in the coroutine");
            m_coroutineHolder = new CoroutineActiveHolder(whoHoldTheCoroutine, methodToHold, startState);
            m_observeBoolState.AddListener(OnSwitchChangeCoroutineState);
            //if(startState)
            //    m_coroutineHolder.ResetCoroutineWith(methodToHold);
        }

        public BoolSwitchableCoroutine(CoroutineActiveHolder coroutineHolder)
        {
            if (m_coroutineHolder == null)
                throw new Exception("You can't create it without a coroutine to holded");
            m_coroutineHolder = coroutineHolder;
            m_observeBoolState.AddListener(OnSwitchChangeCoroutineState);
        }

        private void OnSwitchChangeCoroutineState(bool arg0)
        {
            if (m_coroutineHolder == null)
                return;

            if (arg0)
                m_coroutineHolder.ResetCoroutineWithCurrentOne();
            else
                m_coroutineHolder.StopCoroutineForNow();
        }

        public void SetActiveState(bool isActive)
        {
            m_observeBoolState.Invoke(isActive);
        }
    }
}
