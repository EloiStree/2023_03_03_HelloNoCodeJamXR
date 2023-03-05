using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustementAnchorMono : MonoBehaviour
{
    public Transform m_origin;
    public Transform m_whatToMove;

    public AdjustementAnchorValue m_adjustement;
    private void OnValidate()
    {
        SetLocalTranslation(m_adjustement.m_localPosition, m_adjustement.m_localEulerRotation);
    }


    public void SetLocalTranslation(Vector3 adjustementLocalPosition, Vector3 rotationEulerAdjustement)
    {
        SetLocalTranslation(adjustementLocalPosition, Quaternion.Euler(rotationEulerAdjustement));

    }
    public void SetLocalTranslation(Vector3 adustementLocalPosition, Quaternion rotationAdjustement)
    {
        m_adjustement.m_localEulerRotation = rotationAdjustement.eulerAngles;
        m_adjustement.m_localRotation = rotationAdjustement;
        m_adjustement.m_localPosition = adustementLocalPosition;

        m_whatToMove.position = m_origin.position + m_adjustement.m_localPosition;
        m_whatToMove.rotation = m_adjustement.m_localRotation * m_origin.rotation;
    }
    public void SetLocalTranslation(Vector3 adustement)
    {
        SetLocalTranslation(adustement, m_adjustement.GetLocalRotation());
    }
    public void SetLocalRotation(Quaternion adustement)
    {
        SetLocalTranslation(m_adjustement.GetLocalPosition(), adustement);
    }
    public void SetLocalRotation(Vector3 adustementEuleur)
    {
        SetLocalTranslation(m_adjustement.GetLocalPosition(), adustementEuleur);
    }

    public void RefreshPosition()
    {
        SetLocalTranslation(m_adjustement.m_localPosition, m_adjustement.m_localRotation);
    }

    private void Reset()
    {
        m_whatToMove = transform;
        m_origin = transform.parent;
    }
}

[System.Serializable]
public class AdjustementAnchorValue
{

    public Vector3 m_localPosition;
    public Vector3 m_localEulerRotation;
    public Quaternion m_localRotation;




    public void SetLocalTranslation(Vector3 adjustementLocalPosition, Vector3 rotationEulerAdjustement)
    {
        SetLocalTranslation(adjustementLocalPosition, Quaternion.Euler(rotationEulerAdjustement));

    }
    public void SetLocalTranslation(Vector3 adustementLocalPosition, Quaternion rotationAdjustement)
    {
        m_localEulerRotation = rotationAdjustement.eulerAngles;
        m_localRotation = rotationAdjustement;
        m_localPosition = adustementLocalPosition;
    }
    public void SetLocalTranslation(Vector3 adustement)
    {
        SetLocalTranslation(adustement, m_localRotation);
    }
    public void SetLocalRotation(Quaternion adustement)
    {
        SetLocalTranslation(m_localPosition, adustement);
    }
    public void SetLocalRotation(Vector3 adustementEuleur)
    {
        SetLocalTranslation(m_localPosition, adustementEuleur);
    }

    public Quaternion GetLocalRotation()
    {
        return m_localRotation;
    }

    public Vector3 GetLocalPosition()
    {
        return m_localPosition;
    }
}