using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherMono : MonoBehaviour
{
    public static int m_currentScene=0;
    public static int m_previousScene=0;
    public static List<int> m_sceneSwitchHistory = new List<int>();
    public string[] m_sceneInList;
    [Header("Debug")]
    public string m_currentSceneName;
    public string m_sceneLoadHistory;


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        m_previousScene = m_currentScene;
        m_currentScene = scene.buildIndex;
        m_sceneSwitchHistory.Add(scene.buildIndex);
        m_sceneLoadHistory = string.Join(" > ", m_sceneSwitchHistory);
        m_currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void SwitchToSceneInList(int index)
    {
        if (index == -1)
            index = m_sceneInList.Length - 1;
        if (index == m_sceneInList.Length)
            index = 0;

        if (index >= 0 && index < m_sceneInList.Length) {
            try
            {
                SceneManager.LoadScene(m_sceneInList[index]);
            }
            catch {
                Debug.LogWarning("Scene requested but not loaded:" + index + " - " + m_sceneInList[index]);
            }
        }
    }
    public void SwitchToSceneRandomlyInList()
    {
        Eloi.E_UnityRandomUtility.GetRandomOf(out string result, m_sceneInList);
        SwitchToScene(result);
    }
    public void SwitchToSceneNextInList()
    {
        int index = 0;
        bool found = false;
        GetCurrentIndex(out index, out found);
        if (found)
            SwitchToSceneInList(index-1);
    }
    public void SwitchToScenePreviousInList()
    {
        int index = 0;
        bool found = false ;
        GetCurrentIndex(out  index, out  found);
        if (found)
            SwitchToSceneInList(index+1);
    }

    private void GetCurrentIndex(out int index, out bool found)
    {
         index = -5;
         found = false;
        for (int i = 0; i < m_sceneInList.Length; i++)
        {
            if (Eloi.E_StringUtility.AreEquals(in m_currentSceneName, in m_sceneInList[i], true, true))
            {
                found = true;
                index = i;
                break;
            }
        }
    }

    public void SwitchToScene(string name)
    {
        try
        {
            SceneManager.LoadScene(name);
        }
        catch
        {
            Debug.LogWarning("Scene requested but not loaded:" + name);
        }

    }


}
