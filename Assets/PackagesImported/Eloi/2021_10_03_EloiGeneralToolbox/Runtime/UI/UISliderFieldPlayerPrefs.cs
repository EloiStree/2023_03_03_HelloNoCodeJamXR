
using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace be.eloistree.generaltoolbox
{
    public class UISliderFieldPlayerPrefs : AbstractPlayerPrefs
    {
        public Slider m_inputfield;
        protected override void Reset()
        {
            base.Reset();
            m_inputfield = GetComponent<Slider>();
        }

        public override void GetInfoToStoreAsString(out string infoToStore)
        {
            infoToStore = m_inputfield.value.ToString();
        }

        public override void SetWithStoredInfoFromString(string recoveredInfo)
        {
            float.TryParse(recoveredInfo, out float value);
            m_inputfield.value = value;
        }
    }
}
