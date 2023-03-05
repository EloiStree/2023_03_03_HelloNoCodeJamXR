using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class OpenUrlMono
        : MonoBehaviour
    {

        public string m_urlByDefault;

        public void OpenUrl(string givenUrl) {

            Application.OpenURL(givenUrl);
        }

        public void OpenUrlByDefault() {
            Application.OpenURL(m_urlByDefault);
        }
    }
}
