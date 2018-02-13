﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop1 : MonoBehaviour
{
	
	//Initialize Variables
	GameObject getTarget;
	bool isMouseDragging;
	Vector3 offsetValue;
	Vector3 positionOfScreen;

	public GameObject State;
	public GameObject TeaBag;

	private Transform teaBag;

	private float trigDis;

	public bool held;
	public bool teaPlace;

	// Use this for initialization
	void Start()
	{
		trigDis = 1;

		State = GameObject.Find ("State");
		TeaBag = GameObject.FindGameObjectWithTag ("TeaBag");
		teaBag = GameObject.FindWithTag("TeaBag").GetComponent<Transform>();

		teaPlace = false;
		held = false;
		TeaBag.SetActive (false);
		//Debug.Log (TeaBag==null);
	}

	void Update()
	{

		//Mouse Button Press Down
		if (held == false) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hitInfo;
				getTarget = ReturnClickedObject (out hitInfo);
				if (getTarget != null) {
					isMouseDragging = true;
					//Converting world position to screen position.
					positionOfScreen = Camera.main.WorldToScreenPoint (getTarget.transform.position);
					offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
				/*
					if ((Vector3.Distance (teaBag.position, getTarget.transform.position) < trigDis)) {
						State.GetComponent<TeaStateM2> ().bagHold = true;
						print ("tea is in hand");
					}
*/
					if (teaPlace == true) {
						TeaBag.SetActive (false);
					}
				}
				StartCoroutine (Held ());

			}
		}

		if (held == true) {
			print ("I hold");
			if (Input.GetMouseButtonDown (0)) {
				isMouseDragging = false;
				print ("I no supposed hold");
				StartCoroutine (NoHeld());
			}
		}

		//Mouse Button Up
		/*
		if (Input.GetMouseButtonUp(0))
		{
			isMouseDragging = false;
			held = false;
		}
*/
		//Is mouse Moving
		if (isMouseDragging)
		{
			//tracking mouse position.
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

			//converting screen position to world position with offset changes.
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

			//It will update target gameobject's current postion.
			getTarget.transform.position = currentPosition;
		}


	}

	IEnumerator Held(){
		yield return new WaitForSeconds(1/4);
		held = true;
		print ("time done hold");
	}

	IEnumerator NoHeld(){
		yield return new WaitForSeconds(1/4);
		held = false;
		print ("time hold again");
	}

	//Method to Return Clicked Object
	GameObject ReturnClickedObject(out RaycastHit hit)
	{
		GameObject target = null;
		//GameObject.FindGameObjectWithTag ("Pot") target = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
		{
			target = hit.collider.gameObject;
		}
		return target;
	}

}