using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoaderMono : MonoBehaviour
{

    public string m_defaultScene;
    public bool m_reloadEventIfCurrent=true;
    public LoadSceneMode m_loadingMode= LoadSceneMode.Single;
    public UnityEvent m_beforeLoading;
    public void LoadDefaultSceneInMono()
    {
        m_beforeLoading.Invoke();
        SceneManager.LoadScene(m_defaultScene);
    }
    public void LoadSceneWithIndex(int index)
    {
        LoadSceneWithIndex(index, m_reloadEventIfCurrent);
    }
    public void LoadSceneWithIndex(int index, bool reloadIfCurrent)
    {
        Eloi.E_CodeTag.DirtyCode.Info("I realized that GetCurrent scene is bugging when in don't destroy... To correct later");
        if (reloadIfCurrent) {

            m_beforeLoading.Invoke();
            SceneManager.LoadScene(index, m_loadingMode);
        }
        else if (!reloadIfCurrent && index != SceneManager.GetActiveScene().buildIndex)
        {

            m_beforeLoading.Invoke();
            SceneManager.LoadScene(index, m_loadingMode);
        }
    }

    public void LoadSceneWithName(string name)
    {
        LoadSceneWithName(name, m_reloadEventIfCurrent);
    }
    public void LoadSceneWithName(string name, bool reloadIfCurrent )
    {
        Eloi.E_CodeTag.DirtyCode.Info("I realized that GetCurrent scene is bugging when in don't destroy... To correct later");
        string currentScene = SceneManager.GetActiveScene().name;
        if (reloadIfCurrent)
        {

            m_beforeLoading.Invoke();
            SceneManager.LoadScene(name, m_loadingMode);
        }
        else if (!reloadIfCurrent && Eloi.E_StringUtility.AreNotEquals(in currentScene, in name, true, true))
            
        { 
            m_beforeLoading.Invoke();
            SceneManager.LoadScene(name, m_loadingMode);
        }
    }
    public void ReloadCurrentScene()
    {

        m_beforeLoading.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
