using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TeaStateM2 : MonoBehaviour {

	//public float changeSpeed = 9f;
	//MeshRenderer rend;

	public Color hny = new Color(1F, 0.75F, 0F, 1F);
	public Color mlk = new Color(1F, 1F, 1F, 1F);

	private Transform pot;
	private Transform potLocation;
	private Transform cup;
	private Transform cupLocation;
	private Transform kettle;
	private Transform kettleLocation;
	private Transform teaBag;
	private Transform milk;
	private Transform honey;
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
	public GameObject Done;
	public GameObject milkTea;

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
		teaDone = false;

		pot = GameObject.FindWithTag("Pot").GetComponent<Transform>();
		potLocation = GameObject.FindWithTag ("PotHere").GetComponent<Transform> ();
		cup = GameObject.FindWithTag("Cup").GetComponent<Transform>();
		cupLocation = GameObject.FindWithTag ("CupHere").GetComponent<Transform> ();
		kettle = GameObject.FindWithTag("Kettle").GetComponent<Transform>();
		kettleLocation = GameObject.FindWithTag ("KettleHere").GetComponent<Transform> ();
		teaBag = GameObject.FindWithTag("TeaBag").GetComponent<Transform>();
		milk = GameObject.FindWithTag ("Milk").GetComponent<Transform> ();
		honey = GameObject.FindWithTag ("Honey").GetComponent<Transform> ();

		steam = GameObject.FindGameObjectWithTag ("Steam");
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

		Done.SetActive (false);
		milkTea.SetActive (false);
		//rend = Tea.GetComponent<MeshRenderer>();
		//rend.material = new Material (rend.sharedMaterial);

		//mlk = new Color(1F, 1F, 1F, 1F);
		//hny = new Color(1F, 0.75F, 0F, 1F);
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
		/*else {
			steam.SetActive (false);
		}*/


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

		if (teaDone == true) {
			Done.SetActive (true);
			if ((Vector3.Distance (cup.position, honey.position) < trigDis2)) {
				print ("Honey Near Tea");
				if (Input.GetMouseButtonDown (0)) {
					print ("Honey is in the tea");
					//Tea.GetComponent<ChangeColor> ().ColorChange();
					ChangeColor Col = Tea.GetComponent<ChangeColor>();
					Col.ColorChange(Color.yellow);
					//StartCoroutine ("Changing");

				}

			}

			if ((Vector3.Distance (cup.position, milk.position) < trigDis2)) {
				print ("Milk Near Tea");
				if (Input.GetMouseButtonDown (0)) {
					print ("Milk is in the tea");
					//ChangeColor Col = Tea.GetComponent<ChangeColor>();
					//Col.ColorChange(Color.white);
					milkTea.SetActive (true);

				}

			}
		}


	}
	/*
	public void ColorChange (Color col)
	{
		StartCoroutine ("Changing");
		print ("No really it's in there");
	}

	IEnumerator Changing (Color col)
	{
		float lp = 0f;
		Color startCol = rend.material.color;

		while ( lp < 1f )
		{
			lp += changeSpeed * Time.deltaTime * 0.1f;
			rend.material.color = Color.Lerp (startCol, col, lp);

			yield return null;
		}
	}*/

	IEnumerator Boiling(){
		yield return new WaitForSeconds(10);
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
		yield return new WaitForSeconds(10);
		teaBrewed = true;
		//print ("tea is brewed");
		acheive2.SetActive (true);
	}
}
