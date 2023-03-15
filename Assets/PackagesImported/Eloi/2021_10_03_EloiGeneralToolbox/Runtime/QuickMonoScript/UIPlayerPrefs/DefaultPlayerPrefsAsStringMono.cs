using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DefaultPlayerPrefsAsStringMono : AbstractPlayerPrefs
    {
        public string m_textToStore;
        public Eloi.PrimitiveUnityEvent_String m_onSetCalled;
        public override void GetInfoToStoreAsString(out string infoToStore)
        {
            infoToStore = m_textToStore;
        }

        public override void SetWithStoredInfoFromString(string recoveredInfo)
        {
            m_onSetCalled.Invoke(m_textToStore);
        }
    }
}
