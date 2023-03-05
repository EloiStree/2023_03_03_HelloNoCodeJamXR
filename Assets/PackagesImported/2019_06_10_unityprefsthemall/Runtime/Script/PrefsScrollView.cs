using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class PrefsScrollView : QuickPrefsSaveBehviourAbstract
{
    public ScrollRect m_linked;


    protected override void FindAndLinkcomponent()
    {
        m_linked = GetComponent<ScrollRect>();
    }

    protected override string GetDataToSave()
    {
        Vector2 value = new Vector2(m_linked.horizontalNormalizedPosition, m_linked.verticalNormalizedPosition);
        return JsonUtility.ToJson(value);


    }
    protected override void ResetDataWith(string savedInfo)
    {
        Vector2 value = JsonUtility.FromJson<Vector2>(savedInfo);
        m_linked.horizontalNormalizedPosition = value.x;
        m_linked.verticalNormalizedPosition = value.y;
    }
}
