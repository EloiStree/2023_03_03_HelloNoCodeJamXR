using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PixelPointDL2TR
{
    public int m_x;
    public int m_y;



    public PixelPointDL2TR(int x, int y)
    {
        m_x = x;
        m_y = y;
    }
    public PixelPointDL2TR(PixelPointDL2TR source)
    {
        m_x = source.m_x;
        m_y = source.m_y;
    }



    public int Get1D(in int arrayWidth)
    {
        return arrayWidth * m_y + m_x;
    }
    public void Set1D(in int index, in int width)
    {
        m_x = index % width;
        m_y = (int)(index / (float)width);
    }
    public void Set(int x, int y)
    {
        m_x = x;
        m_y = y;
    }

    public void Set(in PixelPointDL2TR point)
    {
        m_x = point.m_x;
        m_y = point.m_y;
    }
}
public class PixelPointUtility
{
    public static void GetRightOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_x += 1;
    }
    public static void GetLeftOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_x -= 1;
    }
    public static void GetDownOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_y -= 1;
    }
    public static void GetUpOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_y += 1;
    }

    public static bool IsInRange(in PixelPointDL2TR focus, in int width2D, in int width1D )
    {
        int i = focus.Get1D(in width2D);
        return i > -1 && i < width1D;
    }

    public static bool IsTransparent(in Color[] colors, in int width2D, in PixelPointDL2TR focus)
    {
        int index = focus.Get1D(width2D);
        return colors[index].a <= 0f;
    }
    public static bool IsTransparent(in Color[] colors, in int width2D, in PixelPointDL2TR focus, float theshold=0.01f)
    {
        int index = focus.Get1D(width2D);
        return colors[index].a <= theshold;
    }

    public static void GetTopLeftOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_x -= 1;
        nextPoint.m_y += 1;
    }

    public static void GetTopRightOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_x += 1;
        nextPoint.m_y += 1;
    }

    public static void GetDownLeftOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_x -= 1;
        nextPoint.m_y += 1;
    }

    public static void GetUpRightOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_x += 1;
        nextPoint.m_y += 1;
    }
}