using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teabag : Pickupable {

    private RaycastHit hit;
    private Teapot hitTeapot;
    [SerializeField] private Tea tea;
    private bool used = false;

	// Use this for initialization
	void Start () {
        if (tea == null) {
            tea = (Tea)ScriptableObject.CreateInstance("Tea");
        }
	}
	
	// Update is called once per frame
	void Update () {
        hit = CheckBelow();
        hitTeapot = hit.collider.GetComponentInParent<Teapot>();
        if (hitTeapot != null) {
            if (hitTeapot.AddTea(tea)) {
                ClickController.instance.Drop();
                used = true;
            }
        }
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (used) {
            DestroyObject(this.gameObject);
        }
    }
}
