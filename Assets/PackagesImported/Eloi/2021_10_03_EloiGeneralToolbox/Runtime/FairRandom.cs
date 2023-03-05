using System;
using UnityEngine;
namespace Eloi
{
    [System.Serializable]
    public class FairRandom <T> {

        [SerializeField]
        private T[] m_value;
        [SerializeField]
        private int m_index=0;

        public FairRandom(T[] value)
        {
            m_value = value;
        }

        public void GetNext(out T result)
        {
            result= m_value[m_index];
            m_index++;
            if (m_index >= m_value.Length) {
                m_index = 0;
                Eloi.E_UnityRandomUtility.ShuffleRef<T>(ref m_value);
            }
        }
    }
}
