using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloHandTracking : MonoBehaviour
{
    public OVRManager m_manager;
    public OVRSkeleton m_leftSkeleton;
    public OVRHand m_leftHand;
    public OVRMesh m_leftMesh;
    public OVRMeshRenderer m_leftMeshRenderer;
    public string m_description;
    public Text m_debug;
    public GameObject m_debugJoinPrefab;
    public Transform m_pointer;

    
    public List<GameObject> objs = new List<GameObject>();
    public Transform m_selectBone;

    public int m_index;

    private void Start()
    {
        InvokeRepeating("Incr", 0, 1);
    }
    public void Incr() {
        m_index++;
        if (m_index > 27)
            m_index = 0;
    }
    void Update()
    {
        m_description = ">> ";
        m_description += " " + m_leftSkeleton.GetCurrentStartBoneId();
        m_description += " " + m_leftSkeleton.GetCurrentEndBoneId();
        m_description += " | ";
        m_description += " " + m_leftSkeleton.GetCurrentNumBones();
        m_description += " " + m_leftSkeleton.GetCurrentNumSkinnableBones();

        m_description += ">> ";
        m_description += " Index " + m_index + " " + ((OVRSkeleton.BoneId)m_index);
        m_description += " << \n";

        m_description += ">> ";
        m_description += " Scale " + m_leftHand.HandScale;
        m_description += " Tracked " + m_leftHand.IsTracked;
        m_description += " Confidence " + m_leftHand.HandConfidence;
        m_description += " | ";
        m_description += " Pinch " + m_leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        m_description += " " + m_leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        m_description += " Pointer " + m_leftHand.IsPointerPoseValid;

        m_description += " << \n";

       // CreateCubeForBones();

        m_description += ">> ";
        m_pointer.transform.position = m_leftHand.PointerPose.position;
        m_pointer.transform.rotation = m_leftHand.PointerPose.rotation;

        

        m_description += " << \n";

        m_debug.text = m_description;


    }

    private void CreateCubeForBones()
    {
        IList<OVRBone> bones = m_leftSkeleton.Bones;
        for (int i = 0; i < objs.Count; i++)
        {
            Destroy(objs[i]);

        }
        objs.Clear();
        for (int i = 0; i < bones.Count; i++)
        {
            GameObject created = GameObject.Instantiate(m_debugJoinPrefab);
            objs.Add(created);
            created.transform.position = bones[i].Transform.position;
            created.transform.rotation = bones[i].Transform.rotation;
            if (m_index == (int)bones[i].Id)
            {
                m_selectBone.position = bones[i].Transform.position;
                m_selectBone.rotation = bones[i].Transform.rotation;
            }

        }
    }

    private void CreateCubesOnHand()
    {
        List<Vector3> vertices = new List<Vector3>();
        m_leftMesh.Mesh.GetVertices(vertices);
        for (int i = 0; i < objs.Count; i++)
        {
            Destroy(objs[i]);

        }
        objs.Clear();
        for (int i = 0; i < vertices.Count; i++)
        {
            GameObject created = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objs.Add(created);
            created.transform.position = vertices[i];

        }
    }
}
