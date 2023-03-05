using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class AbstractRootTransformMono : MonoBehaviour
    {
        [SerializeField] Transform m_root;
        public void GetRootTransform(out Transform root) => root = m_root;
        public Transform GetRootTransform() { return m_root; }

        private void Reset()
        {
            m_root = transform;
        }
    }
}
