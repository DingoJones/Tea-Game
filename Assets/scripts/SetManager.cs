using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class SetManager : MonoBehaviour {

	public GameObject cup;
	public GameObject pot;
	public GameObject kettle;

	public GameObject[] cupFab;
	public GameObject[] potFab;
	public GameObject[] kettleFab;

	public void OnButtonPress() {
		//new GameObject = cupFab[1];
		//cup = Instantiate(Resources.Load

		Instantiate (cupFab [1]);
		//cupFab.transform.SetParent (cup, false);
	}

}
