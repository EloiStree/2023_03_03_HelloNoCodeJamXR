
using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace be.eloistree.generaltoolbox
{
    public class UIInputFieldPlayerPrefs : AbstractPlayerPrefs
    {
        public InputField m_inputfield;      
        protected override void Reset()
        {
            base.Reset();
            m_inputfield = GetComponent<InputField>();
        }
       
        public override void GetInfoToStoreAsString(out string infoToStore)
        {
            infoToStore = m_inputfield.text;
        }

        public override void SetWithStoredInfoFromString(string recoveredInfo)
        {
            m_inputfield.text = recoveredInfo;
            //m_id = "" + Guid.NewGuid();
        }
    }
}
