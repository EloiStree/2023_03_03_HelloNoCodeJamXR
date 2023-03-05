using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Eloi { 

    public class E_UnityRandomUtility 
    {

        public static void GetRandomEuler(out Vector3 random)
        {
            random = new Vector3();
            GetRandom_n180_180(out random.x);
            GetRandom_n180_180(out random.y);
            GetRandom_n180_180(out random.z);
        }
        public static void GetRandomVector3Direction(out Vector3 random)
        {
            random = new Vector3(UnityEngine.Random.Range(-1f,1f)
                , UnityEngine.Random.Range(-1f, 1f)
                , UnityEngine.Random.Range(-1f, 1f) );
        }

        public static void GetRandomTexture(out Texture2D randomTexture, int width, int height)
        {
            randomTexture = new Texture2D(width, height,TextureFormat.ARGB32,true);
            Color[] c = new Color[width * height];

            for (int i = 0; i < c.Length; i++)
            {
                GetRandomColor(1, out Color color);
                c[i] = color;
            }
            randomTexture.SetPixels(c);
            randomTexture.Apply();
        }

      

        public static void GetRandomColor(float alphaPourcent, out Color color)
        {
            GetRandom_0_1(out float r);
            GetRandom_0_1(out float g);
            GetRandom_0_1(out float b);
            color = new Color(r, g, b, alphaPourcent);
        }
        public static void GetRandomColor(out Color color)
        {
            GetRandom_0_1(out float r);
            GetRandom_0_1(out float g);
            GetRandom_0_1(out float b);
            GetRandom_0_1(out float a);
            color = new Color(r, g, b, a);
        }

        public static void GetRandomGUID(out string id)
        {
            id =Guid.NewGuid().ToString();
        }

        public static void GetRandomQuaternion(out Quaternion random)
        {
               GetRandomEuler(out Vector3 euleur);
               random = Quaternion.Euler(euleur);
        }

        public static void GetRandomBool(out bool value)
        {
            value = UnityEngine.Random.value <0.5f;
        }

        public static void GetRandomPositionInTransform(in Transform zoneReference, out Vector3 position, Space scaleType = Space.World)
        {
            ////Old version
            //Vector3 scale = scaleType==Space.World? zoneReference.lossyScale: zoneReference.localScale;
            //GetRandomVector3Direction(out Vector3 direction);
            //direction.x *= scale.x / 2f;
            //direction.y *= scale.y / 2f;
            //direction.z *= scale.z / 2f;
            //direction = zoneReference.rotation * direction;
            //position = zoneReference.position + direction;
            Vector3 scale = scaleType == Space.World ? zoneReference.lossyScale : zoneReference.localScale;
            Vector3 localPoint = Vector3.zero;
            localPoint.x = UnityEngine.Random.Range(-scale.x / 2f, scale.x / 2f);
            localPoint.y = UnityEngine.Random.Range(-scale.y / 2f, scale.y / 2f);
            localPoint.z = UnityEngine.Random.Range(-scale.z / 2f, scale.z / 2f);
            Eloi.E_RelocationUtility.GetLocalToWorld_Point(in localPoint, in zoneReference, out position);
        }
        public enum SquareFace:int { Left, Right, Up, Down, Front, Back }

        public static void GetRandomPositionInTransformWalls(in Transform zoneReference, out Vector3 position, Space scaleType = Space.World)
        {
            
            Vector3 scale = scaleType == Space.World ? zoneReference.lossyScale : zoneReference.localScale;
            Vector3 localPoint = Vector3.zero;
            scale /= 2f;

            localPoint.x = UnityEngine.Random.Range(-scale.x , scale.x );
            localPoint.y = UnityEngine.Random.Range(-scale.y , scale.y);
            localPoint.z = UnityEngine.Random.Range(-scale.z, scale.z );
            GetRandomN2M(0, 5, out int r);
            switch ((SquareFace)r)
            {
                case SquareFace.Left:

                    localPoint.x = -scale.x  ;
                    break;
                case SquareFace.Right:
                    localPoint.x =  scale.x ;
                    break;
                case SquareFace.Up:
                    localPoint.y = scale.y ;
                    break;
                case SquareFace.Down:
                    localPoint.y = -scale.y ;
                    break;
                case SquareFace.Front:
                    localPoint.z = -scale.z;
                    break;
                case SquareFace.Back:
                    localPoint.z = scale.z;
                    break;
                default:
                    break;
            }

            Eloi.E_RelocationUtility.GetLocalToWorld_Point(in localPoint, in zoneReference, out position);
        }

        private static bool R_Bool()
        {
            return randomSeed.Next() % 2 == 0;
        }

        public static void GetRandomDirectionNormalized(out Vector3 random)
        {
            random = new Vector3();
            GetRandom_n1_1(out random.x);
            GetRandom_n1_1(out random.y);
            GetRandom_n1_1(out random.z);
        }

        public static void GetRandomStringFrom(in string value, int iteration, out string result)
        {
            result = "";
            for (int i = 0; i < iteration; i++)
            {
                result += value[UnityEngine.Random.Range( 0, value.Length)];
            }
        }

        public static void GetRandom_0_1(out float random) => GetRandomN2M(0f, 1f, out random);
        public static void GetRandom_0_90(out float random) => GetRandomN2M(0f, 90f, out random);
        public static void GetRandom_0_180(out float random) => GetRandomN2M(0f, 180f, out random);
        public static void GetRandom_0_360(out float random) => GetRandomN2M(0f, 360f, out random);
        public static void GetRandom_n1_1(out float random) => GetRandomN2M(-1f, 1f, out random);
        public static void GetRandom_n90_90(out float random) => GetRandomN2M(-90f, 90f, out random);
        public static void GetRandom_n180_180(out float random) => GetRandomN2M(-180f, 180f, out random);
        public static void GetRandom_n360_360(out float random) => GetRandomN2M(-360f, 360f, out random);

        public static System.Random randomSeed = new System.Random((int)(DateTime.Now - new DateTime(DateTime.Now.Year,1,1)).TotalSeconds);
        public static void GetRandomN2M(in float minValue, in float maxValue, out float random) {
            Eloi.E_CodeTag.ChatGPTSource();
            random = (float)(randomSeed.NextDouble() * (maxValue - minValue) + minValue);
            
        }
        public static void GetRandomN2M(in int nInclusive, in int mInclusive, out int random) =>
         random = UnityEngine.Random.Range(nInclusive, mInclusive+1);

        public static void GetRandomOfEnum<T>( out T result) where T: Enum
        {
            Eloi.E_GeneralUtility.GetEnumEnumerable(out IEnumerable<T> elements);
            GetRandomOf(out result, in elements);
        }


        public static void GetRandomOf<T>(out T[] result, in int count, params T[] list)
        {

            if (list == null || list.Length <= 0)
            {
                result = new T[0];
                return;
            }
            else
            {
                    result = new T[count];
                    for (int i = 0; i < count; i++)
                    {
                        GetRandomOf(out result[i],  list);
                    }
                return;
                
            }

        }
        public static void GetRandomOfOrLess<T>(out T[] result, in int count, params T[] list)
        {

            if (list == null || list.Length <= 0)
            {
                result = new T[0];
                return;
            }
            else
            {
                if (list.Length < count) { 
                    result = list;
                    return;
                }
                else
                {
                    result = new T[count];
                    for (int i = 0; i < count; i++)
                    {
                        GetRandomOf(out result[i],  list);
                    }
                    return;
                }
            }
        }
        public static void GetRandomOf<T>(out T result, params T[] list) =>
            result = list[UnityEngine.Random.Range(0, list.Length)];
        public static void GetRandomOf<T>(out T result, in T[] list) =>
            result = list[UnityEngine.Random.Range(0, list.Length)];

        public static void GetRandomOf<T>(out T result, IEnumerable<T> range) =>

           GetRandomOf<T>(out result, range.ToArray());
        public static void GetRandomOf<T>(out T result, in IEnumerable<T> range) =>

                  GetRandomOf<T>(out result, range.ToArray());


        public static void Next<T>(in FairRandom<T> fairRandom, out T result) =>
            fairRandom.GetNext(out result);
        
        public static void ShuffleParams<T>(out T[] result, params T[] toAffect) =>
        
            ShuffleAsNew(in toAffect, out result);

        public static void ShuffleRef<T>(ref T[] toAffect)
        {
            int n = toAffect.Length;
            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n--);
                T temp = toAffect[n];
                toAffect[n] = toAffect[k];
                toAffect[k] = temp;
            }
        }
        public static void ShuffleRef<T>(ref List<T> toAffect)
        {
            int n = toAffect.Count;
            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n--);
                T temp = toAffect[n];
                toAffect[n] = toAffect[k];
                toAffect[k] = temp;
            }
        }

        public static void ShuffleAsNew<T>(in T[] given, out T[] result)
        {
            result = given.ToArray();
            ShuffleRef(ref result);
        }
        public static void GetRandomOf(in string text, out char character)
        {
            character = text[UnityEngine.Random.Range(0, text.Length)];
        }

        public static bool GetRandomBool()
        {
            GetRandomBool(out bool value);
            return value;
        }
    }



    

   
}
