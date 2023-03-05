using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class Convert_JsonFromToObject<T> : MonoBehaviour
    {
        [Header("Json 2 Object")]
        public string m_receivedJson;
        public T m_convertedObject;
        public DefaultBooleanChangeListener m_receivedJsonConverted;
        public Eloi.GenericObjectEvent<T> m_jsonToObjectEvent;

        [Header("Object 2 Json")]
        public T m_receivedObject;
        public string m_convertedJson;
        public DefaultBooleanChangeListener m_receivedObjectConverted;
        public Eloi.PrimitiveUnityEvent_String m_objectToJsonEvent;

        public void PushJsonToObject(string json)
        {

            m_receivedJson = json;
            try {
                T o = JsonUtility.FromJson<T>(json);
                m_convertedObject = o;
                m_jsonToObjectEvent.Invoke(o);

                m_receivedJsonConverted.SetBoolean(true);
            }
            catch (Exception) {
                m_receivedJsonConverted.SetBoolean(false);
            }

        }
        public void PushObjectToJson(T targetToConvert)
        {
            m_receivedObject = targetToConvert;
            try
            {
                string json = JsonUtility.ToJson(targetToConvert);
                m_convertedJson = json;
                m_objectToJsonEvent.Invoke(json);

                m_receivedObjectConverted.SetBoolean(true);
            }
            catch (Exception)
            {
                m_receivedObjectConverted.SetBoolean(false);
            }

        }


    }
}
