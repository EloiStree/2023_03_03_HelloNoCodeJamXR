using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_StringCompression 
    {

        public static void FloatToString(in float value, in int maxLeft, in int maxRight, out string asText)
        {
            Eloi.E_CodeTag.DirtyCode.Info("Bad way to do but good enough for now");
            string t = ".";
            for (int i = 0; i < maxLeft; i++)
            {
                t = "0" + t;
            }
            for (int i = 0; i < maxRight; i++)
            {
                t = t + "0";
            }
            asText = string.Format("{0:" + t + "}", value);
        }
        public static void Vector3ToString(in Vector3 value, in int maxLeft, in int maxRight, out string asText)
        {
            FloatToString(value.x, in maxLeft, in maxRight, out string x);
            FloatToString(value.y, in maxLeft, in maxRight, out string y);
            FloatToString(value.z, in maxLeft, in maxRight, out string z);
            asText = x + ":" + y + ":" + z ;
        }

        public static void StringToVector3(in string text, out Vector3 acceleration)
        {
            acceleration = new Vector3();
            string[] tokens = text.Split(':');
            if (tokens.Length >= 1)
                float.TryParse(tokens[0], out acceleration.x);
            if (tokens.Length >= 2)
                float.TryParse(tokens[1], out acceleration.y);
            if (tokens.Length >= 3)
                float.TryParse(tokens[2], out acceleration.z);
        }
        public static void StringToFloat(in string text, out float compassMagneticHeading)
        {
            float.TryParse(text, out compassMagneticHeading);
        }
    }
}
