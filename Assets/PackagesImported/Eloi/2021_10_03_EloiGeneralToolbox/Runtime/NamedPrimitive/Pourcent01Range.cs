using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public interface IPercent01RangeGet
    {
         void GetPercentRangeMin(out IPercent01Get percentValueFromZeroToOne);
         IPercent01Get GetPercentRangeMin();
         void GetPercentRangeMax(out IPercent01Get percentValueFromZeroToOne);
         IPercent01Get GetPercentRangeMax();
    }
    
    [System.Serializable]
    public class Percent01Range : IPercent01RangeGet
    {
        [SerializeField] Percent01 m_minPercent = new Percent01(0);
        [SerializeField] Percent01 m_maxPercent = new Percent01(1);

        public Percent01Range(in float percentValueMin, in float percentValueMax)
        {
            m_minPercent.SetPercent(percentValueMin);
            m_maxPercent.SetPercent(percentValueMax);
        }


        public void GetPercentRangeMin(out IPercent01Get percentValueFromZeroToOne) => percentValueFromZeroToOne = m_minPercent;
        public void GetPercentRangeMax(out IPercent01Get percentValueFromZeroToOne) => percentValueFromZeroToOne = m_maxPercent;
        public IPercent01Get GetPercentRangeMin()
        {
            GetPercentRangeMin(out IPercent01Get value);
            return value;

        }
        public IPercent01Get GetPercentRangeMax()
        {
            GetPercentRangeMax(out IPercent01Get value);
            return value;
        }
    }
}
