using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class UnprotectedEditorImportantStringMono : AbstractImportantStringMono
    {
        public HiddenString m_hiddenValue;

        public override void GetStringValue(out string value)
        {
            value = m_hiddenValue.m_value;
        }

        [System.Serializable]
        public class HiddenString {
            public string m_value;
        }
    }
}
