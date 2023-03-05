using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class AvoidSleepingMono : MonoBehaviour
    {
       
        void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}
