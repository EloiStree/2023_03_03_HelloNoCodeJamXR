using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Eloi
{
    public class E_EnumUtility
    {

        public static void GetAllEnumOf<T>(out IEnumerable<T> list)
        {
            list = Enum.GetValues(typeof(T)).Cast<T>();

        }
        public static void GetAllEnumOf<T>(out T[] list)
        {
            GetAllEnumOf(out IEnumerable<T> l);
            list = l.ToArray();
        }

        public static void Count<T>(out int noteCount)
        {
            noteCount = Enum.GetValues(typeof(T)).Length;
        }

        public static void GetAllEnumOf<T>(out List<T> list)
        {
            GetAllEnumOf(out IEnumerable<T> l);
            list = l.ToList();
        }

        public enum LeftRightEnum
        { Left, Right }
        public enum LeftRightMidEnum
        { Left, Middle, Right }
        public enum TopDownEnum
        { Top, Down }


        public enum PressionTypeEnum
        { Press,Release }
    }
}