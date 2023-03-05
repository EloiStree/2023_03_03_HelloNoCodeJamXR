using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThereMustBeOnlyOneMono : MonoBehaviour
{
    public static Dictionary<string, GameObject> m_kingsOfTheHill = new Dictionary<string, GameObject>();

    public string m_uniqueidToUse="DefaultKingOfTheHill";

    public UnityEvent m_doIfFirstOrAloneInTheScene;
    public UnityEvent m_doIfNotFirstAndSoNeedDeactivation;


    [Header("Destroyer if you prefer")]
    public bool m_justUseClassicDestroyThisGameObject;
    public AbstractDestroyManagerMono m_destroyerToUse;


    void Awake()
    {
        if (!m_kingsOfTheHill.ContainsKey(m_uniqueidToUse))
        {

            m_kingsOfTheHill.Add(m_uniqueidToUse, this.gameObject);
            m_doIfFirstOrAloneInTheScene.Invoke();
        }
        else if (m_kingsOfTheHill.ContainsKey(m_uniqueidToUse) && m_kingsOfTheHill[m_uniqueidToUse] == null)
        {

            m_kingsOfTheHill[m_uniqueidToUse] = this.gameObject;
            m_doIfFirstOrAloneInTheScene.Invoke();
        }
        else if (m_kingsOfTheHill.ContainsKey(m_uniqueidToUse) && m_kingsOfTheHill[m_uniqueidToUse] != null && m_kingsOfTheHill[m_uniqueidToUse]==this.gameObject)
        {

        }
        else {
            m_doIfNotFirstAndSoNeedDeactivation.Invoke();
            RequestDestroyCall();
        }
    }

    public void RequestDestroyCall()
    {
        if (m_destroyerToUse != null)
        {
            m_destroyerToUse.RequestDestruction();
        }
        if (m_justUseClassicDestroyThisGameObject) {
            Destroy(this.gameObject);
           
        }
        
    }

    private void Reset()
    {
        GenerateUniqueIdOnTheDate();
    }

    [ContextMenu("Generate Unique Id based on Date.now")]
    private void GenerateUniqueIdOnTheDate()
    {
        Eloi.E_GeneralUtility.GetTimeLongId(out ulong id);
        m_uniqueidToUse = "KingOfTheHill_" + id
;
    }
}
