using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace be.eloistree.generaltoolbox
{
    public class UISet_TextAppend : MonoBehaviour
    {
        public Text m_affected;

        public void AppendStart(string text)
        {
            m_affected.text = text + m_affected.text;
        }
        public void AppendEnd(string text)
        {
            m_affected.text = m_affected.text + text;

        }
        public void AppendStartWithLineReturn(string text)
        {
            m_affected.text = text + "\n" + m_affected.text;
        }
        public void AppendEndWithLineReturn(string text)
        {
            m_affected.text = m_affected.text +"\n"+ text;

        }

        private void Reset()
        {
            m_affected = GetComponent<Text>();
        }
    }
}
