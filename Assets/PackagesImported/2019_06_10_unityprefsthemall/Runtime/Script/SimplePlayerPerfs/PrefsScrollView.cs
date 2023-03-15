
using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class PrefsScrollView : AbstractPlayerPrefs
{
    public ScrollRect m_linked;

    public override void GetInfoToStoreAsString(out string infoToStore)
    {
        Vector2 value = new Vector2(m_linked.horizontalNormalizedPosition, m_linked.verticalNormalizedPosition);
        infoToStore= JsonUtility.ToJson(value);
    }

    public override void SetWithStoredInfoFromString(string recoveredInfo)
    {
        Vector2 value = JsonUtility.FromJson<Vector2>(recoveredInfo);
        m_linked.horizontalNormalizedPosition = value.x;
        m_linked.verticalNormalizedPosition = value.y;
    }

    protected  void Reset()
    {
        m_linked = GetComponent<ScrollRect>();
    }

    

}
