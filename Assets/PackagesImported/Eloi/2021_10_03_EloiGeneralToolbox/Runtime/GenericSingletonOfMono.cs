using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{

    public class GenericSingletonOfMono<T> where T:MonoBehaviour
    {
        private static T m_instanceInScene;

        public static T Instance
        {
            get
            {
                if (m_instanceInScene == null)
                    Eloi.E_SearchInSceneUtility.TryToFetchWithActiveInScene<T>(ref m_instanceInScene, true);

                if (m_instanceInScene == null)
                {
                    GameObject created = new GameObject("Singleton: "+ typeof(T).ToString());
                    T script = created.AddComponent<T>();
                    m_instanceInScene = script;
                }

                return m_instanceInScene;
            }
        }

    }
}
