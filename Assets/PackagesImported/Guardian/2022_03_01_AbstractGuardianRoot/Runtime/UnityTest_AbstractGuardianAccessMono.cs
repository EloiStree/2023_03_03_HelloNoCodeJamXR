using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTest_AbstractGuardianAccessMono : MonoBehaviour
{
    public AbstractGuardianAccessMono m_toAffect;

    public bool m_hasGuardianDefined;
    public string m_givenUniqueIdBasedOnGuardian;

    [Header("Raw value to push")]
    public Vector3 m_guardianRootWorldPosition;
    public Quaternion m_guardianRootWorldRotation;
    [Header("Transform value to push")]
    public Transform m_guardianRootWorld;

    [ContextMenu("Push Raw value")]
    public void PushRawValue()
    {
        m_toAffect.SetAsGuardianDefinedNoNotification(m_hasGuardianDefined);
        m_toAffect.SetGuardianRootPositionNoNotification(m_guardianRootWorldPosition);
        m_toAffect.SetGuardianRootRotationNoNotification(m_guardianRootWorldRotation);
        m_toAffect.SetGuardianStringIdNoNotification(m_givenUniqueIdBasedOnGuardian);
        m_toAffect.NotifyGuardianAsChanged();
    }
    [ContextMenu("Push Transform value")]
    public void PushTransformValue()
    {
        m_toAffect.SetAsGuardianDefinedNoNotification(m_hasGuardianDefined);
        m_toAffect.SetGuardianRootPositionNoNotification(m_guardianRootWorld.position);
        m_toAffect.SetGuardianRootRotationNoNotification(m_guardianRootWorld.rotation);
        m_toAffect.SetGuardianStringIdNoNotification(m_givenUniqueIdBasedOnGuardian);
        m_toAffect.NotifyGuardianAsChanged();
    }
    private void Reset()
    {
        m_toAffect = GetComponent<AbstractGuardianAccessMono>();
    }
}
