using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Eloi
{
    public class GoodOldRestartLevelOnEscape : MonoBehaviour
    {
        public KeyCode m_escapeKey = KeyCode.Escape;

        void Update()
        {
            if (this.gameObject.activeSelf && this.enabled) { 
                if ( Input.GetKeyDown(m_escapeKey) ) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}
