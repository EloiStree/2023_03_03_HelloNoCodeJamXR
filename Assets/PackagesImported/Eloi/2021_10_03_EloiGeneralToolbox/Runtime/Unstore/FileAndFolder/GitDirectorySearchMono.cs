using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eloi
{
    public class GitDirectorySearchMono : MonoBehaviour
    {
        public AbstractMetaAbsolutePathDirectoryMono m_targetDirectory;

        public string[] m_directories;
        public List<string> m_directoriesGit;
        public List<string> m_directoriesGitIgnore;
        public string m_debug;
        [ContextMenu("Search For Files")]
        public void SearchForFiles()
        {
            m_directoriesGit.Clear();
            m_directoriesGitIgnore.Clear();
            if (m_targetDirectory)
            E_FileAndFolderUtility.GetAllDirectoriesInAndInChildren(m_targetDirectory, out m_directories);
            else
                E_FileAndFolderUtility.GetAllDirectoriesInAndInChildren(
                 new MetaAbsolutePathDirectory(  Application.dataPath) , out m_directories);
            for (int i = 0; i < m_directories.Length; i++)
            {
                string name = new DirectoryInfo(m_directories[i]).Name;
                if (E_StringUtility.AreEquals(name, ".git", true, true))
                {
                    m_directoriesGit.Add(m_directories[i]);
                }
                if (E_StringUtility.AreEquals(name, ".giti", true, true))
                {
                    m_directoriesGitIgnore.Add(m_directories[i]);
                }
            }
        
        }

    }
}
