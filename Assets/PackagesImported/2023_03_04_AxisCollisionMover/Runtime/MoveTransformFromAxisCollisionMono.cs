using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformFromAxisCollisionMono : MonoBehaviour
{
    public Transform m_whatToRotate;
    public Transform m_axisDirection;


    public float m_moveSpeed=0.5f;
    public bool m_moveLeft;
    public bool m_moveRight;
    public bool m_moveDown;
    public bool m_moveTop;
    public bool m_moveForward;
    public bool m_moveBackward;

    public float m_rotationAngle = 90;
    public float m_rotationSpeed = 0.5f;
    public bool m_rotatePositiveForwardZ;
    public bool m_rotateNegativeForwardZ;
    public bool m_rotatePositiveUpY;
    public bool m_rotateNegativeUpY;
    public bool m_rotatePositiveRightX;
    public bool m_rotateNegativeRightX;



    public void SetMoveLeft(bool value) => m_moveLeft = value;
    public void SetMoveRight(bool value) => m_moveRight = value;
    public void SetMoveDown(bool value) => m_moveDown = value;
    public void SetMoveTop(bool value) => m_moveTop = value;
    public void SetMoveForward(bool value) => m_moveForward = value;
    public void SetMoveBackward(bool value) => m_moveBackward = value;


    public void SetRotatePositiveForwardZ (bool value)         => m_rotatePositiveForwardZ=value;
    public void SetRotateNegativeForwardZ     (bool value)        => m_rotateNegativeForwardZ = value;
    public void SetRotatePositiveUpY (bool value)         => m_rotatePositiveUpY = value;
    public void SetRotateNegativeUpY (bool value)          => m_rotateNegativeUpY = value;
    public void SetRotatePositiveRightX (bool value)      => m_rotatePositiveRightX = value;
    public void SetRotateNegativeRightX (bool value)     => m_rotateNegativeRightX = value;


    public bool m_inverseQuaternionMultiplication;


    void Update()
    {
        float deltaTime = Time.deltaTime;
        if (m_moveLeft) m_whatToRotate.position += -m_axisDirection.right * m_moveSpeed * deltaTime;
        if (m_moveRight) m_whatToRotate.position += m_axisDirection.right * m_moveSpeed * deltaTime;
        if (m_moveDown) m_whatToRotate.position += -m_axisDirection.up * m_moveSpeed * deltaTime;
        if (m_moveTop) m_whatToRotate.position += m_axisDirection.up * m_moveSpeed * deltaTime;
        if (m_moveBackward) m_whatToRotate.position += -m_axisDirection.forward * m_moveSpeed * deltaTime;
        if (m_moveForward) m_whatToRotate.position += m_axisDirection.forward * m_moveSpeed * deltaTime;


        float rotationValue = m_rotationAngle * m_rotationSpeed * deltaTime; 
        Vector3 eulerRotation = new Vector3();


        if (m_rotatePositiveForwardZ)   eulerRotation.z += rotationValue;
        if (m_rotateNegativeForwardZ)   eulerRotation.z -= rotationValue;
        if (m_rotatePositiveUpY)        eulerRotation.y += rotationValue;
        if (m_rotateNegativeUpY)        eulerRotation.y -= rotationValue;
        if (m_rotatePositiveRightX)     eulerRotation.x += rotationValue;
        if (m_rotateNegativeRightX)     eulerRotation.x -= rotationValue;


        // BAD CODE. I THINK I KNOW HOW TO CODE IT BUT NEED TIME AND FOCUS.
        //THE IDEA WOULD BE TO ROTATE THE OBJECT AROUND THE PIVOT AND NOT THE OBEJCT.
        /*
        Quaternion rotationToApply = Quaternion.Euler(eulerRotation);
        m_whatToRotate.position = RotationUtility.RotatePointAroundPivot(m_whatToRotate.position, m_axisDirection.position, rotationToApply);
        if(m_inverseQuaternionMultiplication)
            m_whatToRotate.rotation = rotationToApply * m_whatToRotate.rotation;
        else 
            m_whatToRotate.rotation =   m_whatToRotate.rotation* rotationToApply;
        */
        Quaternion rotationToApply = Quaternion.Euler(eulerRotation);
        if (m_inverseQuaternionMultiplication)
            m_whatToRotate.rotation = rotationToApply * m_whatToRotate.rotation;
        else
            m_whatToRotate.rotation = m_whatToRotate.rotation * rotationToApply;
    }
    private void Reset()
    {
        m_axisDirection = this.transform;
        m_whatToRotate = this.transform.parent;
    }



    public class RotationUtility
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
            GetLocalToWorld_Point(in localPosition, in p, in r, out worldPosition);
        }
        public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition) =>
            localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);

        public static void GetLocalToWorld_Point(in Vector3 localPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition) =>
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
            localRotation = Quaternion.Inverse(rotationReference) * worldRotation;
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
