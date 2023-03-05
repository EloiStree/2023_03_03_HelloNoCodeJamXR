using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{

    public class GroupOfLoopingTick {
        public List<ILoopingTick> m_loopingTick = new List<ILoopingTick>();
        public void RemoveTimeToAll(in float timeInSeconds) {
            for (int i = 0; i < m_loopingTick.Count; i++)
            {
                if (m_loopingTick[i] != null)
                {
                    m_loopingTick[i].RemoveTime(in timeInSeconds);
                    m_loopingTick[i].CheckForTriggeringAndRefresh();
                }
            }
        }
        public void AddLoopingTick(ILoopingTick value) {
            RemoveLoopingTick(value);
            m_loopingTick.Add(value);
        }
        public void RemoveLoopingTick(ILoopingTick value)
        {
            m_loopingTick.Remove(value);
        }
    }



    public interface ILoopingTick
    {
        void AddListener(TickDelegateEvent tickListener);
        void RemoveListener(TickDelegateEvent tickListener);
        void ResetTimer();
        void RemoveTime(in float timeInSeconds);
        void CheckForTriggeringAndRefresh();
    }

    [System.Serializable]
    public class LoopingTickBean : ILoopingTick
    {
        protected TickDelegateEvent m_tick;
        [SerializeField] protected float m_loopTimeInSeconds;
        [SerializeField] protected float m_loopTimeInSecondsTrack;

        public LoopingTickBean(float timeInSeconds, params TickDelegateEvent [] toTrigger)
        {
            for (int i = 0; i < toTrigger.Length; i++)
            {
                if (toTrigger[i] != null) { 
                    AddListener(toTrigger[i]);
                }
            }
            m_loopTimeInSeconds = timeInSeconds;
            ResetTimer();
        }
        public void AddListener(TickDelegateEvent tickListener)
        {
            m_tick += tickListener;
        }
        public void RemoveListener(TickDelegateEvent tickListener)
        {
            m_tick -= tickListener;
        }

        public void ResetTimer()
        {

            m_loopTimeInSecondsTrack = m_loopTimeInSeconds;
        }

        public void RemoveTime(in float timeInSeconds)
        {
            m_loopTimeInSecondsTrack -= timeInSeconds;
        }
        public void RemoveDeltaTime()
        {
            m_loopTimeInSecondsTrack -= Time.deltaTime;
        }

        public void CheckForTriggeringAndRefresh()
        {
            if (m_loopTimeInSecondsTrack < 0f)
            {
                Tick();
                m_loopTimeInSecondsTrack = m_loopTimeInSeconds;
            }
        }

        public virtual void Tick()
        {
            if (m_tick != null)
                m_tick();
        }
    }
    [System.Serializable]
    public class LooopingTickBeanUnityEvent : LoopingTickBean
    {
        public LooopingTickBeanUnityEvent(float timeInSeconds) : base(timeInSeconds)
        { }

        [SerializeField] protected UnityEvent m_onTickEvent = new UnityEvent();

        public override void Tick()
        {
            if (m_tick != null)
                m_tick();
            m_onTickEvent.Invoke();
        }
    }
}
