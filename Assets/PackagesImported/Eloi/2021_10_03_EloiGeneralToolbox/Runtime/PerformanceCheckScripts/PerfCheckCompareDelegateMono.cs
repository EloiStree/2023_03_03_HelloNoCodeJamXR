using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfCheckCompareDelegateMonoDemo : MonoBehaviour
{

    public PerformanceCompareResult m_resultMethodes;
    public PerformanceCompareResult m_resultAnonymes;

    private void Start()
    {
        Compare();
    }
    [ContextMenu("Compare delegate methode")]
    public void Compare() {

        E_PerfEstimationUtility.FullCheckOfAToB(A, B, out m_resultMethodes);
        E_PerfEstimationUtility.FullCheckOfAToB(
            ()=> { int a = 5; },
            ()=>{ int b = 6; },
            out  m_resultAnonymes);
    }
    public void A()
    {
        //YourCode
    }
    public void B()
    {
        //YourCode
    }
}
