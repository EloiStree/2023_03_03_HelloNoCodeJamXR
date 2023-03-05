using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eloi
{
    public class InEditorFolderPathMono : Eloi.AbstractMetaAbsolutePathDirectoryMono
    {

        public enum WhereInEditor { Root, Assets, Library, Package, ProjectSettings }
        public WhereInEditor m_target;


        public override void GetPath(out string path)
        {
            path = "";
            string rootPath =  Directory.GetCurrentDirectory();

            switch (m_target)
            {
                case WhereInEditor.Root:
                    path = rootPath;
                    break;
                case WhereInEditor.Assets:
                    path = rootPath + "/Assets";
                    break;
                case WhereInEditor.Library:
                    path = rootPath+"/Library";
                    break;
                case WhereInEditor.Package:
                    path = rootPath + "/Packages";
                    break;
                case WhereInEditor.ProjectSettings:
                    path = rootPath + "/ProjectSettings";
                    break;
                default:
                    break;
            }
        }

        public override string GetPath()
        {
            GetPath(out string s);
            return s;
        }
    }
}
