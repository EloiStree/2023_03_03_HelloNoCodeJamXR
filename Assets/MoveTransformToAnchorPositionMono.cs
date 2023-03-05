using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformToAnchorPositionMono : MonoBehaviour
{
    public Transform m_objectToMove;
    public Transform m_anchorPosition;
    public bool m_usePosition=true;
    public bool m_useRotation=true;
    public bool m_useScale;

    [ContextMenu("Move Object to Anchor Position")]
    public void MoveObjectToAnchorPosition()
    {
        if (m_usePosition)
            m_objectToMove.position = m_anchorPosition.position;
        if (m_useRotation)
            m_objectToMove.rotation = m_anchorPosition.rotation;
        if(m_useScale)
            m_objectToMove.localScale = m_anchorPosition.localScale;
    }

    private void Reset()
    {
        m_anchorPosition = this.transform;
    }
}
