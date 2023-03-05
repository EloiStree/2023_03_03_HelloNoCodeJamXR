using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class Convert_StringToPrimitive : MonoBehaviour
    {

        public Events m_pushRelay;
        [System.Serializable]
        public class Events { 
           public Eloi.PrimitiveUnityEvent_Bool        m_bool   ;
           public Eloi.PrimitiveUnityEvent_Float       m_float  ;
           public Eloi.PrimitiveUnityEvent_Doube       m_double ;
           public Eloi.PrimitiveUnityEvent_Byte        m_byte   ;
           public Eloi.PrimitiveUnityEvent_Short       m_short  ;
           public Eloi.PrimitiveUnityEvent_Int         m_int    ;
           public Eloi.PrimitiveUnityEvent_Long        m_long   ;
           public Eloi.PrimitiveUnityEvent_UShort      m_ushort ;
           public Eloi.PrimitiveUnityEvent_UInt        m_uint   ;
           public Eloi.PrimitiveUnityEvent_ULong       m_ulong  ;
        }
        public void Push(string text) {

            if (bool.TryParse(text, out bool boolValue)) m_pushRelay.m_bool   .Invoke(boolValue);
            if (float.TryParse(text, out float floatValue)) m_pushRelay.m_float  .Invoke(floatValue);
            if (double.TryParse(text, out double doubleValue)) m_pushRelay.m_double .Invoke(doubleValue);
            if (byte.TryParse(text, out byte byteValue)) m_pushRelay.m_byte   .Invoke(byteValue);
            if (short.TryParse(text, out short shortValue)) m_pushRelay.m_short  .Invoke(shortValue);
            if (int.TryParse(text, out int intValue)) m_pushRelay.m_int    .Invoke(intValue);
            if (long.TryParse(text, out long longValue)) m_pushRelay.m_long   .Invoke(longValue);
            if (ushort.TryParse(text, out ushort ushortValue)) m_pushRelay.m_ushort .Invoke(ushortValue);
            if (uint.TryParse(text, out uint uintValue)) m_pushRelay.m_uint   .Invoke(uintValue);
            if (ulong.TryParse(text, out ulong ulongValue)) m_pushRelay.m_ulong  .Invoke(ulongValue);


        }
    }
}
