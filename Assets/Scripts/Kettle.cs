using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kettle : Teaset {

    [SerializeField] private int waterTemp = 20;
    [SerializeField] private bool hasWater = true;
    [SerializeField] private bool isBoiling;

    private Teapot hitTeapot;
    private Burner hitBurner;
    private RaycastHit hit;

	// Use this for initialization
	void Start () {
        hasWater = true;
        isBoiling = waterTemp >= 100;
	}
	
	// Update is called once per frame
	void Update () {
        hit = CheckBelow();
        hitTeapot = hit.collider.GetComponentInParent<Teapot>();
        if (hitTeapot != null && hasWater)
        {
            PourWater(hitTeapot);

        }
	}

    public void HeatWater(){
        if (hasWater) {
            waterTemp = 100;
            isBoiling = true;
        }
    }

    public void PourWater(Teapot teapot){
        teapot.AddWater(waterTemp);
        hasWater = false;
        waterTemp = 20;
    }

    public void OnCollisionEnter(Collision collision)
    {
        hitBurner = collision.collider.GetComponentInParent<Burner>();
        if (hitBurner != null) {
            HeatWater();
        }
    }
}
