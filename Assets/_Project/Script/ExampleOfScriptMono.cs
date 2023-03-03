using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleOfScriptMono : MonoBehaviour
{

    public float m_vitesseDeRotationInDegree = 180;
    [SerializeField] Vector3  m_rotationAsEulerValue = Vector3.up;

    public Transform m_whatToRotate;

    void Start()
    {
        Debug.Log("Hello Unity !!!");
    }

    void Update()
    {
        float timePastSinecLastFrame = Time.deltaTime;
        m_whatToRotate.Rotate(m_rotationAsEulerValue, m_vitesseDeRotationInDegree * timePastSinecLastFrame);
    }
}
