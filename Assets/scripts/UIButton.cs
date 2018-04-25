using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour {
	public Transform teaCup;
	public Transform teaPot;
	public Transform teaKettle;

	public GameObject CupPrefab;
	public GameObject PotPrefab;
	public GameObject KettlePrefab;

	public Mesh cup;
	public Mesh pot;
	public Mesh kettle;

	//public bool cb;
	//public bool cl;

	public void Start() {
		teaCup = GameObject.FindWithTag("Cup").GetComponent<Transform>();
		teaPot = GameObject.FindWithTag("Pot").GetComponent<Transform>();
		teaKettle = GameObject.FindWithTag("Kettle").GetComponent<Transform>();

		//CupPrefab = GameObject.FindWithTag ("Cup");

	}

	public void LoadByIndex (int sceneIndex) {
		SceneManager.LoadScene (sceneIndex);
	}

	public void OnMouseDown() {
		//StartCoroutine (choice ());

		/*
		teaCup = GameObject.FindGameObjectWithTag ("Cup");

		teaCup.GetComponent<MeshFilter> ().mesh = cup;

		teaCup = GameObject.FindGameObjectWithTag ("Pot");

		teaCup.GetComponent<MeshFilter> ().mesh = pot;

		teaCup = GameObject.FindGameObjectWithTag ("Kettle");

		teaCup.GetComponent<MeshFilter> ().mesh = kettle;
*/
		//GameObject teaCup = (GameObject)Instantiate(CupPrefab, transform.position, transform.rotation);
		Instantiate(CupPrefab, new Vector3(-1,1,-3), teaCup.rotation);
		Instantiate(PotPrefab, new Vector3(3,1,-1), teaCup.rotation);
		Instantiate(KettlePrefab, new Vector3(-2,1,1), teaCup.rotation);
		//CupPrefab.timeoutDestructor = 5;


	}
		

}
	

