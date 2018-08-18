using UnityEngine;
using System.Collections;

public class CupSelect : MonoBehaviour {

	public GameObject Obj;
	public GameObject[] ObjFab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void OnButtonPress() {
		Instantiate (ObjFab [1],transform.position, transform.rotation);
	}
}
