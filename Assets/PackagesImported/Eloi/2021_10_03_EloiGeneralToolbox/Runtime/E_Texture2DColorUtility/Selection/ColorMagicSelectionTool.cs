using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class ColorMagicSelectionTool 
    {

        private static void GetNeibourght(in int index1D, in int width, out PixelPointDL2TR[] nearIndex)
        {
            PixelPointDL2TR p = new PixelPointDL2TR(0, 0);
            p.Set1D(in index1D, in width);
            nearIndex = new PixelPointDL2TR[] {
            new PixelPointDL2TR(p.m_x-1, p.m_y-1),
            new PixelPointDL2TR(p.m_x , p.m_y - 1),
            new PixelPointDL2TR(p.m_x + 1, p.m_y - 1),

            new PixelPointDL2TR(p.m_x-1, p.m_y+1),
            new PixelPointDL2TR(p.m_x , p.m_y + 1),
            new PixelPointDL2TR(p.m_x + 1, p.m_y + 1),

            new PixelPointDL2TR(p.m_x-1, p.m_y),
            new PixelPointDL2TR(p.m_x + 1, p.m_y )};
        }

        static PixelPointDL2TR p = new PixelPointDL2TR(0, 0);
        static PixelPointDL2TR[] p4 = new PixelPointDL2TR[] {
            new PixelPointDL2TR(0,0),
            new PixelPointDL2TR(0,0),
            new PixelPointDL2TR(0,0),
            new PixelPointDL2TR(0,0)};
        private static void GetNeibourghtCross(in int index1D, in int width, ref PixelPointDL2TR[] nearIndex)
        {
            p.Set1D(in index1D, in width);
            p4[0].Set(p.m_x, p.m_y - 1);
            p4[1].Set(p.m_x, p.m_y + 1);
            p4[2].Set(p.m_x - 1, p.m_y);
            p4[3].Set(p.m_x + 1, p.m_y);
        }
        private static void GetNeibourghtCrossCreated(in int index1D, in int width, out PixelPointDL2TR[] nearIndex)
        {
            p.Set1D(in index1D, in width);
            nearIndex = new PixelPointDL2TR[] {
            new PixelPointDL2TR(p.m_x, p.m_y - 1),
            new PixelPointDL2TR(p.m_x, p.m_y + 1),
            new PixelPointDL2TR(p.m_x - 1, p.m_y),
            new PixelPointDL2TR(p.m_x + 1, p.m_y)};
        }
       


        public delegate void KeepCondition(in Color[] colors, in int index, ref bool keep);
        private static void IsBlackOrTransparent(in Color[] colors, in int index, ref bool isValide)
        {
            isValide = index > -1 && index < colors.Length && ((colors[index].r <= 0.01f && colors[index].g <= 0.01 && colors[index].b <= 0.01) || colors[index].a <= 0.01);
        }
        private static void IsWhite(in Color[] colors, in int index, ref bool isValide)
        {
            isValide = index > -1 && index < colors.Length && ((colors[index].r > 0.99f && colors[index].g > 0.99f && colors[index].b > 0.99f));
        }
        public static void SelectBlackOrTransparentIndex(in Color[] t, in int width, in PixelPointDL2TR[] points, out List<int> indexLinked)
        {
            SelectColorsIndex(in t, in width, points, out indexLinked, IsBlackOrTransparent);
        }
        public static void SelectWhiteIndex(in Color[] t, in int width, in PixelPointDL2TR[] points, out List<int> indexLinked)
        {
            SelectColorsIndex(in t, in width, points, out indexLinked, IsWhite);
        }

        public static void IsBetween(in Color color, in float threshole) { 
        
        }


        public static  void SelectColorsIndex(in Color[] t, in int width, in PixelPointDL2TR[] points, out List<int> indexLinked, KeepCondition keepCondition)
        {
            if (keepCondition == null)
                keepCondition += IsBlackOrTransparent;
            bool[] alreadyIn = new bool[t.Length];
            indexLinked = new List<int>();
            Queue<int> toExplore = new Queue<int>();

            int index = 0;
            for (int i = 0; i < points.Length; i++)
            {
                index = points[i].Get1D(in width);
                toExplore.Enqueue(index);
            }

            int antiLoop = t.Length * 2;
            int iteration = 0;
            while (toExplore.Count > 0)
            {
                index = toExplore.Dequeue();
                iteration++;
                bool explore = false;
                keepCondition(in t, in index, ref explore);
                if (explore && !alreadyIn[index])
                {
                    alreadyIn[index] = true;
                    indexLinked.Add(index);
                    GetNeibourghtCrossCreated(in index, in width, out PixelPointDL2TR[] nextIndex);
                    for (int ij = 0; ij < nextIndex.Length; ij++)
                    {
                        int a = nextIndex[ij].Get1D(in width);
                        if (a >= 0 && a < t.Length && !alreadyIn[a])
                            toExplore.Enqueue(a);
                    }
                }
                antiLoop--;
                if (antiLoop < 0)
                {
                    Debug.Log("Antiloop used");
                    return;
                }

            }

        }
    }
}
[System.Serializable]
public struct ColorObserved
{
    public Color m_colorTarget;
    [Range(0, 1)]
    public float m_threshole;
}