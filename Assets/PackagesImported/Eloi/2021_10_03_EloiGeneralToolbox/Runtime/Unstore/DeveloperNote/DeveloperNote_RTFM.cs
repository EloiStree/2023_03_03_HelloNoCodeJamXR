using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DeveloperNote_RTFM : DeveloperNote_Links
    {
        [ContextMenu("Open RTFM")]
        public void OpenRTFM() {
            base.OpenLinks();
        }
        protected override void OnValidate()
        {
            base.OnValidate();
        }
    }
}
