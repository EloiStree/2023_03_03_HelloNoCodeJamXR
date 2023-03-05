using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RelayGuardianLineOfPointsMono : MonoBehaviour
{
    public RelayGuardianLineOfPointsEvent m_onPointsToRelay;

    public void PushPointsToRelay(Vector3 [] points) {
        m_onPointsToRelay.Invoke(points);
    }

}
[System.Serializable]
public class RelayGuardianLineOfPointsEvent : UnityEvent<Vector3[]>
{


}
