using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DeveloperMode
    {
        public static bool m_isWorkingWithDeveloperVersion = true;

        public static void AddListener(DeveloperModeChange isDevOn)
        {
            m_devModeChangeListener += isDevOn;
        }
        public static void RemoveListener(DeveloperModeChange isDevOn)
        {
            m_devModeChangeListener -= isDevOn;
        }


        public delegate void DeveloperModeChange(bool deveModeIsOn);
        public static DeveloperModeChange m_devModeChangeListener;
        [ContextMenu("Set dev mode")]
        public static void SetAsDeveloperMode() { 
                m_isWorkingWithDeveloperVersion = true;
            if(m_devModeChangeListener!=null)
            m_devModeChangeListener(m_isWorkingWithDeveloperVersion);
        }


        [ContextMenu("Set client mode")]
        public static void SetAsClientMode()
        {
            m_isWorkingWithDeveloperVersion = false;
            if (m_devModeChangeListener != null)
                m_devModeChangeListener(m_isWorkingWithDeveloperVersion);
        }
        [ContextMenu("Swithc dev and client mode")]
        public static void SwitchDeveloperMode()
        {
            if (m_isWorkingWithDeveloperVersion)
            
                SetAsClientMode();
            
            else SetAsDeveloperMode();

        }




        public static void SetDeveloperModeAs(bool value)
        {
            m_isWorkingWithDeveloperVersion = value;
            if (m_devModeChangeListener != null)
                m_devModeChangeListener(m_isWorkingWithDeveloperVersion);
        }
        public static void IsInDeveloperMode(out bool isInDevMode) { isInDevMode = m_isWorkingWithDeveloperVersion; }
        public static bool IsInDeveloperMode() { return m_isWorkingWithDeveloperVersion; }
    }
    public class DeveloperModeMono : MonoBehaviour
    {
        [ContextMenu("Set As developer")]
        public  void SetAsDeveloperMode() => DeveloperMode.SetAsDeveloperMode();
        [ContextMenu("Set As Client")]
        public  void SetAsClientMode() => DeveloperMode.SetAsClientMode();
        public  void SetDeveloperModeAs(bool value) => DeveloperMode.SetDeveloperModeAs(value);
        public  void IsInDeveloperMode(out bool isInDevMode) 
        { DeveloperMode.IsInDeveloperMode(out isInDevMode); }
        public  bool IsInDeveloperMode() 
        { return DeveloperMode.IsInDeveloperMode(); }

        [ContextMenu("Switch developer mode")]
        public void SwitchDeveloperMode()
        => DeveloperMode.SwitchDeveloperMode();

        

    }
}
