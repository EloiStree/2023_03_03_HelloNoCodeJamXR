using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public abstract class AbstractImportantStringMono : MonoBehaviour
    {
        public string GetStringValue() { GetStringValue(out string v); return v; }
        public abstract void GetStringValue(out string value);

        [ContextMenu("Debug Log the string")]
        public void DebugLogString()
        {
            GetStringValue(out string value);
            Debug.Log("Import string:" + value);
        }
    }
}
