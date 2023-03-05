using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnablerSetFromStatic : MonoBehaviour
{
   
    public static float m_percentChangeToAppearGlobal = 0.3333f;
    public void SetPercentChanceToAppear(float percentChanceToAppear) {
        m_percentChangeToAppearGlobal = percentChanceToAppear;
    }
    public static void GetPercentChance(out float percentChanceToAppear) {
        percentChanceToAppear = m_percentChangeToAppearGlobal;
    }
}
