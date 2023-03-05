using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class TextureRelayMono : MonoBehaviour
    {
        public Texture2D m_lastPushed;
        public Eloi.ClassicUnityEvent_Texture2D m_textureToPush;
        public void PushTexture(Texture2D texture) {
            m_lastPushed = texture;
            m_textureToPush.Invoke(texture);
        }
       
    }
}
