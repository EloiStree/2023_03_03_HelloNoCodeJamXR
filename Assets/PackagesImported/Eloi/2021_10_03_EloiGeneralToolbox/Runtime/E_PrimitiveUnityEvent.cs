using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    [System.Serializable]
    public class PrimitiveUnityEvent_Short : UnityEvent<short> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Byte : UnityEvent<byte> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Int : UnityEvent<int> { }

    [System.Serializable]
    public class PrimitiveUnityEvent_Float : UnityEvent<float> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Long : UnityEvent<long> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Doube : UnityEvent<double> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_IntPtr : UnityEvent<IntPtr> { }

    [System.Serializable]
    public class PrimitiveUnityEvent_Bool : UnityEvent<bool> { }
    [System.Serializable]
    public class PrimitiveUnityEventExtra_Bool {

        public  PrimitiveUnityEvent_Bool m_valueEvent;
        public  UnityEvent m_onEvent;
        public  UnityEvent m_offEvent;

        public void Invoke(bool value)
        {
            m_valueEvent.Invoke(value);
            if(value)
            m_onEvent.Invoke();
            else
            m_offEvent.Invoke();
        }
    }

    [System.Serializable]
    public class PrimitiveUnityEvent_String : UnityEvent<string> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Char : UnityEvent<char> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_StringArray : UnityEvent<string[]> { }

    [System.Serializable]
    public class PrimitiveUnityEvent_DoubleString : UnityEvent<string, string> { }

    [System.Serializable]
    public class PrimitiveUnityEvent_UShort : UnityEvent<ushort> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_UInt : UnityEvent<uint> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_ULong : UnityEvent<ulong> { }


    [System.Serializable]
    public class ClassicUnityEvent_Texture2D : UnityEvent<Texture2D> { }

    [System.Serializable]
    public class ClassicUnityEvent_Texture : UnityEvent<Texture> { }

    [System.Serializable]
    public class ClassicUnityEvent_RenderTexture : UnityEvent<RenderTexture> { }
    [System.Serializable]
    public class ClassicUnityEvent_Color : UnityEvent<Color> { }

    [System.Serializable]
    public class GenericObjectEvent<T> : UnityEvent<T> { }

    [System.Serializable]
    public class ClassicUnityEvent_Vector3 : UnityEvent<Vector3> { }
    [System.Serializable]
    public class ClassicUnityEvent_Vector2 : UnityEvent<Vector2> { }
    [System.Serializable]
    public class ClassicUnityEvent_Quaternion : UnityEvent<Quaternion> { }

}