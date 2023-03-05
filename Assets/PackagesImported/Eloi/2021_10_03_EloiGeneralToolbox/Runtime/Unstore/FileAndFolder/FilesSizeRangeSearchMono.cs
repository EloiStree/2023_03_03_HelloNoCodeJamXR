using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Eloi
{
    public class FilesSizeRangeSearchMono : MonoBehaviour
    {
        public AbstractMetaAbsolutePathDirectoryMono m_targetDirectory;

        public long m_minimumFileSize= 20000000;
        public long m_maxFileSize = 20000000000;
        public string[] m_filesInDirectory;
        public List<MetaAbsolutePathFile> m_filesFound;
        public List<BySizeFileInfo> m_filesFoundWithInfo;
        public string[] m_removeIfContaint = new string[] { "/Library/", "/Build/" };
        public string m_debug;
        [ContextMenu("Search For Files")]
        public void SearchForFiles() {
            string[] files = new string[0];
            E_FileAndFolderUtility.GetAllfilesInAndInChildren(m_targetDirectory, out files);
           // E_FileAndFolderUtility.GetAllfilesInAndOnlyInFolder(m_targetDirectory, out files);
            E_FileAndFolderUtility.FilterWithSize(in files, out m_filesFound, in m_minimumFileSize, in m_maxFileSize);
            m_filesFoundWithInfo.Clear();
            foreach (var item in m_filesFound)
            {   string p = item.GetPath().ToLower().Replace("\\","/");
                bool allow = true;
                for (int i = 0; i < m_removeIfContaint.Length; i++)
                {
                    m_removeIfContaint[i] = m_removeIfContaint[i].ToLower().Trim().Replace("\\", "/"); ;
                    if (p.IndexOf(m_removeIfContaint[i]) > 0)
                    { 
                        allow = false;
                        break;
                    }

                }
                if(allow)
                m_filesFoundWithInfo.Add(new BySizeFileInfo(item.GetPath()));
            }
            m_filesFoundWithInfo = m_filesFoundWithInfo.OrderByDescending(k=>k.m_moSize).ToList();
            m_filesInDirectory = files;
        }


        [ContextMenu("Refresh Mo Estimation")]
        public void RefreshMoEstimation()
        {

            m_debug = "Min:" + (m_minimumFileSize / 1000000f) + " Mo    Max:" + (m_maxFileSize / 1000000f)+" Mo";
        }


        [System.Serializable]
        public class BySizeFileInfo
        {
            public string m_description;
            public string m_name;
            public float m_moSize;
            public string m_path;
            public string m_inprojectPath;

            public BySizeFileInfo(string path) {

                FileInfo fi = new FileInfo(path);
                m_path = path;
                m_name = fi.Name;
                m_moSize = fi.Length / 1000000f;
                string projectPath = Directory.GetCurrentDirectory();
                m_inprojectPath = m_path.Replace(projectPath, "");
                m_description = m_moSize + " | " + m_name + "\t\t\t | " + m_inprojectPath;

            }
        }
    }
}
