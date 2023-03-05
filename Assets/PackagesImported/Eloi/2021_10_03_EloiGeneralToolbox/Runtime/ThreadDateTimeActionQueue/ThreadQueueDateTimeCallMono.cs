using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ThreadQueueDateTimeCall {
    private static ThreadQueueDateTimeCallMono m_instanceInScene;
    
    public static ThreadQueueDateTimeCallMono Instance {
        get {
            if (m_instanceInScene == null)
               Eloi.E_SearchInSceneUtility.TryToFetchWithActiveInScene<ThreadQueueDateTimeCallMono>(ref m_instanceInScene,true);

            if (m_instanceInScene == null)
            {
                GameObject created = new GameObject("Thread Queue Call");
                ThreadQueueDateTimeCallMono script = created.AddComponent<ThreadQueueDateTimeCallMono>();
                m_instanceInScene = script;
            }

            return m_instanceInScene;
        }
    }

}

public class ThreadQueueDateTimeCallMono : MonoBehaviour
{


    public static DateTime m_start;
    public Queue<DateTimeAction> m_threadQueue = new Queue<DateTimeAction>();

    Thread t = null;
    public bool m_threadNeedToDieFalse;


    [System.Serializable]
    public class DateTimeAction {
        public DateTime m_at;
        public Action m_toDo;
        public DateTimeAction(DateTime at, Action toDo)
        {
            this.m_at = at;
            this.m_toDo = toDo;
        }
    }

    public void Add(DateTimeAction waitAction) {
        if(m_threadQueue!=null)
        m_threadQueue.Enqueue(waitAction);
    }

    public bool NothingToExecuteInWaiting()
    {
        return m_actionQueue.Count<=0 && m_threadQueue.Count<=0;
    }

    public int m_actionInThreadWaitingToBeExecuted;
    public void Update()
    {
        m_actionInThreadWaitingToBeExecuted = m_actionQueue.Count;
        m_timeBetweenNowAndLastTick = (DateTime.Now - m_lastTickOfThread).TotalMilliseconds;
    }

    public System.Threading. ThreadPriority m_priority = System.Threading.ThreadPriority.Highest;
    private void OnEnable()
    {
        m_start = DateTime.Now;
        if (t != null)
            t.Abort();
        t = new Thread(CheckTheQueue);
        m_threadNeedToDieFalse = false;
        t.Priority = m_priority;
        t.Start();
    }

    private void OnDisable()
    {
        m_threadNeedToDieFalse = true;
        if (t != null)
            t.Abort();
    }
    public bool m_catchException;
    private DateTime m_previous;
    private DateTime m_current;
    public Eloi.StringClampHistory m_errorHistory = new Eloi.StringClampHistory();
    static readonly object Identity = new object();
    List<DateTimeAction> m_actionQueue = new List<DateTimeAction>();

    [ContextMenu("Reset at zero Queue")]
    public void ResetListToZero() {
        m_actionQueue.Clear();
        m_threadQueue.Clear();
        m_actionInThreadWaitingToBeExecuted = 0;
    }
    public string m_shitHappened;
    public double m_deltaOfThead;
    private readonly object balanceLock = new object();
    public void CheckTheQueue() {


        double delta;
        while (!m_threadNeedToDieFalse) {

            try
            {
                lock (balanceLock)
                {
                    m_previous = m_current;
                    m_current = DateTime.Now;
                    delta = (m_current - m_previous).TotalMilliseconds;
                    m_deltaOfThead = delta;
                    while (m_threadQueue.Count > 0)
                    {
                        m_actionQueue.Insert(0, m_threadQueue.Dequeue());
                    }

                    if (m_actionQueue.Count > 0)
                    {

                        for (int i = m_actionQueue.Count - 1; i >= 0; i--)
                        {
                            if (m_actionQueue[i] != null && m_actionQueue[i].m_at <= m_current)
                            {
                                if (m_actionQueue[i].m_toDo != null)
                                {

                                    m_actionQueue[i].m_toDo.Invoke();

                                }
                                m_actionQueue.RemoveAt(i);
                            }
                            else if (m_actionQueue[i] == null)
                                m_actionQueue.RemoveAt(i);

                        }
                    }
                }
            }
            catch (Exception e) {
                m_actionQueue.Clear();
                m_threadQueue.Clear();
                m_errorHistory.PushIn(e.StackTrace);
                m_shitHappened = e.StackTrace;
            }
            m_lastTickOfThread=(m_current);
            Thread.Sleep(1);
        }
    }
    public DateTime m_lastTickOfThread;
    public double m_timeBetweenNowAndLastTick;
    public void AddFromNowInMs(int milliseconds, Action action)
    {
        DateTime now = DateTime.Now;
        DateTime when= now.AddMilliseconds(milliseconds);
        DateTimeAction da = new DateTimeAction(when ,action);
        Add(da);
    }
}
