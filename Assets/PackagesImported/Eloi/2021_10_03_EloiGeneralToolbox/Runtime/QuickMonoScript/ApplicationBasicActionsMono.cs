using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

[ExecuteInEditMode]
public class ApplicationBasicActionsMono : MonoBehaviour
{
    public static bool m_restartPlayModeInEditor=false;
    public void OpenProjectRoot()
    {
        Application.OpenURL(GetPathOfCurrentFolder());
    }
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    public void OpenRootRelativeFolder(string relativePath)
    {
        Eloi.E_FilePathUnityUtility.MeltPathTogether(out string path, GetPathOfCurrentFolder(), relativePath);
        Application.OpenURL(path);
    }
    public string GetPathOfCurrentFolder() {
        return Application.dataPath + "/../";
    }

#if UNITY_EDITOR
    void Update() {
        if (m_restartPlayModeInEditor && Application.isEditor && !Application.isPlaying  && !UnityEditor.EditorApplication.isPlaying)
        {
            m_restartPlayModeInEditor = false;
            UnityEditor.EditorApplication.isPlaying = true;
        }
    }
#endif

    [ContextMenu("Restart Application")]
    public void RestartTheApplication() {


        //if (dirs.Length == 1)
        //{
        //    //string dir = Directory.GetCurrentDirectory();
        //    //string[] dirs = Directory.GetDirectories(dir, "*_Data");
        //    //pathToCall = dirs[0].Replace("_Data", ".exe") ;
        //    //RestartApplicationWindowThreadCall
        //}
       
        

#if  UNITY_EDITOR
        m_restartPlayModeInEditor = true;
        UnityEditor.EditorApplication.isPlaying = false;

#elif UNITY_STANDALONE_WIN
        string pathToCall = Application.dataPath.Replace("_Data", ".exe");
        Thread t = new Thread(() => RestartApplicationWindowThreadCall(pathToCall));
        t.Start();
        Application.Quit();
#elif UNITY_ANDROID

#endif

    }

    private void RestartApplicationWindowThreadCall( string pathToCall)
    {

        Eloi.IMetaAbsolutePathDirectoryGet dPath = new Eloi.MetaAbsolutePathDirectory(Path.GetDirectoryName(pathToCall));
        E_LaunchWindowBat.ExecuteCommandHiddenWithReturn( in dPath, "start \"\" \"" + pathToCall + "\"", out string o, out string e, out int ex);


    }



#if UNITY_WEBPLAYER
     public static string m_webplayerQuitURL = "http://google.com";
#endif
    public void QuitTheApplication() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(m_webplayerQuitURL);
#else
         Application.Quit();
#endif
    }

}
