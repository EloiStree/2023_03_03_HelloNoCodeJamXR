using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeMono : MonoBehaviour
{
    public float m_lifeTimeStart=30;
    public float m_currentLifeTime=30;
    public AbstractDestroyManagerMono m_autoDestroy;
    // Start is called before the first frame update
    void Start()
    {
        m_currentLifeTime = m_lifeTimeStart;    
    }

    // Update is called once per frame
    void Update()
    {
        m_currentLifeTime -= Time.deltaTime;
        if (m_currentLifeTime<0) {
            if (m_autoDestroy)
                m_autoDestroy.RequestDestruction();
            else Destroy(this.gameObject);
        }
    }

    private void Reset()
    {
        this.gameObject.GetComponent<AbstractDestroyManagerMono>();
        if (m_autoDestroy == null)
            m_autoDestroy=   this.gameObject.AddComponent<DefaultDestroyManagerMono>();
    }
}
