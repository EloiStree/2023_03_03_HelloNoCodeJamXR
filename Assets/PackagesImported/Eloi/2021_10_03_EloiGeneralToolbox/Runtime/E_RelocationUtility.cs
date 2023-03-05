using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi { 

    public class E_RelocationUtility 
    {
        public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Transform rootReference, out Vector3 localPosition)
        {
            Vector3 p = rootReference.position;
            Quaternion r = rootReference.rotation;
            GetWorldToLocal_Point(in worldPosition, in p, in r, out localPosition);
        }
        public static void GetLocalToWorld_Point(in Vector3 localPosition, in Transform rootReference, out Vector3 worldPosition)
        {
            Vector3 p = rootReference.position;
            Quaternion r = rootReference.rotation;
            GetLocalToWorld_Point(in localPosition, in p,in r, out worldPosition);
        }
        public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition) =>
            localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);
        
        public static void GetLocalToWorld_Point(in Vector3 localPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition)=>
            worldPosition = (rotationReference * localPosition) + (positionReference);

        public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Transform rootReference, out Vector3 localPosition, out Quaternion localRotation)
        {
            Vector3 p = rootReference.position;
            Quaternion r = rootReference.rotation;
            GetWorldToLocal_DirectionalPoint(in worldPosition, in worldRotation, in p, in r, out localPosition, out localRotation);
        }
        public static void GetLocalToWorld_DirectionalPoint(in Vector3 localPosition, in Quaternion localRotation, in Transform rootReference, out Vector3 worldPosition, out Quaternion worldRotation)
        {
            Vector3 p = rootReference.position;
            Quaternion r = rootReference.rotation;
            GetLocalToWorld_DirectionalPoint(in localPosition, in localRotation, in p, in r, out worldPosition, out worldRotation);
        }
        public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition, out Quaternion localRotation)
        {
            localRotation = Quaternion.Inverse(rotationReference)* worldRotation;
            localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);
        }
        public static void GetLocalToWorld_DirectionalPoint(in Vector3 localPosition, in Quaternion localRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition, out Quaternion worldRotation)
        {
            worldRotation = localRotation * rotationReference;
            worldPosition = (rotationReference * localPosition) + (positionReference);
        }

        public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
        {
            return RotatePointAroundPivot(point, pivot, Quaternion.Euler(angles));
        }

        public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
        {
            return rotation * (point - pivot) + pivot;
        }
    }
}
