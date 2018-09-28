using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour {
    
    public static Table instance = null;

    public float maxX, maxZ, minX, minZ;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        maxX = transform.position.x + transform.localScale.x / 2;
        minX = transform.position.x - transform.localScale.x / 2;
        maxZ = transform.position.z + transform.localScale.z / 2;
        minZ = transform.position.z - transform.localScale.z / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
