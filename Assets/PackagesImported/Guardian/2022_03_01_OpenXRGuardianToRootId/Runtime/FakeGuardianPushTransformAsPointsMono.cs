using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FakeGuardianPushTransformAsPointsMono : MonoBehaviour
{
    public Transform [] m_points;
    public RelayGuardianLineOfPointsEvent m_onGuardianPush;

    public bool m_pushOnEnable;

    public void OnEnable()
    {
        if (m_pushOnEnable)
            PushGuardian();
    }

    [ContextMenu("Push Guardian")]
    public void PushGuardian() {

        m_onGuardianPush.Invoke( m_points.Select(k => k.position).ToArray() );
    }
}
