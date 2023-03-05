using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class E_DirectoryExplorationUtility : MonoBehaviour
{
    public static void GetParentsPathFromRootToPath(in string targetFolderPath, out string[] rootToPathFolders, bool includingGiven)
    {
        string[] tokens = targetFolderPath.Split(new char[] { '/', '\\' });
        if (tokens.Length == 0)
        {
            rootToPathFolders = new string[0];
            return;
        }
        StringBuilder sb = new StringBuilder();
        List<string> lTmp =  new List<string>();
        for (int i = 0; i < tokens.Length; i++)
        {
            sb.Clear();
            for (int j = 0; j < i; j++)
            {
                sb.Append(tokens[j]);
                if (j < i)
                    sb.Append("/");
            }

            if(sb.Length>0)
            lTmp.Add(sb.ToString());
        }
        if (includingGiven)
            lTmp.Add(targetFolderPath.Replace("\\","/"));

        rootToPathFolders = lTmp.ToArray();
    }


    public delegate void StopCondition(in string nextFolderPath, out bool continueToExplore);
    public delegate void ShouldItBeAdded(in string targetFolder, out bool addThePath);
    public static void ExploreFolderWithCondition(in string startPath , ref List<string> m_folderExploration, StopCondition stopCondition, ShouldItBeAdded shouldItBeAdded)
    {
        m_folderExploration.Clear();
        List<string> stillToExplore = new List<string>();
        List<string> nextToExplore = new List<string>();
        stillToExplore.AddRange( Directory.GetDirectories(startPath));
        while (stillToExplore.Count > 0)
        {
            nextToExplore.Clear();
            nextToExplore.AddRange(stillToExplore);
            stillToExplore.Clear();
            for (int i = 0; i < nextToExplore.Count; i++)
            {
                string p = nextToExplore[i];
                shouldItBeAdded(in p, out bool shouldadd);
                if (shouldadd)
                  m_folderExploration.Add(p);

                stopCondition(in p, out bool continueToExplore);
                if (continueToExplore)
                {
                    try
                    {
                        stillToExplore.AddRange(Directory.GetDirectories(nextToExplore[i]));
                    }
                    catch { }
                }
            }
        }

    }

    public static void GetParentsPathFromPathToRoot(in string targetFolderPath, out string[] pathToRootFolders, bool includingGiven)
    {
        GetParentsPathFromRootToPath(in targetFolderPath, out string[] rootToPathFolders, includingGiven);
        pathToRootFolders = rootToPathFolders.Reverse().ToArray();
    }
}
