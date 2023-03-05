using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class RunOnlyInEditorMono : MonoBehaviour
    {
        public GameObject[] m_deactivate;
        public GameObject[] m_destroy;
        public UnityEvent m_toDoIfNotEditor;

        void Awake()
        {
#if UNITY_EDITOR
            for (int i = 0; i < m_deactivate.Length; i++)
            {
                m_deactivate[i].SetActive(false);
            }
            for (int i = 0; i < m_destroy.Length; i++)
            {
               Destroy( m_deactivate[i] );
            }
            m_toDoIfNotEditor.Invoke();
#endif
        }

        void Reset()
        {
            m_deactivate = new GameObject[] { this.gameObject };
        }
    }

}
