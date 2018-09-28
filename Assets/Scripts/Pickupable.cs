using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable {

    protected RaycastHit pickupHit;
    protected bool inUse = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected RaycastHit CheckBelow(){
        Physics.Raycast(transform.position, Vector3.down * 100, out pickupHit);
        return pickupHit;
    }
}
