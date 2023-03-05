using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefaultDestroyManagerMono : AbstractDestroyManagerMono
{
    [Header("Use default destructon of Unity")]
    public GameObject m_destructionRootTarget;
    public enum DestroyType { DeveloperManaged, Destroy, ImmediateDestroy, Deactivate}
    public DestroyType m_destructionType = DestroyType.Destroy;
    
    [Header("What to do")]
    public UnityEvent m_beforeCallingDestroy;
    public UnityEvent m_destroyCall;
    public UnityEvent m_afterCallingDestroy;

    [Header("Unity")]
    public UnityEvent m_onUnityOnDestroyCall;

  
    public override void RequestDestruction()
    {
        m_beforeCallingDestroy.Invoke();
        m_destroyCall.Invoke();
        switch (m_destructionType)
        {
            case DestroyType.DeveloperManaged:
                break;
                
            case DestroyType.Destroy:
                if(m_destructionRootTarget)
                GameObject.Destroy(m_destructionRootTarget);
                break;
            case DestroyType.ImmediateDestroy:
                if (m_destructionRootTarget)
                    GameObject.DestroyImmediate(m_destructionRootTarget);
                break;
            case DestroyType.Deactivate:
                if (m_destructionRootTarget)
                    m_destructionRootTarget.SetActive(false);
                break;
            default:
                break;
        }
        m_afterCallingDestroy.Invoke();
    }

    public void CallTest(string text) {
        Debug.Log("Test:"+ text);
    }

    private void OnDestroy()
    {
        m_onUnityOnDestroyCall.Invoke();
    }
}
