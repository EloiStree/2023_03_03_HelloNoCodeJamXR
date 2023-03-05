using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DirectOrRelativeDirectoryPathMono : Eloi.AbstractMetaAbsolutePathDirectoryMono
    {
        public Eloi.AbstractMetaAbsolutePathDirectoryMono m_directoryPath;
        public Eloi.AbstractMetaAbsolutePathDirectoryMono m_relativeToProjectPath;

        public override void GetPath(out string path)
        {
            if (m_directoryPath != null)
            {
                m_directoryPath.GetPath(out string directPath);
                if (directPath.Trim().Length > 0)
                {
                    path = directPath;
                    return;
                }
            }
            path = m_relativeToProjectPath.GetPath();
        }

        public override string GetPath()
        {
            GetPath(out string p);
            return p;
        }
    }
}
