using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DeveloperNote_B64Image : DeveloperNoteMono
    {

        public B64Text m_b64Text;
        [HideInInspector]
        public Texture2D m_image;

        [System.Serializable]
        public class B64Text {
            [TextArea(0,5)]
            public string m_b64Text;
        }

        [ContextMenu("Open Image In Browser")]
        public void OpenImageInBrowser() {

            E_Base64ToImage.OpenB64InBrowser(m_b64Text.m_b64Text);
        }
        public void SetWithURL(string url) {
            Eloi.E_DownloadImage.TryToLoadImageFromDataOrURI_Direct(url,out m_image);
            if (m_image != null)
                Eloi.E_Base64ToImage.ConvertTextureToBase64(m_image, E_Base64ToImage.SupportedImageTypeB64.PNG,
                           out bool c,
                           out string data, out m_b64Text.m_b64Text);
            else m_b64Text.m_b64Text = "";
        }

        public void SetWithB64(string b64Text)
        {
            m_b64Text.m_b64Text = b64Text;
            Eloi.E_Base64ToImage.ConvertBase64WithHeaderStringToImage(b64Text, out bool converted, out m_image);
        }
        public void SetWithTexture2D(Texture2D texture)
        {
            Eloi.E_Base64ToImage.ConvertTextureToBase64(texture, E_Base64ToImage.SupportedImageTypeB64.PNG,
                       out bool c,
                       out string data, out m_b64Text.m_b64Text);
            m_image = texture;
        }
        [ContextMenu("Convert Image To B64 Text Save")]
        public void ConvertImageToB64Text()
        {
            if (m_image == null)
                m_b64Text.m_b64Text = "";
            else
                Eloi.E_Base64ToImage.ConvertTextureToBase64(m_image, E_Base64ToImage.SupportedImageTypeB64.PNG,
                       out bool c,
                       out string data, out m_b64Text.m_b64Text);

        }
        [ContextMenu("Scale down -10%")]

        public void ScaleDownImageBy10Percent() => ScaleDownImageSize(0.9f);
        [ContextMenu("Scale down -25%")]

        public void ScaleDownImageBy25Percent() => ScaleDownImageSize(0.75f);
        
        [ContextMenu("Scale down -50%")]

        public void ScaleDownImageBy50Percent() => ScaleDownImageSize(0.5f);

        [ContextMenu("Flush")]
        public void Flush() {

            m_image = null;
            m_b64Text.m_b64Text = "";
        }


        public void ScaleDownImageSize(float percentScaleDown) {
             TextureScale.Scale(m_image
                ,(int)( m_image.width * percentScaleDown)
                , (int)(m_image.height * percentScaleDown));
            ConvertImageToB64Text();
        }

        [ContextMenu("Convert B64 Text To Image")]
        public void ConvertB64TextToImage()
        {

            m_image = null;
            Eloi.E_Base64ToImage.ConvertBase64WithHeaderStringToImage(m_b64Text.m_b64Text, out bool converted, out m_image);
           if (!converted)
                m_image = new Texture2D(2, 2);
        }
        [ContextMenu("Convert Clipboard To Image")]
        public void ConvertClipboardToImage()
        {
            m_image = null;
            if (WindowClipboard2Image.IsThereImageAvailable())
            {
                Texture2D tmp = WindowClipboard2Image.Copy();
                if (tmp == null) m_b64Text.m_b64Text = "";
                else { 
                Eloi.E_Base64ToImage.ConvertTextureToBase64(tmp, E_Base64ToImage.SupportedImageTypeB64.PNG, 
                    out bool c,
                    out string data, out  m_b64Text.m_b64Text);
                }

            }
            Eloi.E_Base64ToImage.ConvertBase64WithHeaderStringToImage(m_b64Text.m_b64Text, out bool converted, out m_image);
            if (!converted)
                m_image = new Texture2D(2, 2);
        }


        protected override void OnValidate()
        {
            base.OnValidate();
            if (m_image==null &&  m_b64Text.m_b64Text != null && m_b64Text.m_b64Text.Length > 1) {
                ConvertB64TextToImage();
            }

        }
    }
}
