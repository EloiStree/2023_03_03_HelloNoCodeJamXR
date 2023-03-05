using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadGameObjectMono : MonoBehaviour
{
    public GameObject[] m_targets;

    public void Awake()
    {

        AddTargetsToObjectToKeep();
    }
    public void Start()
    {
        AddTargetsToObjectToKeep();
    }

    private void AddTargetsToObjectToKeep()
    {
        for (int i = 0; i < m_targets.Length; i++)
        {
            DontDestroyOnLoad(this.gameObject);

        }
    }

    private void Reset()
    {
        m_targets = new GameObject[] { this.gameObject };
    }
}
