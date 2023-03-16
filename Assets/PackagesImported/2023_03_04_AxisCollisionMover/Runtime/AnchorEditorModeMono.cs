using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorEditorModeMono : MonoBehaviour
{

    [ContextMenu("Hide all Anchor")]
    public void HideAllAnchors() {
        AnchorEditorMode.HideAll();
    }
    [ContextMenu("Display All Anchors")]
    public void DisplayAllAnchors()
    {
        AnchorEditorMode.DisplayAll();
    }
    [ContextMenu("Switch Display All Anchors")]
    public void SwitchDisplayAllAnchors()
    {
        AnchorEditorMode.SwitchDisplayAll();
    }

    private string m_playerPrefsKey= "AnchorEditorModeMono";
    private void Start()
    {
        if (PlayerPrefs.HasKey(m_playerPrefsKey))
        {
            string value =PlayerPrefs.GetString(m_playerPrefsKey);
            if (value.Length > 0 && value[0] == 'h')
                AnchorEditorMode.HideAll();
            else
                AnchorEditorMode.DisplayAll();
        }
        else {
            AnchorEditorMode.DisplayAll();
        }
    }
    private void OnApplicationQuit()
    {
        SaveAnchorEditorStateInPlayerPrefs();
    }
    private void OnDestroy()
    {
        SaveAnchorEditorStateInPlayerPrefs();
    }

    private void SaveAnchorEditorStateInPlayerPrefs()
    {
        PlayerPrefs.SetString(m_playerPrefsKey, AnchorEditorMode.IsLastHiddenRequest() ? "h" : "d");
    }
}


public class AnchorEditorMode {

    public enum HideDisplayMode { HideAll, DisplayAll}
    public static HideDisplayMode m_lastRequestedDisplayType;
    public static void HideAll()
    {
        m_lastRequestedDisplayType = HideDisplayMode.HideAll;
        EditAnchorTagMono[] editorTag = new EditAnchorTagMono[0];
        Eloi.E_SearchInSceneUtility.TryToFetchWithInScene(ref editorTag);
        foreach (var item in editorTag)
        {
            item.Hide();
        }
    }
    public static void DisplayAll()
    {
        m_lastRequestedDisplayType = HideDisplayMode.DisplayAll;
        EditAnchorTagMono[] editorTag = new EditAnchorTagMono[0];
        Eloi.E_SearchInSceneUtility.TryToFetchWithInScene(ref editorTag);
        foreach (var item in editorTag)
        {
            item.Display();
        }
    }

    public static void SwitchDisplayAll() {
        if (m_lastRequestedDisplayType == HideDisplayMode.HideAll)
            DisplayAll();
        else HideAll();
    }

    public static bool IsLastHiddenRequest()
    {
        return m_lastRequestedDisplayType == HideDisplayMode.HideAll;
    }
}