using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRSkeleton;

public class QuestHandToTransformBones : MonoBehaviour
{
    public SkeletonType m_handType;
    public OVRSkeleton m_handSkeletonInfo;
    public OVRHand m_handStateInfo;
    public Transform m_wraistRoot;
    public Transform[] m_bonesTransform;

    private Vector3 m_leftAdjustementRotation = new Vector3(0,90,180);
    private Vector3 m_rightAdjustmentRotation = new Vector3(0, -90, 0);


    public void Update()
    {
        if (!m_handStateInfo.IsTracked)
        {
            SetAsNotTracked();
        }
        else {
            SetPositionOfTrackedHandWithBones();
        }
    }

    private void SetPositionOfTrackedHandWithBones()
    {
        int boneId = -1;
        Transform selectedBone = null;
        for (int i = 0; i < m_handSkeletonInfo.Bones.Count; i++)
        {
            boneId = (int)m_handSkeletonInfo.Bones[i].Id;
            if (boneId >= 0 && boneId < m_bonesTransform.Length)
            {
                selectedBone = m_bonesTransform[boneId];
                if (boneId == 0)
                {
                    if (m_wraistRoot != null && selectedBone != null)
                    {
                //        m_wraistRoot.gameObject.SetActive(true);
                        m_wraistRoot.position = selectedBone.position;
                        m_wraistRoot.rotation = selectedBone.rotation;
                    }
                }

                m_bonesTransform[i].gameObject.SetActive(true);
                selectedBone.position = m_handSkeletonInfo.Bones[i].Transform.position;
                ApplyRotationToPutStandardToTheDirectionOfHandBones(selectedBone, i);
            }

        }
    }

    private void ApplyRotationToPutStandardToTheDirectionOfHandBones(Transform selectedBone, int i)
    {
        Quaternion rotationAdjustement = Quaternion.identity;
        if (m_handType == SkeletonType.HandLeft)
            rotationAdjustement = Quaternion.Euler(m_leftAdjustementRotation)*Quaternion.Euler(0,180,0);
        if (m_handType == SkeletonType.HandRight)
            rotationAdjustement = Quaternion.Euler(m_rightAdjustmentRotation) * Quaternion.Euler(0, 180, 0);

        selectedBone.rotation = m_handSkeletonInfo.Bones[i].Transform.rotation * rotationAdjustement;
    }

    private void SetAsNotTracked()
    {
        m_wraistRoot.position = Vector3.zero;
        m_wraistRoot.rotation = Quaternion.identity;
   //     m_wraistRoot.gameObject.SetActive(false);
        for (int i = 0; i < m_bonesTransform.Length; i++)
        {
            m_bonesTransform[i].position = Vector3.zero;
            m_bonesTransform[i].rotation = Quaternion.identity;
            m_bonesTransform[i].gameObject.SetActive(false);
        }
    }
}
