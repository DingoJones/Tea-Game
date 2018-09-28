using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teapot : Teaset {

    [SerializeField] private Tea heldTea;
    [SerializeField] private bool hasWater = false;
    [SerializeField] private int waterTemp = 20;

    private RaycastHit hit;
    private Teacup hitTeacup;

	// Use this for initialization
	void Start () {
        heldTea = null;
	}
	
	// Update is called once per frame
	void Update () {
        hit = CheckBelow();
        hitTeacup = hit.collider.GetComponent<Teacup>();
        if (hitTeacup != null) {
            hitTeacup.AddTea(heldTea, waterTemp);
            Pour();
        }
		
	}

    public bool AddTea(Tea tea) {
        if (heldTea == null) {
            heldTea = tea;
            return true;
        } else {
            return false;
        }
    } 

    public bool AddWater(int temp) {
        if (!hasWater){
            hasWater = true;
            waterTemp = temp;
            return hasWater;
        }
        else {
            return false;
        }
    }

    public bool Pour() {
        if (hasWater && heldTea != null) {
            hasWater = false;
            heldTea = null;
            return true;
        }
        else {
            return false;
        }
    }
}
