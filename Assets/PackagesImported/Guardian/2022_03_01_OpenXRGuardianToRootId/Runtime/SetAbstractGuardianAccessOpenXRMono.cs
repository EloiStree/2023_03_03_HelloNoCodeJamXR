using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class SetAbstractGuardianAccessOpenXRMono : MonoBehaviour
{
    public bool m_hasGuardian;
    public List<Vector3> m_guardianPoints = new List<Vector3>();
    public RelayGuardianLineOfPointsEvent m_onGuardianChanged;
    public UnityEvent m_notFoundGuardian;
    public bool m_pushPreviousAtStart=true;

    void Start()
    {
        var loader = XRGeneralSettings.Instance?.Manager?.activeLoader;
        if (loader == null)
        {
            m_notFoundGuardian.Invoke();
            return;
        }
        var inputSubsystem = loader.GetLoadedSubsystem<XRInputSubsystem>();
        inputSubsystem.boundaryChanged += InputSubsystem_boundaryChanged;
        if (m_pushPreviousAtStart) PushCurrentBoundary();
    }

    [ContextMenu("Push Current Guardian")]
    public void PushCurrentBoundary() {
        var loader = XRGeneralSettings.Instance?.Manager?.activeLoader;
        if (loader == null)
        {
            m_notFoundGuardian.Invoke();
            return;
        }
        var inputSubsystem = loader.GetLoadedSubsystem<XRInputSubsystem>();
            InputSubsystem_boundaryChanged(inputSubsystem);
    }

    private void InputSubsystem_boundaryChanged(XRInputSubsystem inputSubsystem)
    {
        m_hasGuardian = inputSubsystem.TryGetBoundaryPoints(m_guardianPoints);
        if (m_hasGuardian)
        {
            Eloi.E_DrawingUtility.DrawLines(5, Color.red, m_guardianPoints.ToArray());
            if (m_guardianPoints.Count > 0)
                m_onGuardianChanged.Invoke(m_guardianPoints.ToArray());
            else
            {
                m_notFoundGuardian.Invoke();

            }
        }
        else
        {
            m_guardianPoints = new List<Vector3>();
            m_notFoundGuardian.Invoke();
        }
       
    }
}
