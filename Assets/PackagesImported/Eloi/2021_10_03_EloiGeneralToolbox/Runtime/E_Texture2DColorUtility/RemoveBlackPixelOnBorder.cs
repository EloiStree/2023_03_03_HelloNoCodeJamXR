using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{

    public class RemoveBlackPixelOnBorder
    {

        public static void Filter(in Color[] from, in int width, ref bool[] isPixelTransparent)
        {
            if (from.Length == 0)
            {
                Debug.LogWarning("Color should not be length of 0");
                return;
            }

            int width1D = from.Length;
            if (isPixelTransparent == null)
                isPixelTransparent = new bool[from.Length];
            PixelPointDL2TR focus = new PixelPointDL2TR(0, 0);
            PixelPointDL2TR tempFocus = new PixelPointDL2TR(0, 0);
            bool isOutRange;

            for (int i = 0; i < from.Length; i++)
            {
                if (isPixelTransparent[i])
                    continue;

                focus.Set1D(in i, in width);
                if (PixelPointUtility.IsTransparent(in from, in width, in focus))
                {
                    //blackWhiteMask[i]=false;
                    continue;
                }
                PixelPointUtility.GetLeftOf(in focus, ref tempFocus);
                if (PixelPointUtility.IsInRange(in tempFocus, in width ,in width1D) && PixelPointUtility.IsTransparent(in from, in width, in tempFocus))
                {
                    isPixelTransparent[i] = true;
                    continue;
                }
                PixelPointUtility.GetRightOf(in focus, ref tempFocus);
                if (PixelPointUtility.IsInRange(in tempFocus, in width, in width1D) && PixelPointUtility.IsTransparent(in from, in width, in tempFocus))
                {
                    isPixelTransparent[i] = true;
                    continue;
                }
                PixelPointUtility.GetDownOf(in focus, ref tempFocus);
                if (PixelPointUtility.IsInRange(in tempFocus, in width, in width1D)   &&    PixelPointUtility.IsTransparent(in from, in width, in tempFocus))
                {
                    isPixelTransparent[i] = true;
                    continue;
                }
                PixelPointUtility.GetUpOf(in focus, ref tempFocus);
                if (PixelPointUtility.IsInRange(in tempFocus, in width, in width1D) && PixelPointUtility.IsTransparent(in from, in width, in tempFocus))
                {
                    isPixelTransparent[i] = true;
                    continue;
                }




                PixelPointUtility.GetTopLeftOf(in focus, ref tempFocus);
                if (PixelPointUtility.IsInRange(in tempFocus, in width, in width1D) && PixelPointUtility.IsTransparent(in from, in width, in tempFocus))
                {
                    isPixelTransparent[i] = true;
                    continue;
                }
                PixelPointUtility.GetTopRightOf(in focus, ref tempFocus);
                if (PixelPointUtility.IsInRange(in tempFocus, in width, in width1D) && PixelPointUtility.IsTransparent(in from, in width, in tempFocus))
                {
                    isPixelTransparent[i] = true;
                    continue;
                }
                PixelPointUtility.GetDownLeftOf(in focus, ref tempFocus);
                if (PixelPointUtility.IsInRange(in tempFocus, in width, in width1D) && PixelPointUtility.IsTransparent(in from, in width, in tempFocus))
                {
                    isPixelTransparent[i] = true;
                    continue;
                }
                PixelPointUtility.GetUpRightOf(in focus, ref tempFocus);
                if (PixelPointUtility.IsInRange(in tempFocus, in width, in width1D) && PixelPointUtility.IsTransparent(in from, in width, in tempFocus))
                {
                    isPixelTransparent[i] = true;
                    continue;
                }
            }
        }

        public static void Remove(in bool[] from, ref Color[] toAffect, in Color replaceColor)
        {
            for (int i = 0; i < from.Length; i++)
            {
                if (from[i])
                    toAffect[i] = replaceColor;
            }
        }

        public static void SetAsTransparent(in bool[] mask, ref Color[] toAffect, float alpha)
        {
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i])
                    toAffect[i] *= alpha;
            }
        }
    }
}
