using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshTexture2DWithGroupIdMono : MonoBehaviour
{
    public AbstractGroupIdMono m_groupIdFocus;
    public GroupID2Texture2DCollectionMono m_collection;
    public Texture2D m_defaultTexture;
    public Eloi.ClassicUnityEvent_Texture2D m_textureFound;


    [ContextMenu("Push Focus Selected")]
    public void PushSelected() {

        m_collection.SearchForTexture(m_groupIdFocus, out bool found, out Texture2D founded);
        if (found)
            m_textureFound.Invoke(founded);
        else
            m_textureFound.Invoke(m_defaultTexture);

    }

}
