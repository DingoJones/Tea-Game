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

	public GameObject steam;
	public GameObject TeaBag;
	// Use this for initialization
	void Start () {
		trigDis = 1;
		trigDis2 = 4;

		potPlace = false;
		cupPlace = false;
		kettlePlace = false;
		KBoiled = false;
		bagHold = false;

		pot = GameObject.FindWithTag("Pot").GetComponent<Transform>();
		potLocation = GameObject.FindWithTag ("PotHere").GetComponent<Transform> ();
		cup = GameObject.FindWithTag("Cup").GetComponent<Transform>();
		cupLocation = GameObject.FindWithTag ("CupHere").GetComponent<Transform> ();
		kettle = GameObject.FindWithTag("Kettle").GetComponent<Transform>();
		kettleLocation = GameObject.FindWithTag ("KettleHere").GetComponent<Transform> ();
		teaBag = GameObject.FindWithTag("TeaBag").GetComponent<Transform>();

		steam = GameObject.FindWithTag ("Steam");
		steam.SetActive (false);

		TeaBag = GameObject.Find ("TeaBag");


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
			//DD.GetComponent<DragDrop1> ().teaPlace = true;
			if (Input.GetMouseButtonDown (0)) {
				StartCoroutine (TeaInPot ());
			}
			print ("tea in pot");
		}

			
	}

	IEnumerator Boiling(){
		yield return new WaitForSeconds(5);
		print ("kettle is boiling");
		KBoiled = true;
	}

	IEnumerator TeaInPot(){
		yield return new WaitForSeconds(1/4);
		TeaBag.SetActive (false);

	}
}
