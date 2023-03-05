using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Eloi { 
    [System.Serializable]
    public class GenericClampHistory<T> 
    {
        [Range(1,100)]
        public int m_historySize=10;
        [SerializeField] List<T> m_history = new List<T>();

        public void PushIn(T value) {
            if(m_historySize>0)
            Eloi.E_GeneralUtility.ListAsQueueInsert(in value, in m_historySize, ref m_history);
        }

        public T GetAt(int index) { return m_history[index]; }
        public void GetHistoryAsArray(out T[] history)
        {
            history = m_history.ToArray();
        }
        public void GetHistorySize(out int currentSize, out int maxSize)
        {
            currentSize = m_history.Count;
            maxSize = m_historySize;
        }
        public void GetHistoryRealSize(out int currentSize)
        {

            currentSize = m_history.Count;
        }
        public void GetHistoryMaxSize( out int maxSize)
        {
            maxSize = m_historySize;
        }
        public void Clear() {
            m_history.Clear();
        }
    }

    [System.Serializable]
    public class StringClampHistory : GenericClampHistory<string> { }
    [System.Serializable]
    public class TypeClampHistory : GenericClampHistory<string> {
        public void PushIn(System.Type typeValue) {
            PushIn(typeValue.ToString());
        }
    }


}
