using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Eloi
{

    public static class E_CacheBin
    {

        public static bool _bool;
        public static int _int;
        public static float _float;
        public static double _double;
        public static object _object;
    }
    public static class E_ClassicPrimitive
    {
        public readonly static string _empty = "";
        public readonly static bool _true = true;
        public readonly static bool _false = false;
        public readonly static float _n1f = -1;
        public readonly static float _0f = 0;
        public readonly static float _p1f = 1;
    }

    public static class E_ClassicUnityStatic
    {

        public readonly static Vector3 _zero = Vector3.zero;
        public readonly static Vector3 _left = Vector3.left;
        public readonly static Vector3 _up = Vector3.up;
        public readonly static Vector3 _forward = Vector3.forward;
        public readonly static Quaternion _identity = Quaternion.identity;


    }
}
