using UnityEngine;
using System.Collections;

public class TeaStateM2 : MonoBehaviour {

	private Transform pot;
	private Transform potLocation;
	private Transform cup;
	private Transform cupLocation;
	private Transform kettle;
	private Transform kettleLocation;
	private Transform teaBag;
	//private Transform cupLocation;

	private float trigDis;
	private float trigDis2;

	public bool potPlace;
	public bool cupPlace;
	public bool kettlePlace;
	public bool KBoiled;
	public bool bagHold;
	public bool teaInPot;
	public bool teaBrewing;
	public bool teaBrewed;
	public bool teaDone;

	public GameObject steam;
	public GameObject TeaBag;
	public GameObject DD;
	public GameObject Tea;

	public GameObject acheive1;
	public GameObject acheive2;
	public GameObject acheive3;
	// Use this for initialization
	void Start () {
		trigDis = 1;
		trigDis2 = 4;

		potPlace = false;
		cupPlace = false;
		kettlePlace = false;
		KBoiled = false;
		bagHold = false;
		teaInPot = false;
		teaBrewing = false;
		teaBrewed = false;
		teaDone = true;

		pot = GameObject.FindWithTag("Pot").GetComponent<Transform>();
		potLocation = GameObject.FindWithTag ("PotHere").GetComponent<Transform> ();
		cup = GameObject.FindWithTag("Cup").GetComponent<Transform>();
		cupLocation = GameObject.FindWithTag ("CupHere").GetComponent<Transform> ();
		kettle = GameObject.FindWithTag("Kettle").GetComponent<Transform>();
		kettleLocation = GameObject.FindWithTag ("KettleHere").GetComponent<Transform> ();
		teaBag = GameObject.FindWithTag("TeaBag").GetComponent<Transform>();

		steam = GameObject.FindWithTag ("Steam");
		steam.SetActive (false);
		Tea = GameObject.FindWithTag ("tea");
		Tea.SetActive (false);

		TeaBag = GameObject.FindGameObjectWithTag ("TeaBag");
		DD = GameObject.FindGameObjectWithTag ("DD");

		acheive1 = GameObject.FindGameObjectWithTag ("acheive1");
		acheive2 = GameObject.FindGameObjectWithTag ("acheive2");
		acheive3 = GameObject.FindGameObjectWithTag ("acheive3");

		acheive1.SetActive (false);
		acheive2.SetActive (false);
		acheive3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if ((Vector3.Distance (pot.position, potLocation.position) < trigDis)) {
			print ("Pot is where it should be");
			potPlace = true;
		} else {
			potPlace = false;
		}

		if (potPlace == true) {

		}

		if (potPlace == false) {

		}

		if ((Vector3.Distance (cup.position, cupLocation.position) < trigDis)){
			print ("cup is where it should be");
			cupPlace = true; 
		} else {
			cupPlace = false;
		}

		if (cupPlace == true) {

		}

		if (cupPlace == false) {

		}

		if ((Vector3.Distance (kettle.position, kettleLocation.position) < trigDis)){
			print ("kettle is where it should be");
			kettlePlace = true; 
		} else {
			kettlePlace = false;
		}

		if (kettlePlace == true) {
			StartCoroutine (Boiling());

		}

		if (kettlePlace == false) {

		}

		if (KBoiled == true) {
			steam.SetActive (true);
		}


		if ((Vector3.Distance (teaBag.position, pot.position) < trigDis2)){
			if (Input.GetMouseButtonDown (0)) {
				StartCoroutine (TeaInPot ());

			}
			print ("tea in pot");
		}

		if (teaInPot == true && KBoiled == true) {
			if ((Vector3.Distance (kettle.position, pot.position) < trigDis2)){
				//DD.GetComponent<DragDrop1> ().teaPlace = true;
				print ("kettle in spot");
				if (Input.GetMouseButtonDown (0)) {
					StartCoroutine (Brewing ());
					print ("check teaBrewing");
				}
			}
			/*
			if ((Vector3.Distance (kettle.position, pot.position) < trigDis2)){
				DD.GetComponent<DragDrop1> ().teaPlace = false;
			}*/
		}

		if (teaBrewing == true) {
			StartCoroutine (Brewing ());
			//print ("check teaBrewing");
		}
			
		if (teaBrewed == true) {
			print ("tea is brewed");
			if ((Vector3.Distance (cup.position, pot.position) < trigDis2)) {
				print ("tea is ready to pour");
				if (Input.GetMouseButtonDown (0)) {
					teaDone = true;
					Tea.SetActive (true);
					acheive3.SetActive (true);
				}

			}
		}


	}

	IEnumerator Boiling(){
		yield return new WaitForSeconds(5);
		print ("kettle is boiling");
		KBoiled = true;
		acheive1.SetActive (true);
	}

	IEnumerator TeaInPot(){
		yield return new WaitForSeconds(1/4);
		TeaBag.SetActive (false);
		teaInPot = true;

	}

	IEnumerator Brewing(){
		yield return new WaitForSeconds(5);
		teaBrewed = true;
		//print ("tea is brewed");
		acheive2.SetActive (true);
	}
}
