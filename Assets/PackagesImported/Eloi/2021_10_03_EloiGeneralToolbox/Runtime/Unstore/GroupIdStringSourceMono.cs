using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupIdStringSourceMono : AbstractGroupIdMono
{

    public string m_groupId;
    public string m_elementId;
    public Eloi.PrimitiveUnityEvent_DoubleString m_pushed;

    public override void GetElementId(out string elementId)
    {
        elementId = m_elementId;
    }

    public override void GetGroupId(out string groupId)
    {
        groupId = m_groupId;
    }

    [ContextMenu("Push")]
    public void Push()
    {
        Push(m_groupId, m_elementId);
    }
    public void Push(string group, string elementId)
    {
        m_groupId = group ;
        m_elementId=elementId ;
        
        m_pushed.Invoke(m_groupId, m_elementId);
    }

    public void SetAsFullEmpty()
    {
        m_groupId = "";
        m_elementId = "";
    }

}


public abstract class AbstractGroupIdMono :MonoBehaviour,  IAbstractGroupId
{
    public abstract void GetGroupId(out string groupId);
    public abstract void GetElementId(out string elementId);
}

public interface IAbstractGroupId
{
    void GetGroupId(out string groupId);
    void GetElementId(out string elementId);
}