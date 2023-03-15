using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleOfScriptMono : MonoBehaviour
{

    public float m_vitesseDeRotationInDegree = 180;
    [SerializeField] Vector3  m_rotationAsEulerValue = Vector3.up;

    public Transform m_whatToRotate;
    public GameObject m_whatToActivate;
    public bool m_activateAtStart;

    void Start()
    {
        Debug.Log("Hello Unity !!!");
        m_whatToActivate.SetActive(m_activateAtStart);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
                float multiplicateur = 50;
                float timePastSinecLastFrame = Time.deltaTime;
                m_whatToRotate.Rotate(m_rotationAsEulerValue, m_vitesseDeRotationInDegree * timePastSinecLastFrame
                   * multiplicateur);
        }
    }
}
