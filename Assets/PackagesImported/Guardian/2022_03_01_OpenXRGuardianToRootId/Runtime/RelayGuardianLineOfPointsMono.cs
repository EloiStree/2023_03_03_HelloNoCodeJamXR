using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RelayGuardianLineOfPointsMono : MonoBehaviour
{
    public RelayGuardianLineOfPointsEvent m_onPointsToRelay;

    public void PushPointsToRelay(Vector3[] points)
    {
        m_onPointsToRelay.Invoke(points);
    }
    public void PushEmptyArrayofPointsToRelay()
    {
        m_onPointsToRelay.Invoke(new Vector3[] { });
    }

}
[System.Serializable]
public class RelayGuardianLineOfPointsEvent : UnityEvent<Vector3[]>
{


}
