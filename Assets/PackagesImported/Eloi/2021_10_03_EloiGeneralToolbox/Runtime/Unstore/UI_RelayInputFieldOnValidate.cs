using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RelayInputFieldOnValidate : MonoBehaviour
{

    public InputField m_inputField;
    public Eloi.PrimitiveUnityEvent_String m_pushOnValidate;


    public void PushInputField() {
        m_pushOnValidate.Invoke(m_inputField.text);
    }
}
