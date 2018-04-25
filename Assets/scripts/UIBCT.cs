using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIBCT : MonoBehaviour {
	public GameObject back;
	public GameObject One;
	public GameObject Two;
	public GameObject Three;

	// Use this for initialization
	void Start () {
	
		back.SetActive (true);
		One.SetActive (true);
		Two.SetActive (true);
		Three.SetActive (true);
	}
	
	// Update is called once per frame
	public void OnMouseDown() {
		back.SetActive (false);
		One.SetActive (false);
		Two.SetActive (false);
		Three.SetActive (false);
	}

	public void OnTriggerClick(){

	}
}
