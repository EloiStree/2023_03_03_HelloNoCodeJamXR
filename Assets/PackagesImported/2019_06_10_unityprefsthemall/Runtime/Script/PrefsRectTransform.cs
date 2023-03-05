using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PrefsRectTransform : QuickPrefsSaveAbstract
{
    [Header("Specific")]
    public RectTransform m_linked;
    public bool m_savePosition = true;
    public bool m_saveRotation = true;
    public bool m_saveScale = true;
    public bool m_saveRect = true;
    public bool m_saveAnchors = true;
    public int m_precision = 2;


    [Header("Debug")]
    public RectTransformSave m_saved;
    [System.Serializable]
    public class RectTransformSave
    {
        public float px, py, pz;
        public float rx, ry, rz, rw;
        public float sx, sy, sz;
        public float rex, rey, rew, reh;
        public float six, siy;
        public float aminx, amaxx, aminy, amaxy;
        public float pix, piy;
    }

    public void Awake()
    {
        LinkTheComponent();
    }

    protected override string GetDataToSave()
    {
        RectTransformSave save = new RectTransformSave();
        if (m_savePosition)
        {
            save.px = RoundToPrecisionValue(m_linked.position.x);
            save.py = RoundToPrecisionValue(m_linked.position.y);
            save.pz = RoundToPrecisionValue(m_linked.position.z);

        }
        if (m_saveRotation)
        {
            save.rx = RoundToPrecisionValue(m_linked.rotation.x);
            save.ry = RoundToPrecisionValue(m_linked.rotation.y);
            save.rz = RoundToPrecisionValue(m_linked.rotation.z);
            save.rw = RoundToPrecisionValue(m_linked.rotation.w);

        }
        if (m_saveScale)
        {
            save.sx = RoundToPrecisionValue(m_linked.localScale.x);
            save.sy = RoundToPrecisionValue(m_linked.localScale.y);
            save.sz = RoundToPrecisionValue(m_linked.localScale.z);

        }
        if (m_saveAnchors)
        {
            save.pix = RoundToPrecisionValue (m_linked.anchoredPosition.x);
            save.piy = RoundToPrecisionValue(m_linked.anchoredPosition.y);
            save.aminx = RoundToPrecisionValue(m_linked.anchorMin.x);
            save.aminy = RoundToPrecisionValue(m_linked.anchorMin.y);
            save.amaxx = RoundToPrecisionValue(m_linked.anchorMax.x);
            save.amaxy = RoundToPrecisionValue(m_linked.anchorMax.y);

        }
        if (m_saveRect)
        {
            save.rex = RoundToPrecisionValue(m_linked.rect.x);
            save.rey = RoundToPrecisionValue(m_linked.rect.y);
            save.rew = RoundToPrecisionValue(m_linked.rect.width);
            save.reh = RoundToPrecisionValue(m_linked.rect.height);
            save.six = RoundToPrecisionValue(m_linked.sizeDelta.x);
            save.siy = RoundToPrecisionValue(m_linked.sizeDelta.y);
        }

       

        m_saved = save;
        return JsonUtility.ToJson(save);


    }
    protected override void ResetDataWith(string savedInfo)
    {
        RectTransformSave saved = JsonUtility.FromJson<RectTransformSave>(savedInfo);
        if (m_savePosition)
        {
            m_linked.position = new Vector3(saved.px, saved.py, saved.pz);
        }
        if (m_saveRotation)
        {
            m_linked.rotation = new Quaternion(saved.rx, saved.ry, saved.rz, saved.rw);
        }
        if (m_saveScale)
        {
            m_linked.localScale = new Vector3(saved.sx, saved.sy, saved.sz);
        }
        if (m_saveAnchors)
        {
            m_linked.anchoredPosition = new Vector2(saved.pix, saved.piy);
            m_linked.anchorMin = new Vector2(saved.aminx, saved.aminy);
            m_linked.anchorMax = new Vector2(saved.amaxx, saved.amaxy);

        }
        if (m_saveRect)
        {
            m_linked.sizeDelta = new Vector2(saved.six, saved.siy);
            m_linked.rect.Set(saved.rex, saved.rey, saved.rew, saved.reh);
        }

    }


    public float RoundToPrecisionValue(float value)
    {
        //return Mathf.Round(value * m_precision * 10f) / m_precision * 10f;
        return (float)System.Math.Round((double)value, m_precision);
    }



    public new void OnValidate()
    {
        base.OnValidate();
        LinkTheComponent();
    }
    public new void Reset()
    {
        base.Reset();
        LinkTheComponent();
    }

    private void LinkTheComponent()
    {
        m_linked = GetComponent<RectTransform>();
    }
}
