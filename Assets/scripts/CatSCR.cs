using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatSCR : MonoBehaviour {

	//public Transform Cat;
	public GameObject State;

	public Transform step1;
	public Transform step2;
	public Transform step3;
	public Transform step4;

	public GameObject CatA;
	public GameObject CatB;
	public GameObject CatC;
	public GameObject CatD;

	public float go;

	// Use this for initialization
	void Start () {

		go = 1;
		/*
		//Cat = GameObject.FindGameObjectWithTag ("CatUI").GetComponent<Transform> ();
		CatA =GameObject.FindGameObjectWithTag ("CatUI");
		CatB =GameObject.FindGameObjectWithTag ("CatUI");
		CatC =GameObject.FindGameObjectWithTag ("CatUI");
		CatD =GameObject.FindGameObjectWithTag ("CatUI");
		*/
		step1.position = new Vector2(-378, 179);
		step2.position = new Vector2(-378, 162);
		step3.position = new Vector2(-378, 145);
		step4.position = new Vector2(-378, 128);

		//CatA.SetActive true;
		//CatB.SetActive false;
		//CatC.SetActive false;
		//CatD.SetActive false;
	}

	// Update is called once per frame
	void Update () {
		if (State.GetComponent<TeaStateM2> ().kettlePlace == true){
			//Cat.LookAt (step1); 
			//Cat.position = new Vector2( -378, 150);
			//Cat.position = step1;
			//CatA.SetActive = false;
			//CatB.SetActive = true;
		}
	}
}
