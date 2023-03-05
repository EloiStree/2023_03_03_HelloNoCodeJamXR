using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class TextToPrimitiveRelayMono : MonoBehaviour
    {
       public PrimitiveUnityEvent_Short m_asShort;
       public PrimitiveUnityEvent_Byte m_asByte;
       public PrimitiveUnityEvent_Int m_asInt;
       public PrimitiveUnityEvent_Float m_asFloat;
       public PrimitiveUnityEvent_Long m_asLong;
       public PrimitiveUnityEvent_Doube m_asDouble;
       public PrimitiveUnityEvent_Bool m_asBool;
       public void PushText(string textReceived)
        {
            if (short.TryParse(textReceived, out short sresult))
                m_asShort.Invoke(sresult);
            if (byte.TryParse(textReceived, out byte bresult))
                m_asByte.Invoke(bresult);
            if (int.TryParse(textReceived, out int iresult))
                m_asInt.Invoke(iresult);
            if (float.TryParse(textReceived, out float fresult))
                m_asFloat.Invoke(fresult);
            if (double.TryParse(textReceived, out double dresult))
                m_asDouble.Invoke(dresult);
            if (bool.TryParse(textReceived, out bool bbresult))
                m_asBool.Invoke(bbresult);
            if (long.TryParse(textReceived, out long lresult))
                m_asLong.Invoke(lresult);
        }
       
    }
}
