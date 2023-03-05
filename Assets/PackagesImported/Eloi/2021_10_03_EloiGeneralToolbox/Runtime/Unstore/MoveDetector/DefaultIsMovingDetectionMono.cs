using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Eloi { 
public class DefaultIsMovingDetectionMono : AbstractIsMovingDetectionMono
{
    public float m_timeToBeConsiderMoving = 0.5f;
    public float m_timeSinceLastMove;
    public DefaultBooleanChangeListener m_isMoving;

    public override void IsMoving(out bool moving) { 
      m_isMoving.GetBoolean(out moving);
    }

    public void PingAsMoved() { 
     m_timeSinceLastMove = 0;
    }
    private void Update()
    {
        m_timeSinceLastMove += Time.deltaTime;
        m_isMoving .SetBoolean(m_timeSinceLastMove < m_timeToBeConsiderMoving);
    }

}
}
