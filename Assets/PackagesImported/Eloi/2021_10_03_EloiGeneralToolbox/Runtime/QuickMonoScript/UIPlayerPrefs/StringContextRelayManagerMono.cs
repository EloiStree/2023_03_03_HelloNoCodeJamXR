using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StringContextRelayManagerMono : MonoBehaviour
{

    public string m_lastContextReceived;
    public Eloi.PrimitiveUnityEvent_String m_onContextReceived;
    public StringContextListenerRelayMono [] m_listenerInEditor;
    public GameObject[] m_searchInChildrenForListener;
    public List<GameObject> m_searchInChildrenForListenerList;


 

    public void AddGameObjectPossibleListener(GameObject givenObject)
    {
        m_searchInChildrenForListenerList.Add(givenObject);
    }
    public void RemoveGameObjectPossibleListener(GameObject givenObject)
    {
        m_searchInChildrenForListenerList.Remove(givenObject);
    }
    public void ClearListOfAddedObjectAtRuntime()
    {
        m_searchInChildrenForListenerList.Clear();
    }
    public void ClearListOfAddedObjectAtRuntimeOfNull()
    {
        m_searchInChildrenForListenerList = m_searchInChildrenForListenerList.Where(k => k != null).ToList();
    }

    [ContextMenu("RePush Last received")]
    public void PushContextFromLastReceived() {
        PushContext(m_lastContextReceived);
    }

    public void PushContext(string stringContextId)
    {
        m_lastContextReceived = stringContextId;
        m_onContextReceived.Invoke(stringContextId);
        foreach (var listener in m_listenerInEditor) {

            if (listener != null) { 
                    listener.PushContext(stringContextId);
            }
        }

        foreach (var gameObject in m_searchInChildrenForListener)
        {
            SearchInGameObjectAndPushInChildren(stringContextId, gameObject);
        }
        foreach (var gameObject in m_searchInChildrenForListenerList)
        {
            SearchInGameObjectAndPushInChildren(stringContextId, gameObject);
        }
    }
    public void SearchInGameObjectAndPushInChildren( GameObject gameObject)
    {
        SearchInGameObjectAndPushInChildren(m_lastContextReceived, gameObject);
    }
    public  void SearchInGameObjectAndPushInChildren(string stringContextId, GameObject gameObject)
    {
        m_lastContextReceived = stringContextId;
        if (gameObject != null)
        {
            StringContextListenerRelayMono[] listeners = gameObject.GetComponentsInChildren<StringContextListenerRelayMono>();
            foreach (var listener in listeners)
                if (listener != null)
                    listener.PushContext(stringContextId);
        }
    }
}
