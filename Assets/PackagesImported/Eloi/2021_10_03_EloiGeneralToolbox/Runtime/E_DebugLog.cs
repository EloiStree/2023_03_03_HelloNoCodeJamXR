using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi { 
public class E_DebugLog
    {
        public static void Format(in string info = "", params object[] parameters) => DisplaySmallText( in info, parameters);
        public static void A(in string info="", params object[] parameters) => DisplaySmallText("A", in info, parameters);
        public static void B(in string info="", params object[] parameters) => DisplaySmallText("B", in info, parameters);
        public static void C(in string info="", params object[] parameters) => DisplaySmallText("C", in info, parameters);
        public static void D(in string info="", params object[] parameters) => DisplaySmallText("D", in info, parameters);

        public static void NowLog(string debugText, string nowFormat="hh:mm ss fff")
        {
            Debug.Log(string.Format(debugText, DateTime.Now.ToString(nowFormat)));
        }

        public static void E(in string info="", params object[] parameters) => DisplaySmallText("E", in info, parameters);
        public static void F(in string info="", params object[] parameters) => DisplaySmallText("F", in info, parameters);
        public static void G(in string info="", params object[] parameters) => DisplaySmallText("G", in info, parameters);
        public static void H(in string info="", params object[] parameters) => DisplaySmallText("H", in info, parameters);
        public static void I(in string info="", params object[] parameters) => DisplaySmallText("I", in info, parameters);
        public static void J(in string info="", params object[] parameters) => DisplaySmallText("J", in info, parameters);
        public static void K(in string info="", params object[] parameters) => DisplaySmallText("K", in info, parameters);
        public static void L(in string info="", params object[] parameters) => DisplaySmallText("L", in info, parameters);
        public static void M(in string info="", params object[] parameters) => DisplaySmallText("M", in info, parameters);
        public static void N(in string info="", params object[] parameters) => DisplaySmallText("N", in info, parameters);
        public static void O(in string info="", params object[] parameters) => DisplaySmallText("O", in info, parameters);
        public static void P(in string info="", params object[] parameters) => DisplaySmallText("P", in info, parameters);
        public static void Q(in string info="", params object[] parameters) => DisplaySmallText("Q", in info, parameters);
        public static void R(in string info="", params object[] parameters) => DisplaySmallText("R", in info, parameters);
        public static void S(in string info="", params object[] parameters) => DisplaySmallText("S", in info, parameters);
        public static void T(in string info="", params object[] parameters) => DisplaySmallText("T", in info, parameters);
        public static void U(in string info="", params object[] parameters) => DisplaySmallText("U", in info, parameters);
        public static void X(in string info="", params object[] parameters) => DisplaySmallText("X", in info, parameters);
        public static void W(in string info="", params object[] parameters) => DisplaySmallText("W", in info, parameters);
        public static void Y(in string info="", params object[] parameters) => DisplaySmallText("Y", in info, parameters);
        public static void Z(in string info="", params object[] parameters) => DisplaySmallText("Z", in info,  parameters);
        public static void _0(in string info="", params object[] parameters) => DisplaySmallText("0", in info, parameters);
        public static void _1(in string info="", params object[] parameters) => DisplaySmallText("1", in info, parameters);
        public static void _2(in string info="", params object[] parameters) => DisplaySmallText("2", in info, parameters);
        public static void _3(in string info="", params object[] parameters) => DisplaySmallText("3", in info, parameters);
        public static void _4(in string info="", params object[] parameters) => DisplaySmallText("4", in info, parameters);
        public static void _5(in string info="", params object[] parameters) => DisplaySmallText("5", in info, parameters);
        public static void _6(in string info="", params object[] parameters) => DisplaySmallText("6", in info, parameters);
        public static void _7(in string info="", params object[] parameters) => DisplaySmallText("7", in info, parameters);
        public static void _8(in string info="", params object[] parameters) => DisplaySmallText("8", in info, parameters);
        public static void _9(in string info="", params object[] parameters) => DisplaySmallText("9", in info, parameters);

        private static void DisplaySmallText(in string charText, in string info, params object[] parameters)
        {
            if (E_StringUtility.IsNullOrEmpty(in info))
            { 
                 Debug.Log(charText);
            }
            else if (parameters == null || parameters.Length <= 0) { 
                Debug.Log(charText + ": " + info);
            }
            else {
                try
                {
                    Debug.Log(string.Format(charText + ": " + info, parameters));
                }
                catch (Exception e)
                {
                    Debug.Log("/!\\ format exception:"+charText + ": " + info + " | " + string.Join(" - ",parameters));
                }
            
            }
        }
        private static void DisplaySmallText( in string info, params object[] parameters)
        {
            if (parameters == null || parameters.Length <= 0) { 
                Debug.Log( info);
            }
             else
            {
                try
                {
                    Debug.Log(string.Format( info, parameters));
                }
                catch (Exception e)
                {
                    Debug.Log("/!\\ format exception: " + info + " | " + string.Join(" - ", parameters));
                }

            }
        }
    }
}
