
using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace be.eloistree.generaltoolbox
{
    public class UIToggleFieldPlayerPrefs : AbstractPlayerPrefs
    {

        public bool m_toggleValue;
        public Eloi.PrimitiveUnityEvent_Bool m_reloadToggleValue;
        protected override void Reset()
        {
            base.Reset();
        }
        public void SetToggleValue(bool isOnValue) {
            m_toggleValue = isOnValue;
        }

        public override void GetInfoToStoreAsString(out string infoToStore)
        {
            infoToStore = m_toggleValue ? "1" : "0";
        }

        public override void SetWithStoredInfoFromString(string recoveredInfo)
        {
            recoveredInfo = recoveredInfo.Trim();
            if (recoveredInfo.Length == 1)
            {
                m_reloadToggleValue.Invoke( recoveredInfo[0] == '1');
            }
        }
    }
}
