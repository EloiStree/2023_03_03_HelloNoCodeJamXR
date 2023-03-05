using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace be.eloistree.generaltoolbox
{
    public abstract class GetTimeMono : MonoBehaviour
    {

        public abstract void GetTime(out float time);
        public abstract float GetTime();
    }
}
