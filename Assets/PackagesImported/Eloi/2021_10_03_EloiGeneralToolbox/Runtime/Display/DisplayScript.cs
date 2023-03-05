using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
  
    public class DisplayScript : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("displays connected: " + Display.displays.Length);
            // Display.displays[0] is the primary, default display and is always ON.
            // Check if additional displays are available and activate each.
            if (Display.displays.Length > 1)
                Display.displays[1].Activate();
            if (Display.displays.Length > 2)
                Display.displays[2].Activate();
        }

    }
}


//public int m_width = 1600;
//public int m_height = 900;
//public int m_freshRate = 90;

//void Start()
//{
//    Debug.Log("displays connected: " + Display.displays.Length);

//    Display.displays[0].Activate(m_width, m_height, m_freshRate);
//    // Display.displays[0] is the primary, default display and is always ON.
//    // Check if additional displays are available and activate each.
//    if (Display.displays.Length > 1)
//        Display.displays[1].Activate(m_width, m_height, m_freshRate);
//    if (Display.displays.Length > 2)
//        Display.displays[2].Activate(m_width, m_height, m_freshRate);
//}