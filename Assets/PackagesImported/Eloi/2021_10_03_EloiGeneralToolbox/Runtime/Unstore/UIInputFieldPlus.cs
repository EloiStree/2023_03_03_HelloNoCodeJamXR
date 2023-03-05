using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Eloi
{
    public class UIInputFieldPlus : MonoBehaviour
    {
        public InputField m_inputField;

        public void SetTextAs(int value) => m_inputField.text = ""+value;

        private void Reset()
        {
            m_inputField = GetComponent<InputField>();
        }
    }
}
