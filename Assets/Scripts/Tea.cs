using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tea : ScriptableObject {

    [SerializeField] private string teaName;

    public Tea()
    {
        if (teaName == null)
        {
            teaName = "Earl Grey";
        }
    }
}
