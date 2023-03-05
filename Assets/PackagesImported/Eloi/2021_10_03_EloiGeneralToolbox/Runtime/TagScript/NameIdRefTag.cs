using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class NameIdRefTag : MonoBehaviour
    {
        public StringIdScriptable m_associatedIdName;

        public void GetName(out string name) {

            if (m_associatedIdName == null)
                name= "";
            else
               name = m_associatedIdName.GetValue();
        }
        public string GetName() {
            if (m_associatedIdName == null)
                return "";
            return m_associatedIdName.GetValue(); }
        public void GetStringId(out StringIdScriptable name) { name = m_associatedIdName; }
        public StringIdScriptable GetStringID() { return m_associatedIdName; }

            
    }
   

}
