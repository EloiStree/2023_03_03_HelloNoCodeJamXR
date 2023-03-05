using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGuardianValueTagMono : MonoBehaviour

{

    public bool m_hasGuardianDefined;
    public Vector3 m_guardianRootWorldPosition;
    public Quaternion m_guardianRootWorldRotation;
    public string m_givenUniqueIdBasedOnGuardian;
    public Transform m_guardianRoot;


    public void SetGuardianRootPosition(Vector3 position)
    {
        if (m_guardianRoot)
            m_guardianRoot.position = position;
        m_guardianRootWorldPosition = position;
    }
    public void SetGuardianRootRotation(Quaternion rotation)
    {
        if (m_guardianRoot)
            m_guardianRoot.rotation = rotation;
        m_guardianRootWorldRotation = rotation;
    }
    public void SetGuardianStringId(string guardianId)
    {
        if (m_guardianRoot)
            m_guardianRoot.name ="String Id:"+ guardianId;
        m_givenUniqueIdBasedOnGuardian = guardianId;
    }
    public void SetAsGuardianDefined(bool isGuardianDefined)
    {
        if (m_guardianRoot)
            m_guardianRoot.gameObject.SetActive(isGuardianDefined);
        m_hasGuardianDefined = isGuardianDefined;
    }
}
