using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi { 
    public class Base64ToImageMono : MonoBehaviour
    {
        public E_Base64ToImage.SupportedImageTypeB64 m_converType;
        public Texture2D m_imageFrom;
        public bool m_convertedFrom;
        public string m_data64;
        public string m_data64WithHeader;
        public Texture2D m_imageTo;
        public bool m_convertedTo;

        [ContextMenu("Screenshot double convertion")]
        public void Test()
        {
            E_Base64ToImage.ConvertTextureToBase64(m_imageFrom,
                m_converType,
                out  m_convertedFrom,
                out  m_data64,
                out  m_data64WithHeader);
            E_Base64ToImage.TryBase64StringToImage(m_data64WithHeader, out m_convertedTo, out m_imageTo);
        }
}
}
