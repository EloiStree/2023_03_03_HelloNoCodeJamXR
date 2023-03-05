using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture2DToMaterialMono : MonoBehaviour
{
    public Material m_target;
    public string m_textureName="_Base";

    public Texture2D m_texture;
    public void PushTexture2D(Texture2D texture)
    {
        m_texture = texture;
        m_target.mainTexture = m_texture;
        m_target.SetTexture(m_textureName, m_texture);
    }

}
