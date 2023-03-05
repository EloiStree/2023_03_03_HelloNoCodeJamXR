using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PerformanceCheckingCompareUnityEventMono : MonoBehaviour
{
    [Header("What to test ?")]
    public UnityEvent m_aCall;
    public UnityEvent m_bCall;
    [Header("Loop testing control")]
    public CoroutineLoopInfo m_loopInfo;
    [Header("Result")]
    public PerformanceCompareResult m_compareResult;

    [Header("Iterations of the test you want")]
    public uint interationsCount = 100000;
    public uint groupOfTestCount = 10;

    private void Start()
    {
        m_loopInfo.m_whatToDo = CheckUnityEventLinked;
        StartCoroutine(E_QuickCoroutineUtility.DoWhile(m_loopInfo));
       
    }

    [ContextMenu("Check code in Unity Event")]
    public void CheckUnityEventLinked()
    {

        IMethodeToTest a = new UnityEventApproximationCodeToTest(m_aCall);
        IMethodeToTest b = new UnityEventApproximationCodeToTest(m_bCall);
        E_PerfEstimationUtility.FullCheckOfAToB(in a,in b, out m_compareResult);

    }
 


}
