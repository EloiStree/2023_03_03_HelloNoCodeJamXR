using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupID2Texture2DCollectionMono : MonoBehaviour
{

    public List<GroupIdToTexture2D> m_groupIdToMasks= new List<GroupIdToTexture2D>();
    public Texture2D m_default;
    public bool m_useTrim;
    public bool m_useIgnoreCase;
    public Eloi.ClassicUnityEvent_Texture2D m_pushMask;
    public void PushTexture( string groupId, string elementId) {

        IAbstractGroupId id = new GroupId(groupId, elementId);
        SearchForTexture(id, out bool found, out Texture2D texture);
        if (found) {
            if (texture == null)
                texture = m_default;
            m_pushMask.Invoke(texture);

        }

    }

    public void SearchForTexture(IAbstractGroupId groupId, out bool found, out Texture2D texture) {

        GroupIDSearchUtility.SearchForFirst<Texture2D>(
            in groupId,
            in m_groupIdToMasks,
            out found,
            out texture,
            in m_default,
            in m_useTrim,
            in m_useIgnoreCase); 
    }
}


public class GroupIDSearchUtility {

    public static void SearchForFirst<T>(
        in IAbstractGroupId id, 
        in List<GroupIdToTexture2D> list,
        out bool found,
        out Texture2D element, 
        in Texture2D defaultIfNotFound,
        in bool useLow, 
        in bool useTrim)
    {
        found = false;
        element = defaultIfNotFound;

        if (id == null)
            return;
        if (list == null)
            return;
        for (int i = 0; i < list.Count; i++)
        {
            GroupIdToTexture2D value = list[i];
            id.GetGroupId(out string groupId);
            id.GetElementId(out string elementId);
            if (value != null &&
                Eloi.E_StringUtility.AreEquals(in groupId, in value.m_groupId.m_groupId, in useLow, in useTrim)
         && Eloi.E_StringUtility.AreEquals(in elementId, in value.m_groupId.m_elementId, in useLow, in useTrim))
            {
                found = true;
                element = value.m_target;
                return;
            }
        }

    }

        public static void SearchForFirst<T>(in IAbstractGroupId id, in List<GroupIdToGeneric<T>> list, out bool found, out T element, in T defaultIfNotFound, in bool useLow, in bool useTrim) {
        found = false;
        element = defaultIfNotFound;

        if (id == null)
            return;
        if (list == null)
            return;
        for (int i = 0; i < list.Count; i++)
        {
            GroupIdToGeneric<T> value = list[i];
            id.GetGroupId(out string groupId);
            id.GetElementId(out string elementId);
            if (value !=null &&
                Eloi.E_StringUtility.AreEquals(in groupId, in value.m_groupId.m_groupId, in useLow, in useTrim)
         && Eloi.E_StringUtility.AreEquals(in elementId, in value.m_groupId.m_elementId, in useLow, in useTrim) )
            {
                found = true;
                element = value.m_target;
                return;
            }
        }

    }

}


[System.Serializable]
public class GroupIdToTexture2D : GroupIdToGeneric<Texture2D>
{ }


public class GroupIdToGeneric<T> : IAbstractGroupId
{
    public GroupId m_groupId;
    public T m_target;

    public void GetElementId(out string elementId)
    {
        m_groupId.GetElementId(out elementId);
    }

    public void GetGroupId(out string groupId)
    {
        m_groupId.GetElementId(out groupId);
    }
}


[System.Serializable]
public class GroupId : IAbstractGroupId
{
    public string m_groupId;
    public string m_elementId;

    public GroupId()
    {
        m_groupId = "";
        m_elementId = "";
    }
    public GroupId(string groupId, string elementId)
    {
        m_groupId = groupId;
        m_elementId = elementId;
    }

    public void GetElementId(out string elementId)
    {
        elementId = m_elementId;
    }

    public void GetGroupId(out string groupId)
    {
        groupId = m_groupId;
    }
}
