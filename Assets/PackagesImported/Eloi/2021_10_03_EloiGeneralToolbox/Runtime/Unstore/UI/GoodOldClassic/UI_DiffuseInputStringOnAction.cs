using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Eloi
{
    public class UI_DiffuseInputStringOnAction : MonoBehaviour
    {

        public Eloi.PrimitiveUnityEvent_String m_pushed;
        public InputField m_target;


        public void PushInputFieldValue()
        {
            m_pushed.Invoke(m_target.text);
        }

    }

}