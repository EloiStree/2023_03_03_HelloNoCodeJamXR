using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi {

   

public abstract class AbstractRelayPrimitiveMono<T> : MonoBehaviour
    {
        public T m_givenValue;
        public AbstractDirectRelayPrimitive<T> m_directRelay;
        public AbstractOnChangedRelayPrimitive<T> m_onChangedRelay;


        public  virtual void RepushLastGivenValue()
        {
            Push(m_givenValue);
        }
        public void Push(T value)
        {
            m_givenValue = value;
            m_directRelay.PushInRef(in value);
            m_onChangedRelay.PushInRef(in value);
            NotifyChildren(in value);
        }
        public void PushInRef(in T value)
        {
            m_givenValue = value;
            m_directRelay.PushInRef(in value);
            m_onChangedRelay.PushInRef(in value);
            NotifyChildren(in value);
        }
        public virtual void NotifyChildren(in T value) { }
    }



    [System.Serializable]
    public class AbstractRelayPrimitive<T>
    {
        public T m_lastReceived;
        public Action<T> m_devListener;
        public PrimitiveRelay m_relayListener = new PrimitiveRelay();

        [System.Serializable]
        public class PrimitiveRelay : UnityEvent<T> { }

    }

    [System.Serializable]
    public class AbstractDirectRelayPrimitive<T> : AbstractRelayPrimitive<T>
    {
        public void Push(T value)
        {
            m_lastReceived = value;
            if (m_devListener != null)
                m_devListener(value);
            m_relayListener.Invoke(value);
            NotifyChildren(in value);
        }
        public void PushInRef(in T value)
        {
            m_lastReceived = value;
            if (m_devListener != null)
                m_devListener(value);
            m_relayListener.Invoke(value);
            NotifyChildren(in value);
        }

        public virtual void NotifyChildren(in T value) { }
    }


    [System.Serializable]
    public class AbstractOnChangedRelayPrimitive<T> :AbstractRelayPrimitive<T>
    {
       

        public void Push(T value)
        {
            if (!AreEqualsWithPrevious(in value))
            {
                if (m_devListener != null)
                    m_devListener(value);
                m_relayListener.Invoke(value);
                NotifyNewValueToChildren(in value);
                NotifyNewValueToChildren(in value, m_lastReceived);
                m_lastReceived = value;
            }
        }
        public void PushInRef(in T value)
        {
            if (!AreEqualsWithPrevious(in value)) { 
                if (m_devListener != null)
                    m_devListener(value);
                m_relayListener.Invoke(value);
                NotifyNewValueToChildren(in value);
                NotifyNewValueToChildren(in value, m_lastReceived);
                m_lastReceived = value;
            }
        }
        public  bool AreEqualsWithPrevious(in T value)
        {
            return AreEquals(in m_lastReceived, in value);
        }
        public virtual bool AreEquals(in T value, in T value2)
        {
            return value.Equals(value2);
        }

        public virtual void NotifyNewValueToChildren(in T value) { }
        public virtual void NotifyNewValueToChildren(in T newValue, in T previousValue) { }
    }



    //[System.Serializable] public class RelayPrimitiveIntPtrMono : AbstractRelayPrimitiveMono<IntPtr> { }
    //    //[System.Serializable] public class RelayPrimitiveBoolMono : AbstractRelayPrimitiveMono<bool> { }
    //    //[System.Serializable] public class RelayPrimitiveDoubleMono : AbstractRelayPrimitiveMono<double> { }
    //    [System.Serializable] public class RelayPrimitiveFloatMono : AbstractRelayPrimitiveMono<float> { }
    //[System.Serializable] public class RelayPrimitiveStringMono : AbstractRelayPrimitiveMono<string> { }
    //[System.Serializable] public class RelayPrimitiveStringArrayMono : AbstractRelayPrimitiveMono<string[]> { }
    //[System.Serializable] public class RelayPrimitiveCharMono : AbstractRelayPrimitiveMono<char> { }
    //[System.Serializable] public class RelayPrimitiveUshortMono : AbstractRelayPrimitiveMono<ushort> { }
    //[System.Serializable] public class RelayPrimitiveUintMono : AbstractRelayPrimitiveMono<uint> { }
    //    //[System.Serializable] public class RelayPrimitiveUlongMono : AbstractRelayPrimitiveMono<ulong> { }
    //    [System.Serializable] public class RelayPrimitiveShortMono : AbstractRelayPrimitiveMono<short> { }
    //    //[System.Serializable] public class RelayPrimitiveIntMono : AbstractRelayPrimitiveMono<int> { }
    //    [System.Serializable] public class RelayPrimitiveLongMono : AbstractRelayPrimitiveMono<long> { }
    //    //[System.Serializable] public class RelayPrimitiveByteMono : AbstractRelayPrimitiveMono<byte> { }
    //    //[System.Serializable] public class RelayPrimitiveTexture2DMono : AbstractRelayPrimitiveMono<Texture2D> { }
    //    [System.Serializable] public class RelayPrimitiveTextureMono : AbstractRelayPrimitiveMono<Texture> { }
    //[System.Serializable] public class RelayPrimitiveRenderTextureMono : AbstractRelayPrimitiveMono<RenderTexture> { }
    //[System.Serializable] public class RelayPrimitiveColorMono : AbstractRelayPrimitiveMono<Color> { }

    [System.Serializable]public class RelayPrimitiveIntPtr : AbstractDirectRelayPrimitive<IntPtr              > { }
[System.Serializable]public class RelayPrimitiveBool : AbstractDirectRelayPrimitive<bool                  > { }
[System.Serializable]public class RelayPrimitiveDouble : AbstractDirectRelayPrimitive<double              > { }
[System.Serializable]public class RelayPrimitiveFloat : AbstractDirectRelayPrimitive<float                > { }
[System.Serializable]public class RelayPrimitiveString : AbstractDirectRelayPrimitive<string              > { }
[System.Serializable]public class RelayPrimitiveStringArray : AbstractDirectRelayPrimitive<string[]          > { }
[System.Serializable]public class RelayPrimitiveChar : AbstractDirectRelayPrimitive<char                  > { }
[System.Serializable]public class RelayPrimitiveUshort : AbstractDirectRelayPrimitive<ushort              > { }
[System.Serializable]public class RelayPrimitiveUint : AbstractDirectRelayPrimitive<uint                  > { }
[System.Serializable]public class RelayPrimitiveUlong : AbstractDirectRelayPrimitive<ulong                > { }
[System.Serializable]public class RelayPrimitiveShort : AbstractDirectRelayPrimitive<short                > { }
[System.Serializable]public class RelayPrimitiveInt : AbstractDirectRelayPrimitive<int                    > { }
[System.Serializable]public class RelayPrimitiveLong : AbstractDirectRelayPrimitive<long                  > { }
[System.Serializable]public class RelayPrimitiveByte : AbstractDirectRelayPrimitive<byte                  > { }
[System.Serializable]public class RelayPrimitiveTexture2D : AbstractDirectRelayPrimitive<Texture2D        > { }
[System.Serializable]public class RelayPrimitiveTexture : AbstractDirectRelayPrimitive<Texture            > { }
[System.Serializable]public class RelayPrimitiveRenderTexture : AbstractDirectRelayPrimitive<RenderTexture> { }
[System.Serializable]public class RelayPrimitiveColor : AbstractDirectRelayPrimitive<Color> { }

}