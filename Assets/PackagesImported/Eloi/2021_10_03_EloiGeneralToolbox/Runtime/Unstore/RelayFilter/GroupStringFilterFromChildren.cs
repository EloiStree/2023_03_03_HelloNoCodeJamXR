using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace be.eloistree.generaltoolbox
{
    public class GroupStringFilterFromChildren : MonoBehaviour
    {
        public StringFilterToUnityEvent[] m_foundChildren;

        public bool m_refreshOnValide=true;
        public bool m_refreshAtAwake = true;
        public void PushInTextToRelay(string text)
        {
            for (int i = 0; i < m_foundChildren.Length; i++)
            {
                if(m_foundChildren[i] != null)
                    m_foundChildren[i].PushIn(in text);
            }
        }
        [ContextMenu("Refresh list with children")]
        public void RefreshListenerInChildren()
        {
            m_foundChildren = this.gameObject.GetComponentsInChildren<StringFilterToUnityEvent>();        
        }


        public void OnValidate()
        {
            if (m_refreshOnValide)
            {
                RefreshListenerInChildren();
            }
        }
        public void OnAwake()
        {
            if (m_refreshAtAwake)
            {
                RefreshListenerInChildren();
            }
        }
    }
}
