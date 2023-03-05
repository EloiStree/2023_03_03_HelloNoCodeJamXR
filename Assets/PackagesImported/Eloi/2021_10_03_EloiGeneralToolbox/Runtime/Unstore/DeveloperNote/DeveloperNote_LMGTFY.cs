using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DeveloperNote_LMGTFY : DeveloperNote_Links
    {

        [ContextMenu("Let's me google that for you")]
        public void OpenLMGTFY()
        {
                base.OpenLinks();
            
        }

        protected override void OnValidate()
        {
            base.OnValidate();
        }
    }
}
