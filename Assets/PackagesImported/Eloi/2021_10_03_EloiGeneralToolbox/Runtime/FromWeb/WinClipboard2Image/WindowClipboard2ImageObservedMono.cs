using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class WindowClipboard2ImageObservedMono : MonoBehaviour
    {
        public Eloi.ClassicUnityEvent_Texture2D m_newImage;
        public bool m_useUpdateToCheck=true;
        public Texture2D m_lastPushed;
        public int m_currentWidth;
        public int m_currentHeight;
        public int m_previousWidth;
        public int m_previousHeight;
        void Update()
        {
            if(m_useUpdateToCheck)
                CheckClipboardForNew();
        }

        [ContextMenu("Push Current from Clipboard")]
        public void PushCurrent() {


            WindowClipboard2Image.GetDimension(out m_currentWidth, out m_currentHeight);
            m_previousWidth = m_currentWidth;
            m_previousHeight = m_currentHeight;
            m_lastPushed = WindowClipboard2Image.Copy();
            m_newImage.Invoke(m_lastPushed);
        }
        private void CheckClipboardForNew()
        {
            if (WindowClipboard2Image.IsThereImageAvailable())
            {
                WindowClipboard2Image.GetDimension(out m_currentWidth, out m_currentHeight);
                if (m_currentWidth != m_previousWidth || m_currentHeight != m_previousHeight)
                {
                    m_previousWidth = m_currentWidth;
                    m_previousHeight = m_currentHeight;
                    m_lastPushed = WindowClipboard2Image.Copy();
                    m_newImage.Invoke(m_lastPushed);
                }
            }
            else
            {
                if (m_currentHeight > -1 || m_currentWidth > -1)
                {
                    m_lastPushed = null;
                    m_newImage.Invoke(null);
                }
                m_currentWidth = -1; m_previousWidth = -1;
            }
        }
    }
}
