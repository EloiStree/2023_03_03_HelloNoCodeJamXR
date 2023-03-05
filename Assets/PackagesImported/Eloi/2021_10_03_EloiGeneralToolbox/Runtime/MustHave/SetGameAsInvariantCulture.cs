using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;

public class SetGameAsInvariantCulture : MonoBehaviour
{

    static SetGameAsInvariantCulture() {
        Eloi.E_GeneralUtility.SetApplicationAsCultureInvariant();
    }

    void Awake()
    {
        Eloi.E_GeneralUtility.SetApplicationAsCultureInvariant();
    }
    private void OnValidate()
    {
        Eloi.E_GeneralUtility.SetApplicationAsCultureInvariant();

    }

   
}
