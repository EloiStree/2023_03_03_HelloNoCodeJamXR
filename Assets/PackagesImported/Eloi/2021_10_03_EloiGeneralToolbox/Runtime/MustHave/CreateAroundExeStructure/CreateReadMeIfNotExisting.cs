using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateReadMeIfNotExisting : MonoBehaviour
{

    public ReadMeToCreate[] m_readsMe;

    [System.Serializable]
    public class ReadMeToCreate {
        public TextAsset m_readMe;
        public Eloi.MetaRelativePathFile m_subfolderFilePath;
    }

    void Start()
    {
        string dir = Directory.GetCurrentDirectory();
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        for (int i = 0; i < m_readsMe.Length; i++)
        {
            Eloi.E_FilePathUnityUtility.MeltPathTogether(out string path,  in dir , m_readsMe[i].m_subfolderFilePath.GetPath());
            string d = Path.GetDirectoryName(path);
            if (!Directory.Exists(d))
                Directory.CreateDirectory(d);
            if (!File.Exists(path)) {
                File.WriteAllText(path, m_readsMe[i].m_readMe.text);
            }
        }
    }

   
}
