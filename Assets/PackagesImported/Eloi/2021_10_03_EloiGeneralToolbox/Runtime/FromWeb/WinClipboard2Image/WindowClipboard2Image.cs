using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Eloi {
    //Credit to :NullTale https://github.com/NullTale/
    //Source: https://github.com/NullTale/UnityClipboardImage
    public static class WindowClipboard2Image
{
    [DllImport("UnityClipboard")] private static extern bool Open();
    [DllImport("UnityClipboard")] private static extern int Width();
    [DllImport("UnityClipboard")] private static extern int Height();
    [DllImport("UnityClipboard")] private static extern int BitsPerPixel();
    [DllImport("UnityClipboard")] private static extern IntPtr Read();

        public static bool IsThereImageAvailable() {
            return Open();
        }

        public static int GetTextureWidth()
        {
            return Width();
        }
        public static int GetTextureHeight()
        {
            return Height();
        }
        public static void GetDimension(out int widthInPixel, out int heightInPixel) {
            widthInPixel = Width();
            heightInPixel = Height();
        }
        public static void GetImagePointer(out IntPtr pointer) { pointer = Read(); }
        public static void GetImagePointerAsIntId(out int pointer) { pointer = (int)Read(); }
        public static IntPtr GetImagePointer() { return Read(); }
        public static int GetImagePointerAsIntId() { return (int)Read(); }

        public static Texture2D Copy()
        {
            try
            {
                if (!IsThereImageAvailable())
                    return null;
            
                var width  = Width();
                var height = Height();
                var step   = BitsPerPixel() / 8;
                var ptr    = Read();
            
                var tex = new Texture2D(width, height, GraphicsFormat.R8G8B8A8_SRGB, 0, TextureCreationFlags.None);
            
                var bytes = new byte[width * height * step];
                Marshal.Copy(ptr, bytes, 0, width * height * step);
            
                for (var y = 0; y < height; y++)
                for (var x = 0; x < width; x++)
                {
                    var pos = (y * width + x) * 4;
                
                    // read in bgra format
                    var b = bytes[pos];
                    var g = bytes[pos + 1];
                    var r = bytes[pos + 2];
                    var a = bytes[pos + 3];
                
                    tex.SetPixel(x, height - y, new Color32(r, g, b, a));
                }

                tex.Apply();
                return tex;
            }
            catch (Exception e)
            {
                Debug.LogError($"Can't past image from clipboard {e}");
            }
        
            return null;
        }
    }
}