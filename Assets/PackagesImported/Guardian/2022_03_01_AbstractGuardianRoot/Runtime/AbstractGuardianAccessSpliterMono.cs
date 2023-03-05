using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGuardianAccessSpliterMono : MonoBehaviour
{
    public AbstractGuardianAccessMono m_source;

    public Eloi.PrimitiveUnityEvent_Bool    m_guardianActive;
    public Eloi.PrimitiveUnityEvent_String  m_guardianGivenId;
    public Eloi.ClassicUnityEvent_Vector3   m_worldPosition;
    public Eloi.ClassicUnityEvent_Quaternion m_worldRotation;


    [ContextMenu("Push Data as split value")]
    public void PushDataAsSplitValue()
    {
        m_guardianActive.Invoke(m_source.m_hasGuardianDefined);
        m_guardianGivenId.Invoke(m_source.m_givenUniqueIdBasedOnGuardian);
        m_worldPosition.Invoke(m_source.m_guardianRootWorldPosition);
        m_worldRotation.Invoke(m_source.m_guardianRootWorldRotation);
        
    }
}
