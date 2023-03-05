using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi {
public class E_SearchInSceneUtility : MonoBehaviour
{


    public static void TryToFetchWithInScene<T>(ref T toFill) where T : UnityEngine.Object
    {
        T[] languages = Resources.FindObjectsOfTypeAll<T>();
        if (languages.Length > 0)
            toFill = languages[0];
    }
    public static void TryToFetchWithInScene<T>(ref T[] toFill) where T : UnityEngine.Object
    {
        toFill = Resources.FindObjectsOfTypeAll<T>();
    }
        public static void TryToFetchWithActiveInScene<T>(ref T toFill, bool includeInactive = false) where T : UnityEngine.Object
        {

            toFill = GameObject.FindObjectOfType<T>(includeInactive);
        }
        public static void TryToFetchWithActiveInScene<T>(ref T[] toFill, bool includeInactive = false) where T : UnityEngine.Object
        {

            toFill = GameObject.FindObjectsOfType<T>(includeInactive);
        }
        public static void FetchComponent<T>(in MonoBehaviour from, ref T target) where T : UnityEngine.Object
        {
            FetchComponent(from.gameObject, ref target);
        }
        public static void FetchComponent<T>(in MonoBehaviour from, ref T[] target) where T : UnityEngine.Object
        {
            FetchComponent(from.gameObject, ref target);

        }
        public static void FetchComponent<T>(in GameObject from, ref T target) where T : UnityEngine.Object
        {
            if (target == null)
                target = from.GetComponent<T>();

        }
        public static void FetchComponent<T>(in GameObject from, ref T [] target) where T : UnityEngine.Object
        {
            if (target == null)
                target = from.GetComponents<T>();

        }
        public static void FetchComponentNearThenChildren<T>(in MonoBehaviour from, ref T target) where T : UnityEngine.Object
        {
            FetchComponentNearThenChildren(from.gameObject, ref target);
        }
        public static void FetchComponentNearThenChildren<T>(in MonoBehaviour from, ref T[] target) where T : UnityEngine.Object
        {
            FetchComponentNearThenChildren(from.gameObject, ref target);

        }
        public static void FetchComponentNearThenChildren<T>(in GameObject from, ref T target) where T : UnityEngine.Object
        {
            if (target == null)
                target = from.GetComponent<T>();
            if (target == null)
                target = from.GetComponentInChildren<T>();
        }
        public static void FetchComponentNearThenChildren<T>(in GameObject from, ref T[] target) where T : UnityEngine.Object
        {
            if (target == null)
                target = from.GetComponents<T>();
            if (target == null)
                target = from.GetComponentsInChildren<T>();
        }

        public static void TryToFetchWithActiveInScene<T>(ref T[] toFill) where T : UnityEngine.Object
    {
        toFill = GameObject.FindObjectsOfType<T>();
    }
}
}
