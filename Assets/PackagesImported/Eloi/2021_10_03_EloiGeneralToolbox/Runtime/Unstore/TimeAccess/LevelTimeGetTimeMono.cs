using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace be.eloistree.generaltoolbox
{
    public class LevelTimeGetTimeMono : GetTimeMono
    {
        public float m_time;
        public override void GetTime(out float time) { time = m_time = Time.timeSinceLevelLoad; }
        public override float GetTime() { return m_time = Time.timeSinceLevelLoad; }
    }
}
