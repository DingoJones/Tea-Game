using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacup : Teaset {

    [SerializeField] private Tea heldTea;
    [SerializeField] private bool hasWater = false;
    [SerializeField] private int waterTemp = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool AddTea(Tea tea, int temp) {
        if (heldTea == null) {
            heldTea = tea;
            hasWater = true;
            waterTemp = temp;
            return true;
        } else {
            return false;
        }
    } 
}
