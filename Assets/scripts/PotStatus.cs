using UnityEngine;
using System.Collections;

public class PotStatus : MonoBehaviour {

	public GameObject Pot;

	private Transform pot;
	private Transform potLocation;
	// Use this for initialization
	void Start () {
	
		pot = GameObject.FindWithTag("Pot").GetComponent<Transform>();
		//GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
