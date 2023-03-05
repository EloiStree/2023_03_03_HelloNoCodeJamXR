using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Eloi
{
    public interface IPercentN1P1Get
    {
        public void GetPercent(out float percentValueFromZeroToOne);
        public float GetPercent();
    }
    public interface IPercentN1P1Set
    {
        public void SetPercent(in float percentValueFromZeroToOne);
    }
    [System.Serializable]
    public class PercentN1P1 : IPercentN1P1Get, IPercentN1P1Set
    {


        [Range(-1, 1)]
        [SerializeField] float m_percentValue;

        public PercentN1P1(in float percentValue)
        {
            SetPercent(in percentValue);
        }

        public void GetPercent(out float percentValueFromZeroToOne)
        {
            percentValueFromZeroToOne = m_percentValue;
        }
        public float GetPercent()
        {
            return m_percentValue;
        }

        public void SetPercent(in float percentValueFromZeroToOne)
        {
            if (percentValueFromZeroToOne < -1)
                m_percentValue = -1;
            else if (percentValueFromZeroToOne > 1)
                m_percentValue = 1;
            else
                m_percentValue = percentValueFromZeroToOne;
        }


    }
}
