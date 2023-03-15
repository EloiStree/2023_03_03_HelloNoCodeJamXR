using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class AbstractPlayersPrefsBroadcastMono : MonoBehaviour
    {
        public GameObject[] m_targetToBroadcastOn;



        private void Reset()
        {
            m_targetToBroadcastOn = new GameObject[] { this.gameObject };
        }
        public void BroadcastSaveOnChildren()
        {
            GetAllPlayerPrefIn(m_targetToBroadcastOn, out List<AbstractPlayerPrefs> result);
            foreach (var item in result)
            {
                item.Save();
            }

        }



        public void BroadcastLoadOnChildren()
        {
            GetAllPlayerPrefIn(m_targetToBroadcastOn, out List<AbstractPlayerPrefs> result);
            foreach (var item in result)
            {
                item.Load();
            }
        }
        public void BroadcastSaveLoadOnChildren()
        {
            GetAllPlayerPrefIn(m_targetToBroadcastOn, out List<AbstractPlayerPrefs> result);
            foreach (var item in result)
            {
                item.SaveAndReload();
            }
        }
        private void GetAllPlayerPrefIn(GameObject[] objects, out List<AbstractPlayerPrefs> result)
        {
            result = new List<Eloi.AbstractPlayerPrefs>();
            foreach (var p in objects)
            {
                result.AddRange(p.GetComponentsInChildren<AbstractPlayerPrefs>());
            }
        }

        public void BroadcastContextSaveOnChildren()
        {
            GetAllPlayerPrefIn(m_targetToBroadcastOn,out List < AbstractStringContextToPlayerPref > result);
            foreach (var item in result)
            {
                item.Save();
            }

        }

      

        public void BroadcastContextLoadOnChildren()
        {
            GetAllPlayerPrefIn(m_targetToBroadcastOn, out List<AbstractStringContextToPlayerPref> result);
            foreach (var item in result)
            {
                item.Load();
            }
        }
        public void BroadcastContextSaveLoadOnChildren(string newContext)
        {
            GetAllPlayerPrefIn(m_targetToBroadcastOn, out List<AbstractStringContextToPlayerPref> result);
            foreach (var item in result)
            {
                item.SaveAndLoadNewContext(newContext);
            }
        }
        private void GetAllPlayerPrefIn(GameObject[] objects, out List<AbstractStringContextToPlayerPref> result)
        {
            result = new List<Eloi.AbstractStringContextToPlayerPref>();
            foreach (var p in objects)
            {
                result.AddRange(p.GetComponentsInChildren<AbstractStringContextToPlayerPref>());
            }
        }
    }
}
