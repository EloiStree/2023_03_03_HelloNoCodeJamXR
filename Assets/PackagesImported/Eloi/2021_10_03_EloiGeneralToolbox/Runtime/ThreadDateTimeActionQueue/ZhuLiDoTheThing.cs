using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public interface IZhuLiDoTheThing
    {
        void DoTheThing();
    }
    public delegate void ZhuLiDelegate();

    [System.Serializable]
    public class ZhuLiSystemAction : IZhuLiDoTheThing
    {
        System.Action m_toDo;

        public void AddAction(Action toDo) => m_toDo += toDo;
        public void RemoveAction(Action toDo) => m_toDo -= toDo;
        public void Clear() => m_toDo = null;
        public ZhuLiSystemAction()
        { }

        public ZhuLiSystemAction(Action toDo)
        {
            m_toDo = toDo;
        }
        public ZhuLiSystemAction(ZhuLiDelegate toDo)
        {
            AddAction(ExecuteZhuLiAction(toDo));
        }
        Action ExecuteZhuLiAction(ZhuLiDelegate doTheThing) {
            return () => { if (doTheThing != null) doTheThing(); };
        }

        public void DoTheThing()
        { if (m_toDo != null) m_toDo.Invoke(); }
        
    }

    [System.Serializable]
    public class AtTimeZhuLiSystemAction : ZhuLiSystemAction
    {
        [SerializeField] SerializableDateTime m_at= new SerializableDateTime();
        public AtTimeZhuLiSystemAction(DateTime at)
        {
            m_at.SetWithDate(at);
        }

        public void SetWhenToExecute(DateTime when) => m_at.SetWithDate(when);
        public bool IsTimePast(DateTime now) { return now < m_at.GetAsDate(); }
    }

}
