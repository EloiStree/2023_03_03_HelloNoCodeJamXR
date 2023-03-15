﻿
using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PrefsTransform : AbstractPlayerPrefs
{
    [Header("Specific")]
    public Transform m_linked;
    public bool m_savePosition=true;
    public bool m_saveRotation=true;
    public bool m_saveScale=true;
    public Space m_worldSpaceUse = Space.World;
    public int m_precision=2;


    [Header("Debug")]
    public TransformSave m_saved;
    [System.Serializable]
    public class TransformSave {
        public float px, py, pz;
        public float rx, ry, rz, rw;
        public float sx, sy, sz;
    }

    public new void Awake()
    {
        base.Awake();
    }

   


    public float  RoundToPrecisionValue(float value) {
        //return Mathf.Round(value * m_precision * 10f) / m_precision * 10f;
        return  (float)System.Math.Round((double)value, m_precision);
    }

  

    public   void OnValidate()
    {
        LinkTheComponent();
    }
    public new void Reset()
    {
        base.Reset();
        LinkTheComponent();
    }

    private void LinkTheComponent()
    {
        if(m_linked==null)
        m_linked = GetComponent<Transform>();
    }

    public override void GetInfoToStoreAsString(out string infoToStore)
    {
        TransformSave save = new TransformSave();
        if (m_worldSpaceUse == Space.World)
        {
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
        }
        else
        {

            if (m_savePosition)
            {
                save.px = RoundToPrecisionValue(m_linked.localPosition.x);
                save.py = RoundToPrecisionValue(m_linked.localPosition.y);
                save.pz = RoundToPrecisionValue(m_linked.localPosition.z);

            }
            if (m_saveRotation)
            {
                save.rx = RoundToPrecisionValue(m_linked.localRotation.x);
                save.ry = RoundToPrecisionValue(m_linked.localRotation.y);
                save.rz = RoundToPrecisionValue(m_linked.localRotation.z);
                save.rw = RoundToPrecisionValue(m_linked.localRotation.w);

            }
            if (m_saveScale)
            {
                save.sx = RoundToPrecisionValue(m_linked.localScale.x);
                save.sy = RoundToPrecisionValue(m_linked.localScale.y);
                save.sz = RoundToPrecisionValue(m_linked.localScale.z);

            }
        }
        m_saved = save;
        infoToStore= JsonUtility.ToJson(save);
    }

    public override void SetWithStoredInfoFromString(string recoveredInfo)
    {
        TransformSave saved = JsonUtility.FromJson<TransformSave>(recoveredInfo);
        if (saved == null)
        {
            GetInfoToStoreAsString(out string defaultInfo);
            saved = JsonUtility.FromJson<TransformSave>(defaultInfo);
        }
        if (m_worldSpaceUse == Space.World)
        {

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
        }
        else
        {

            if (m_savePosition)
            {
                m_linked.localPosition = new Vector3(saved.px, saved.py, saved.pz);
            }
            if (m_saveRotation)
            {
                m_linked.localRotation = new Quaternion(saved.rx, saved.ry, saved.rz, saved.rw);
            }
            if (m_saveScale)
            {
                m_linked.localScale = new Vector3(saved.sx, saved.sy, saved.sz);
            }
        }
    }
}
