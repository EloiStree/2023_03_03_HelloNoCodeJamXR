using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace be.eloistree.generaltoolbox
{
    public class OnlyInEditorMono : MonoBehaviour
    {
        public UnityEvent m_inEditor;
        public UnityEvent m_notInEditor;
        public bool m_useDefaultDeactivate=true;
        public bool m_useDefaultDestroy=false;
        void Awake()
        {
            bool inEditor = true;
#if !UNITY_EDITOR
            inEditor=false;
#endif
            if (inEditor)
            {
                m_inEditor.Invoke();
            }
            else {

                m_notInEditor.Invoke();
                if (m_useDefaultDeactivate)
                    this.gameObject.SetActive(false);
                if (m_useDefaultDestroy)
                    Destroy(this.gameObject);
            } 

        }

    }
}
