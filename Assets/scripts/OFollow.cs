using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*if rest state is  true walk randomly
 *if rest state is false move to GameObject player
 *rest state is false when player hits mouse2
 *rest state is true if wolf hits player
 */

public class OFollow : MonoBehaviour {
	//private float moveInterval;  //Seconds between each move.
	private float moveVelocity;  //How fast wolf chases.
	private float chaseProximity; 
	private float atkProximity; 
	private float rewardProximity;
	private float chaseTime;

	public GameObject Player;    //the player character
	public GameObject Wolf;        //the wolf
	public GameObject Beacon;    //the marker
	public GameObject Reward;    //the marker
	//private Transform rad;
	private Transform player;

	private NavMeshAgent wolf;

	private Transform beacon; 

	private Transform rwrd;


	//private Vector3 startPos;
	private Transform wolfTr;

	public int wolfCounter;

	public bool call;            //the comand to bring the wolf to the player
	public bool move;            //how the wolf moves to the player
	public bool idle;            //how the wolf behaves when not 
	public bool atk;
	public bool wrd;
	public bool kll;
	public bool retrn;


	bool chasingRabbit = false;

	public Animator animW;
	// Use this for initialization
	void Start () {

		//moveInterval = 50;
		moveVelocity = 7f;
		chaseProximity = 2;
		atkProximity = 6;
		rewardProximity = 5;
		chaseTime = 4;

		wolfCounter = 0;

		beacon = GameObject.FindWithTag("Marker").GetComponent<Transform>();
		wolf = GetComponent<NavMeshAgent>();
		wolfTr = GetComponent<Transform>();
		//startPos = wolfTr.position;
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();

		//Animator_Wolf Animator_Wolf = wolfBod.GetComponent<Animator_Wolf>();


		call = false;
		move = false;
		idle = true;
		atk = false;
		wrd = false;
		kll = false;
		retrn = false;


		animW = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {
		/*
        if (!move && !call)  {
            StartCoroutine(movementCycle());
        }
        */

		if (!idle && (Vector3.Distance (beacon.position, wolfTr.position) < chaseProximity)) {
			idle = true;
			move = false;
			call = false;
			wrd = false;
			retrn = false;
			print ("stop");
			animW.Play ("idleW");

		}

		if ((Vector3.Distance (player.position, wolfTr.position) < atkProximity)) {
			atk = true;
			idle = false;
			move = false;
			call = false;
			wrd = false;
			retrn = false;

		}
		/*
		if ((Vector3.Distance (wolfTr.position, rwrd.position) < rewardProximity)) {
			wrd = true;
			atk = false;
			idle = false;
			move = false;
			call = false;
			print ("before wolf looking at reward");

		}
*/
		if (Input.GetKeyDown ("space")) {
			print ("space was pressed");
			call = true;

		}

		if (call == true) {
			move = true;
			idle = false;
			print ("called");
		}



		if (move == true) {
			wolfTr.LookAt (beacon);
			wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
			//anim.SetTrigger("bite");
			print ("wolf anim run");
			animW.Play ("Take 001");

		}

		if (atk == true) {
			wolfTr.LookAt (player);
			wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
			print ("wolf anim run");
			animW.Play ("Take 001");
		}

		if (retrn && Vector3.Distance(wolfTr.position, beacon.position) <= 1) {
			Debug.Log("back to beacon");
			retrn = false;
			animW.Play ("idleW");
		}


		if (retrn == true) {
			idle = true;
			move = false;
			call = false;
			wrd = false;
			retrn = false;
			Debug.Log("return true");
			animW.Play ("Take 001");
		}
		/*
		if (wrd == true) {
			wolfTr.LookAt (rwrd);
			wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
		}

		
		if ((Vector3.Distance (wolfTr.position, rwrd.position) < rewardCollect)) {
			wolfCounter = (wolfCounter + 1);
			print (wolfCounter);
			print ("non-coll");
			//rwrd.gameObject.SetActive (false);
			kll = true;
		}

		if ((Vector3.Distance (wolfTr.position, rwrd.position) < rewardCollect)) {
			kll = false;
		}
*/
		if (wolfCounter > 5) {
			wolfTr.LookAt (player);
			wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
			print ("wolf anim run");
			animW.Play ("Take 001");
		}

	}

	IEnumerator setAttackLimit()    {
		//Stop chasing after a time limit.
		yield return new WaitForSeconds(chaseTime);
		call = false;
		move = false;
		idle = false;
		atk = false;
		print ("wolf is returning"); 
		//Send monster back to start point.
		retrn = true;
		wolfTr.LookAt (beacon);
		wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
	}

	public void TemptWolf (Transform rabbit)
	{
		if (!chasingRabbit)
			StartCoroutine ("Hunt", rabbit);
	}

	IEnumerator Hunt (Transform follow)
	{
		while (true) {
			transform.position = Vector3.MoveTowards (transform.position, follow.position, moveVelocity * Time.deltaTime);
			yield return null;


		}
	}

	void OnTriggerEnter(Collider obj)     {
		print (obj.gameObject.tag); 
		if (obj.gameObject.tag == "Player") {
			//Reset level
			if (wolfCounter < 5) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				print ("killed");
				wolfCounter = 0;
			}
			if (wolfCounter > 5) {
				Destroy (obj.gameObject);

			}

		}
		if (obj.gameObject.tag == "Reward") {
			wolfCounter = (wolfCounter + 1);
			print (wolfCounter);
			obj.gameObject.SetActive (false);
			print ("coll");
		}

		if (obj.gameObject.tag == "Radius") {
				wolfTr.LookAt (rwrd);
				wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
			print ("wolf anim run");
			animW.Play ("Take 001");
			print ("Saw radius");
			rwrd = GameObject.FindWithTag("Reward").GetComponent<Transform>();
		}

	}
}