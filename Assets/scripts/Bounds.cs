using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {
	
	public Transform cup;
	public Transform pot;
	public Transform kettle;
	public Transform tea;
	public Transform honey;
	public Transform milk;

	public Transform Base;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider col){
		
		if (col.gameObject.tag == "Cup") {
			//Destroy (cup);
			//Instantiate (cup, new Vector3 (0, 10, 0), Base.rotation);
			cup.position = Base.position;
			print ("cup gone");

		}
		if (col.gameObject.tag == "Pot") {
			//Destroy (pot);
			//Instantiate (pot, new Vector3 (0, 10, 0), Base.rotation);
			pot.position = Base.position;
			print ("pot gone");

		}
		if (col.gameObject.tag == "Kettle") {
			//Destroy (kettle);
			//Instantiate (kettle, new Vector3 (0, 10, 0), Base.rotation);
			kettle.position = Base.position;
			print ("kettle gone");

		}
		if (col.gameObject.tag == "Tea") {
			//Destroy (tea);
			//Instantiate (tea, new Vector3 (0, 10, 0), Base.rotation);
			tea.position = Base.position;
			print ("tea gone");

		}
		if (col.gameObject.tag == "Honey") {
			//Destroy (honey);
			//Instantiate (honey, new Vector3 (0, 10, 0), Base.rotation);
			honey.position = Base.position;
			print ("honey gone");

		}
		if (col.gameObject.tag == "Milk") {
			//Destroy (milk);
			//Instantiate (milk, new Vector3 (0, 10, 0), Base.rotation);
			milk.position = Base.position;
			print ("milk gone");

		}
	}
}
