using UnityEngine;
using UnityEngine.Events;

public class StartTick : MonoBehaviour
{
    public UnityEvent m_tick;
    void Start()
    {
        m_tick.Invoke();
    }

}
