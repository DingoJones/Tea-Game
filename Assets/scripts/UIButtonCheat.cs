using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButtonCheat : MonoBehaviour {
	public GameObject CupOne;
	public GameObject PotOne;
	public GameObject KettleOne;
	public GameObject CupTwo;
	public GameObject PotTwo;
	public GameObject KettleTwo;
	public Transform Steam;
	//public GameObject SteamTwo;

	public Transform SteamPlace;

	public Button One;
	public Button Two;
	public GameObject OK;
	// Use this for initialization
	void Start () {
		CupOne.SetActive (false);
		PotOne.SetActive (false);
		KettleOne.SetActive (false);
		CupTwo.SetActive (false);
		PotTwo.SetActive (false);
		KettleTwo.SetActive (false);
		OK.SetActive (false);

	}
	
	// Update is called once per frame
	public void OnMouseDown() {
		CupOne.SetActive (true);
		PotOne.SetActive (true);
		KettleOne.SetActive (true);
		CupTwo.SetActive (false);
		PotTwo.SetActive (false);
		KettleTwo.SetActive (false);
		Steam.position = SteamPlace.position;
		OK.SetActive (true);
		/*
			CupOne.SetActive (false);
			PotOne.SetActive (false);
			KettleOne.SetActive (false);
			CupTwo.SetActive (true);
			PotTwo.SetActive (true);
			KettleTwo.SetActive (true);
*/

	}
		

}
