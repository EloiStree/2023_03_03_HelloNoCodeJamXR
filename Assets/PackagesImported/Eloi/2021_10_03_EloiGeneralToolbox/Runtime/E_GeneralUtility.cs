using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace Eloi
{
    public class E_GeneralUtility
    {

        public static void GetEnumEnumerable<T>(out IEnumerable<T> list) where T : Enum
        {
            list = Enum.GetValues(typeof(T)).Cast<T>();
        }
        public static void GetEnumList<T>(out List<T> listResult) where T : Enum
        {
            GetEnumEnumerable<T>(out IEnumerable<T> values);
            listResult = values.ToList();
        }

        public static void OpenProjectRoot()
        {
            Eloi.E_CodeTag.ToCodeLater.Info("Platform dependant");
            //if window and editor
            Application.OpenURL(GetProjectRoot());
        }
        public static string GetProjectRoot()
        {
            Eloi.E_CodeTag.ToCodeLater.Info("Platform dependant");
            //if window and editor
            return Application.dataPath + "/..";
        }

        public static void SetAllDisable(ref GameObject[] toActivateOnHide)
        {
            SetAllActive(ref toActivateOnHide, false);
        }

        public static void SetAllActive(ref GameObject[] toActivateOnDisplay)
        {
            for (int i = 0; i < toActivateOnDisplay.Length; i++)
            {
                if (toActivateOnDisplay[i] != null)
                    toActivateOnDisplay[i].SetActive(true);
            }
        }

        public static void SetAllActive(ref GameObject[] toActivateOnDisplay, in bool isActive)
        {
            if (toActivateOnDisplay != null) { 
                for (int i = 0; i < toActivateOnDisplay.Length; i++)
                {
                    if (toActivateOnDisplay[i] != null)
                        toActivateOnDisplay[i].SetActive(isActive);
                }
            }
        }

        public static void RemoveDouble(ref List<string> list)
        {
            list= list.Distinct().ToList();
        }

        public static void GetTimeULongIdWithNow(out ulong id)
        {
            GetTimeULongId(DateTime.Now, out id);
        }


        public static void GetTimeULongId(in DateTime time, out ulong id)
        {
            string createdDate = time.ToString("yyyy MM dd HH mm ss ffff");
            id = ulong.Parse(createdDate.Replace(" ", ""));
        }

        public static void SetApplicationAsCultureInvariant()
        {
           
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            
        }

        public static void GetTimeLongId(out ulong id)
        {
            DateTime n = DateTime.Now;
            GetTimeULongId(in n, out id);
        }

        public static void ListAsQueueInsert<T>(in T value, in int maxCount, ref List<T> list)
        {
            if (list == null)
                return;
            list.Insert(0, value);
            for (int i = 0; i < list.Count-maxCount; i++)
            {
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}