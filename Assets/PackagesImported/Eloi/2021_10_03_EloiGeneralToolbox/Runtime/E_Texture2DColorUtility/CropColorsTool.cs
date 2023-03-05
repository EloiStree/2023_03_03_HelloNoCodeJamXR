using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class CropColorsTool 
    {


        public static void Crop(ref Color[] source,
            in int sourceWidth, 
            in int sourceHeight, 
            out Color [] result, out int newWidth, out int newHeight) {


            GetCropBorder(ref source,
                in sourceWidth,
                in sourceHeight,
                out int padLeft,
                out int padTop, 
                out int padRight,
                out int padDown);

            int width = padRight - padLeft;
            int height = padDown - padTop;
            int x = padLeft;
            int y = padTop;

            int widthCrop = width;
            int heightCrop = height;


            result = Crop(ref source, sourceWidth, x, y, widthCrop, heightCrop);
            newWidth = widthCrop;
            newHeight = heightCrop;
        }
        public  static Color[] Crop(ref Color[] source, int originalWidth, int x, int y, int widthCrop, int heightCrop)
        {


            Color[] result = new Color[widthCrop * heightCrop];
            for (int sx = 0; sx < widthCrop; sx++)
            {
                for (int sy = 0; sy < heightCrop; sy++)
                {
                    int realIndex = originalWidth * (y + sy) + (x + sx);
                    int resultIndex = widthCrop * sy + sx;
                    result[resultIndex] = source[realIndex];
                }
            }

            return result;
        }
        public static  void GetCropBorder(ref Color[] colors, in int width, in int height, out int padLeft, out int padTop, out int padRight, out int padDown)
        {
            padLeft =0 ;
            padTop = 0;
            padDown = height ;
            padRight = width ;
           
            for (int i = 0; i < height; i++)
            {
                if (IsHorizontalFullBlack(ref colors, in width, in i))
                {
                    padTop = i;
                }
                else break;
            }
            for (int i = height - 1; i > -1; i--)
            {
                if (IsHorizontalFullBlack(ref colors, in width, in i))
                {
                    padDown = i;
                }
                else break;
            }


            for (int i = 0; i < width; i++)
            {
                if (IsVerticalFullBlack(ref colors, in width, in height, in i))
                {
                    padLeft = i;
                }
                else break;
            }
            for (int i = width - 1; i > -1; i--)
            {
                if (IsVerticalFullBlack(ref colors, in width, in height, in i))
                {
                    padRight = i;
                }
                else break;
            }
        }

        public static bool IsHorizontalFullBlack(ref Color[] t, in int width, in int line)
        {
            for (int i = 0; i < width; i++)
            {
                int p = (width * line) + i;
                if (!E_Texture2DColorUtility.IsFullBlackOrTransparent(in t[p]))
                    return false;
            }
            return true;
        }
        public static bool IsVerticalFullBlack(ref Color[] t, in int width, in int height, in int column)
        {
            for (int i = 0; i < height; i++)
            {
                int p = column + width * i;
                if (!E_Texture2DColorUtility.IsFullBlackOrTransparent(in t[p]))
                    return false;
            }
            return true;
        }
       
    }
}
