using System;
using Unity.Collections;
using UnityEngine;

namespace Eloi
{

    public class E_Texture2DUtility
    {
        public enum TextureRotation : int { Left180 = -2, Left90 = -1, Right90 = 1, Right180 = 2 }


        public static void DoSnapshot(in Camera camera, out Texture2D texture)
        {
            {//From VINCENT
                int resWidth;
                int resHeight;
                //rendertexture.enableRandomWrite = true;
                //RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);

                Texture2D screenShot;
                resWidth = camera.pixelWidth;
                resHeight = camera.pixelHeight;

                RenderTexture renderTexture = new RenderTexture(resWidth, resHeight, 0);
                camera.targetTexture = renderTexture; //Create new renderTexture and assign to camera

                screenShot = new Texture2D(resWidth, resHeight, renderTexture.graphicsFormat, UnityEngine.Experimental.Rendering.TextureCreationFlags.None); //Create new texture
                RenderTexture.active = renderTexture;
                camera.Render();


                screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0); //Apply pixels from camera onto Texture2D
                screenShot.Apply();
                camera.targetTexture = null;
                RenderTexture.active = null; //Clean
                renderTexture.Release();
                GameObject.Destroy(renderTexture); //Free memory
                texture = screenShot;
            }
        }

        
        public static void Copy(in Texture2D from, out Texture2D to)
        {
            throw new NotImplementedException();
            //to = new Texture2D(from.width, from.height);
            //Graphics.CopyTexture(from, to);
        }

        public static void SetFullBlackToTransparent(ref Texture2D refTexture)
        {
            Color[] c = refTexture.GetPixels();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i].r == 0 && c[i].g == 0 && c[i].b == 0)
                    c[i].a = 0;
            }
            refTexture.SetPixels(c);
            refTexture.Apply();
        }
        public static void SetFullBlackToTransparent(ref Texture2D refTexture, in float thershold=0.01f)
        {
            Color[] c = refTexture.GetPixels();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i].r < thershold && c[i].g < thershold && c[i].b < thershold)
                    c[i].a = 0;
            }
            refTexture.SetPixels(c);
            refTexture.Apply();
        }

        public static void CopyWithRenderer(Texture2D texture, out Texture2D textureCopied)
        {
            // Create a temporary RenderTexture of the same size as the texture
            RenderTexture tmp = RenderTexture.GetTemporary(
                                texture.width,
                                texture.height,
                                0,
                                RenderTextureFormat.Default,
                                RenderTextureReadWrite.Linear);


            // Blit the pixels on texture to the RenderTexture
            Graphics.Blit(texture, tmp);


            // Backup the currently set RenderTexture
            RenderTexture previous = RenderTexture.active;


            // Set the current RenderTexture to the temporary one we created
            RenderTexture.active = tmp;


            // Create a new readable Texture2D to copy the pixels to it
            textureCopied = new Texture2D(texture.width, texture.height);


            // Copy the pixels from the RenderTexture to the new Texture
            textureCopied.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
            textureCopied.Apply();


            // Reset the active RenderTexture
            RenderTexture.active = previous;


            // Release the temporary RenderTexture
            RenderTexture.ReleaseTemporary(tmp);


            // "myTexture2D" now has the same pixels from "texture" and it's re
        }

        public static void Texture2DToRenderTexture(in Texture2D refTexture, out RenderTexture rt)
        {

            rt = new RenderTexture(refTexture.width, refTexture.height, 0);
            rt.enableRandomWrite = true;
                RenderTexture.active = rt;
                Graphics.Blit(refTexture, rt);
        }

        public static void Texture2DInRenderTexture(in Texture2D refTexture, ref RenderTexture rt)
        {
            //rt.enableRandomWrite = true;
            RenderTexture.active = rt;
            Graphics.Blit(refTexture, rt);
        }


        public static void Import(IMetaAbsolutePathFileGet file, out Texture2D texture)
        {
            Eloi.E_FileAndFolderUtility.ImportTexture(file, out texture);
        }

        public static void SetTextureAsBlackAndWhite(in Texture2D target,out Texture2D grayScaleTexture)
        {
            Eloi.E_CodeTag.ToCodeLaterWhenCodeIsReady.Info("Convert image from color to black and white");

            grayScaleTexture = new Texture2D(target.width, target.height);

           Color [] c = target.GetPixels();

            float grayScale;
            for (int i = 0; i < c.Length; i++)
            {

                grayScale = c[i].grayscale;
                c[i] =new Color(grayScale,grayScale,grayScale);
            }
            grayScaleTexture.SetPixels(c);
            grayScaleTexture.Apply();


            //Texture2D grayLayer;
            //Texture2D rgbLayer;
            ////grayTex2d is created grayscale image. rgbTex2d is original color image tested to be still color at this stage

            //grayLayer = new Texture2D(target.width, target.height, target.format, true);
            //Graphics.CopyTexture(target, grayLayer);
            //rgbLayer = new Texture2D(target.width, target.height, target.format, true);
            //Graphics.CopyTexture(target, rgbLayer);

            //grayScaleTExture = new Texture2D(grayLayer.width, grayLayer.height * 2, TextureFormat.ARGB32, false);
            //NativeArray<byte> bytesGrayLayer = grayLayer.GetRawTextureData<byte>();
            //NativeArray<byte> bytesRGBLayer = rgbLayer.GetRawTextureData<byte>();
            //NativeArray<byte> bytesDestinationTexture = grayScaleTExture.GetRawTextureData<byte>();

            //byte srcGray = 0;
            //byte srcRGB = 0;

            //for (int i = 0; i < bytesGrayLayer.Length; i += 4)
            //{
            //    srcGray = (byte)(bytesGrayLayer[i + 1] + bytesGrayLayer[i + 2] + bytesGrayLayer[i + 3]);
            //    srcRGB = (byte)(bytesRGBLayer[i + 1] + bytesRGBLayer[i + 2] + bytesRGBLayer[i + 3]);

            //    bytesDestinationTexture[i + 3] = bytesDestinationTexture[i + 2] = bytesDestinationTexture[i + 1] = srcGray;
            //    bytesDestinationTexture[bytesGrayLayer.Length + i + 3] = bytesDestinationTexture[bytesGrayLayer.Length + i + 2] = bytesDestinationTexture[bytesGrayLayer.Length + i + 1] = srcRGB;
            //}

            //grayScaleTExture.Apply();
            grayScaleTexture = target;
        }

        public static void TextureToTexture2DCopy(Texture2D texture, out Texture2D texture2D)
        {
           
                texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
                RenderTexture currentRT = RenderTexture.active;
                RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
                Graphics.Blit(texture, renderTexture);

                RenderTexture.active = renderTexture;
                texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                texture2D.Apply();

                RenderTexture.active = currentRT;
                RenderTexture.ReleaseTemporary(renderTexture);
            
            
        }

        public static void FlipTextureVertical(in Texture2D original , out Texture newFlipTexture)
        {
            Eloi.E_CodeTag.QualityAssurance.TestedState(E_CodeTag.QualityAssurance.TestedStateType.NotAtAll);
            //Source: https://stackoverflow.com/questions/35950660/unity-180-rotation-for-a-texture2d-or-maybe-flip-both/56494513
            Texture2D flipped = new Texture2D(original.width, original.height);

            int xN = original.width;
            int yN = original.height;


            for (int i = 0; i < xN; i++)
            {
                for (int j = 0; j < yN; j++)
                {
                    
                        flipped.SetPixel(j, xN - i - 1, original.GetPixel(j, i));
                }
            }
            flipped.Apply();

            newFlipTexture = flipped;
        }

        public static void CropTexture2DWithPourcent(in Texture2D textureOrigine, out Texture2D result,
            in float topPct, in float rightPct, in float downPct, in float leftPct, bool mipmap=true)
        {
            int width = textureOrigine.width;
            int height = textureOrigine.height;
            int startHorizontal = (int)(width * (leftPct));
            int startVertical = (int)(height * (downPct));

            int widthNew = (int) (width * (1f - (leftPct + rightPct)));
            int heightNew = (int) (height * (1f - (downPct + topPct)));

            Color [] c=  textureOrigine.GetPixels(startHorizontal, startVertical, widthNew, heightNew);
            result = new Texture2D(widthNew, heightNew, textureOrigine.format, mipmap);
            result.SetPixels(c);
            result.Apply();


        }

        public static void FlipTextureHorizontal(in Texture2D original, out Texture newFlipTexture)
        {
            Eloi.E_CodeTag.QualityAssurance.TestedState(E_CodeTag.QualityAssurance.TestedStateType.NotAtAll);
            //Source: https://stackoverflow.com/questions/35950660/unity-180-rotation-for-a-texture2d-or-maybe-flip-both/56494513

            Texture2D flipped = new Texture2D(original.width, original.height);

            int xN = original.width;
            int yN = original.height;


            for (int i = 0; i < xN; i++)
            {
                for (int j = 0; j < yN; j++)
                {
                        flipped.SetPixel(xN - i - 1, j, original.GetPixel(i, j));
                }
            }
            flipped.Apply();

            newFlipTexture= flipped;
        }

        public static void RenderTextureToTexture2D(in RenderTexture renderTexture , out Texture2D texture)
        {
            texture = new Texture2D(renderTexture.width, renderTexture.height, 
                TextureFormat.RGBA32, true,true); 
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture.Apply();
        }
        public static void RotateTexture(in Texture2D texture, in TextureRotation rotationType, out Texture2D rotatedTexture)
        {
            RotateTexture(in texture, (int)rotationType,out rotatedTexture);
        }
        public static void RotateTexture(in Texture2D originalTexture, in int clockwise, out Texture2D rotatedTexture)
        {
            Eloi.E_CodeTag.QualityAssurance.TestedState(E_CodeTag.QualityAssurance.TestedStateType.NotAtAll);
            Texture2D t = originalTexture;
            for (int i = 0; i < clockwise; i++)
            {
                RotateTexture(in t, clockwise > 0, out t);
            }
            rotatedTexture = t;
        }
        public static void RotateTexture(in Texture2D originalTexture, in bool clockwise, out Texture2D rotatedTexture)
        {//Source: https://answers.unity.com/questions/951835/rotate-the-contents-of-a-texture.html

            Eloi.E_CodeTag.QualityAssurance.TestedState(E_CodeTag.QualityAssurance.TestedStateType.NotAtAll);
            Color32[] original = originalTexture.GetPixels32();
            Color32[] rotated = new Color32[original.Length];
            int w = originalTexture.width;
            int h = originalTexture.height;

            int iRotated, iOriginal;

            for (int j = 0; j < h; ++j)
            {
                for (int i = 0; i < w; ++i)
                {
                    iRotated = (i + 1) * h - j - 1;
                    iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                    rotated[iRotated] = original[iOriginal];
                }
            }

            rotatedTexture = new Texture2D(h, w, TextureFormat.RGBA32, true);
            rotatedTexture.SetPixels32(rotated);
            rotatedTexture.Apply();
        }
    }

}