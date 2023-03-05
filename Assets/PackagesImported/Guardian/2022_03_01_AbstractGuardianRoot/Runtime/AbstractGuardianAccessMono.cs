using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbstractGuardianAccessMono : MonoBehaviour
{
    public bool m_hasGuardianDefined;
    public Vector3 m_guardianRootWorldPosition;
    public Quaternion m_guardianRootWorldRotation;
    public string m_givenUniqueIdBasedOnGuardian;

    public Transform m_debugRootGuardian;
    public UnityEvent m_onChangeDetected;

    public void SetGuardianRootPositionNoNotification(Vector3 position) { SetGuardianRootPosition(position, false); }
    public void SetGuardianRootPosition(Vector3 position, bool notifyChanged)
    {
        m_guardianRootWorldPosition = position;
        if (notifyChanged)
            NotifyGuardianAsChanged();
    }
    public void SetGuardianRootRotationNoNotification(Quaternion rotation) { SetGuardianRootRotation(rotation, false); }
    public void SetGuardianRootRotation(Quaternion rotation, bool notifyChanged)
    {
        m_guardianRootWorldRotation = rotation;
        if (notifyChanged)
            NotifyGuardianAsChanged();
    }
    public void SetGuardianStringIdNoNotification(string guardianId) { SetGuardianStringId(guardianId, false); }
    public void SetGuardianStringId(string guardianId, bool notifyChanged)
    {
        m_givenUniqueIdBasedOnGuardian = guardianId;
        if (notifyChanged)
            NotifyGuardianAsChanged();
    }
    public void SetAsGuardianDefinedNoNotification(bool isGuardianDefined) { SetAsGuardianDefined(isGuardianDefined, false); }
    public void SetAsGuardianDefined(bool isGuardianDefined, bool notifyChanged) {
        m_hasGuardianDefined = isGuardianDefined;
        if(notifyChanged)
        NotifyGuardianAsChanged();
    }

    [ContextMenu("Notify as Changed")]
    public void NotifyGuardianAsChanged() {
        RefreshGuardian();
        m_onChangeDetected.Invoke();
    }

    [ContextMenu("Refresh Guardian")]
    public void RefreshGuardian() {
        if (m_debugRootGuardian) { 
            m_debugRootGuardian.gameObject.SetActive(m_hasGuardianDefined);
            m_debugRootGuardian.position = m_guardianRootWorldPosition;
            m_debugRootGuardian.rotation = m_guardianRootWorldRotation;
            m_debugRootGuardian.name = "Guardian ID | " + m_givenUniqueIdBasedOnGuardian;
        }
    }
    
}
