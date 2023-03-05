using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_ColorUtility : MonoBehaviour
    {

        public static bool IsAlmostEqual(in Color a, in Color b, in float minPourcent) {

            return
                Mathf.Abs(a.r - b.r) < Mathf.Abs(minPourcent) &&
                Mathf.Abs(a.g - b.g) < Mathf.Abs(minPourcent) &&
                Mathf.Abs(a.b - b.b) < Mathf.Abs(minPourcent);
        
        }

        public static class RGBCodesChart
        {
            public static Color Black = new Color(0, 0, 0);
            public static Color White = new Color(255, 255, 255);
            public static Color Red = new Color(255, 0, 0);
            public static Color Lime = new Color(0, 255, 0);
            public static Color Blue = new Color(0, 0, 255);
            public static Color Yellow = new Color(255, 255, 0);
            public static Color Cyan_Aqua = new Color(0, 255, 255);
            public static Color Magenta_Fuchsia = new Color(255, 0, 255);
            public static Color Silver = new Color(192, 192, 192);
            public static Color Gray = new Color(128, 128, 128);
            public static Color Maroon = new Color(128, 0, 0);
            public static Color Olive = new Color(128, 128, 0);
            public static Color Green = new Color(0, 128, 0);
            public static Color Purple = new Color(128, 0, 128);
            public static Color Teal = new Color(0, 128, 128);
            public static Color Navy = new Color(0, 0, 128);
            public static Color maroon = new Color(128, 0, 0);
            public static Color darkred = new Color(139, 0, 0);
            public static Color brown = new Color(165, 42, 42);
            public static Color firebrick = new Color(178, 34, 34);
            public static Color crimson = new Color(220, 20, 60);
            public static Color red = new Color(255, 0, 0);
            public static Color tomato = new Color(255, 99, 71);
            public static Color coral = new Color(255, 127, 80);
            public static Color indianred = new Color(205, 92, 92);
            public static Color lightcoral = new Color(240, 128, 128);
            public static Color darksalmon = new Color(233, 150, 122);
            public static Color salmon = new Color(250, 128, 114);
            public static Color lightsalmon = new Color(255, 160, 122);
            public static Color orangered = new Color(255, 69, 0);
            public static Color darkorange = new Color(255, 140, 0);
            public static Color orange = new Color(255, 165, 0);
            public static Color gold = new Color(255, 215, 0);
            public static Color darkgoldenrod = new Color(184, 134, 11);
            public static Color goldenrod = new Color(218, 165, 32);
            public static Color palegoldenrod = new Color(238, 232, 170);
            public static Color darkkhaki = new Color(189, 183, 107);
            public static Color khaki = new Color(240, 230, 140);
            public static Color olive = new Color(128, 128, 0);
            public static Color yellow = new Color(255, 255, 0);
            public static Color yellowgreen = new Color(154, 205, 50);
            public static Color darkolivegreen = new Color(85, 107, 47);
            public static Color olivedrab = new Color(107, 142, 35);
            public static Color lawngreen = new Color(124, 252, 0);
            public static Color chartreuse = new Color(127, 255, 0);
            public static Color greenyellow = new Color(173, 255, 47);
            public static Color darkgreen = new Color(0, 100, 0);
            public static Color green = new Color(0, 128, 0);
            public static Color forestgreen = new Color(34, 139, 34);
            public static Color lime = new Color(0, 255, 0);
            public static Color limegreen = new Color(50, 205, 50);
            public static Color lightgreen = new Color(144, 238, 144);
            public static Color palegreen = new Color(152, 251, 152);
            public static Color darkseagreen = new Color(143, 188, 143);
            public static Color mediumspringgreen = new Color(0, 250, 154);
            public static Color springgreen = new Color(0, 255, 127);
            public static Color seagreen = new Color(46, 139, 87);
            public static Color mediumaquamarine = new Color(102, 205, 170);
            public static Color mediumseagreen = new Color(60, 179, 113);
            public static Color lightseagreen = new Color(32, 178, 170);
            public static Color darkslategray = new Color(47, 79, 79);
            public static Color teal = new Color(0, 128, 128);
            public static Color darkcyan = new Color(0, 139, 139);
            public static Color aqua = new Color(0, 255, 255);
            public static Color cyan = new Color(0, 255, 255);
            public static Color lightcyan = new Color(224, 255, 255);
            public static Color darkturquoise = new Color(0, 206, 209);
            public static Color turquoise = new Color(64, 224, 208);
            public static Color mediumturquoise = new Color(72, 209, 204);
            public static Color paleturquoise = new Color(175, 238, 238);
            public static Color aquamarine = new Color(127, 255, 212);
            public static Color powderblue = new Color(176, 224, 230);
            public static Color cadetblue = new Color(95, 158, 160);
            public static Color steelblue = new Color(70, 130, 180);
            public static Color cornflowerblue = new Color(100, 149, 237);
            public static Color deepskyblue = new Color(0, 191, 255);
            public static Color dodgerblue = new Color(30, 144, 255);
            public static Color lightblue = new Color(173, 216, 230);
            public static Color skyblue = new Color(135, 206, 235);
            public static Color lightskyblue = new Color(135, 206, 250);
            public static Color midnightblue = new Color(25, 25, 112);
            public static Color navy = new Color(0, 0, 128);
            public static Color darkblue = new Color(0, 0, 139);
            public static Color mediumblue = new Color(0, 0, 205);
            public static Color blue = new Color(0, 0, 255);
            public static Color royalblue = new Color(65, 105, 225);
            public static Color blueviolet = new Color(138, 43, 226);
            public static Color indigo = new Color(75, 0, 130);
            public static Color darkslateblue = new Color(72, 61, 139);
            public static Color slateblue = new Color(106, 90, 205);
            public static Color mediumslateblue = new Color(123, 104, 238);
            public static Color mediumpurple = new Color(147, 112, 219);
            public static Color darkmagenta = new Color(139, 0, 139);
            public static Color darkviolet = new Color(148, 0, 211);
            public static Color darkorchid = new Color(153, 50, 204);
            public static Color mediumorchid = new Color(186, 85, 211);
            public static Color purple = new Color(128, 0, 128);
            public static Color thistle = new Color(216, 191, 216);
            public static Color plum = new Color(221, 160, 221);
            public static Color violet = new Color(238, 130, 238);
            public static Color magenta_fuchsia = new Color(255, 0, 255);
            public static Color orchid = new Color(218, 112, 214);
            public static Color mediumvioletred = new Color(199, 21, 133);
            public static Color palevioletred = new Color(219, 112, 147);
            public static Color deeppink = new Color(255, 20, 147);
            public static Color hotpink = new Color(255, 105, 180);
            public static Color lightpink = new Color(255, 182, 193);
            public static Color pink = new Color(255, 192, 203);
            public static Color antiquewhite = new Color(250, 235, 215);
            public static Color beige = new Color(245, 245, 220);
            public static Color bisque = new Color(255, 228, 196);
            public static Color blanchedalmond = new Color(255, 235, 205);
            public static Color wheat = new Color(245, 222, 179);
            public static Color cornsilk = new Color(255, 248, 220);
            public static Color lemonchiffon = new Color(255, 250, 205);
            public static Color lightgoldenrodyellow = new Color(250, 250, 210);
            public static Color lightyellow = new Color(255, 255, 224);
            public static Color saddlebrown = new Color(139, 69, 19);
            public static Color sienna = new Color(160, 82, 45);
            public static Color chocolate = new Color(210, 105, 30);
            public static Color peru = new Color(205, 133, 63);
            public static Color sandybrown = new Color(244, 164, 96);
            public static Color burlywood = new Color(222, 184, 135);
            public static Color tan = new Color(210, 180, 140);
            public static Color rosybrown = new Color(188, 143, 143);
            public static Color moccasin = new Color(255, 228, 181);
            public static Color navajowhite = new Color(255, 222, 173);
            public static Color peachpuff = new Color(255, 218, 185);
            public static Color mistyrose = new Color(255, 228, 225);
            public static Color lavenderblush = new Color(255, 240, 245);
            public static Color linen = new Color(250, 240, 230);
            public static Color oldlace = new Color(253, 245, 230);
            public static Color papayawhip = new Color(255, 239, 213);
            public static Color seashell = new Color(255, 245, 238);
            public static Color mintcream = new Color(245, 255, 250);
            public static Color slategray = new Color(112, 128, 144);
            public static Color lightslategray = new Color(119, 136, 153);
            public static Color lightsteelblue = new Color(176, 196, 222);
            public static Color lavender = new Color(230, 230, 250);
            public static Color floralwhite = new Color(255, 250, 240);
            public static Color aliceblue = new Color(240, 248, 255);
            public static Color ghostwhite = new Color(248, 248, 255);
            public static Color honeydew = new Color(240, 255, 240);
            public static Color ivory = new Color(255, 255, 240);
            public static Color azure = new Color(240, 255, 255);
            public static Color snow = new Color(255, 250, 250);
            public static Color black = new Color(0, 0, 0);
            public static Color dimgray_dimgrey = new Color(105, 105, 105);
            public static Color gray_grey = new Color(128, 128, 128);
            public static Color darkgray_darkgrey = new Color(169, 169, 169);
            public static Color silver = new Color(192, 192, 192);
            public static Color lightgray_lightgrey = new Color(211, 211, 211);
            public static Color gainsboro = new Color(220, 220, 220);
            public static Color whitesmoke = new Color(245, 245, 245);
            public static Color white = new Color(255, 255, 255);



        }

        public static void ConvertHashFFFFFFFFToColor(in string text, out bool converted, out Color color)
        {
            color = new Color();
            int indexStart = 0;
            if (text[0] == '#')
                indexStart = 1;

            if (text.Length >= 6 + indexStart)
            {
                Eloi.E_StringUtility.ConvertHexaToInt(text.Substring(indexStart, 2), out byte r);
                color.r = r / 255f;
                Eloi.E_StringUtility.ConvertHexaToInt(text.Substring(indexStart + 2, 2), out byte g);
                color.g = g / 255f;
                Eloi.E_StringUtility.ConvertHexaToInt(text.Substring(indexStart + 4, 2), out byte b);
                color.b = b / 255f;
                if (text.Length >= 8 + indexStart)
                {
                    Eloi.E_StringUtility.ConvertHexaToInt(text.Substring(indexStart + 6, 2), out byte a);
                    color.a = a / 255f;
                }
                converted = true;
                return;
            }
            converted = false;
        }
        public static void ConvertFromSplitTextToColor(in string text,  out bool converted, out Color color, in char spliter=':')
        {
            color = new Color();
            string[] tokens = text.Split(spliter);
            if (tokens.Length < 3)
            { 
                converted = false;
                return;
            }
            for (int i = 0; i < 4 ; i++)
            {
                if (i < tokens.Length)
                {
                    if (i == 0) if (!float.TryParse(tokens[i], out color.r)) color.r = 0; 
                    if (i == 1) if (!float.TryParse(tokens[i], out color.g)) color.g = 0; 
                    if (i == 2) if (!float.TryParse(tokens[i], out color.b)) color.b = 0; 
                    if (i == 3) if (!float.TryParse(tokens[i], out color.a)) color.a = 1;
                }
            }
            converted = true;
        }
    }
}