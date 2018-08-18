using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetSelect : MonoBehaviour {

	//public static SetSelect instance = null; 
	public Button select;
	public GameObject Cup;
	public GameObject Pot;
	public GameObject Kettle;
	public int set;
	// Use this for initialization
	void Start () {
		set = 0;

		
	}
	
	// Update is called once per frame
	public void Press(){
		Cup.GetComponent<CupSelect> ().OnButtonPress();
		Pot.GetComponent<CupSelect> ().OnButtonPress();
		Kettle.GetComponent<CupSelect> ().OnButtonPress();
	}

}
