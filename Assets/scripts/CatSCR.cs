using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatSCR : MonoBehaviour {

	public Transform Cat;
	public GameObject State;

	public Transform step1;
	public Transform step2;
	public Transform step3;
	public Transform step4;

	// Use this for initialization
	void Start () {

		Cat = GameObject.FindGameObjectWithTag ("CatUI").GetComponent<Transform> ();

		step1.position = new Vector3(-378, 179, 0);
		step2.position = new Vector3(-378, 162, 0);
		step3.position = new Vector3(-378, 145, 0);
		step4.position = new Vector3(-378, 128, 0);
	}

	// Update is called once per frame
	void Update () {
		if (State.GetComponent<TeaStateM2> ().kettlePlace == true){
			//Cat.LookAt (step1); -378
			Cat.position = new Vector2(-378, 162);
		}
	}
}
