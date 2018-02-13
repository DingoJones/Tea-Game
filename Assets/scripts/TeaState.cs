using UnityEngine;
using System.Collections;

public class TeaState : MonoBehaviour {

	GameObject State;
	bool isMouseDragging;
	Vector3 offsetValue;
	Vector3 positionOfScreen;
	// Use this for initialization
	void Start () {
	
		State = GameObject.FindGameObjectWithTag ("State");//.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
		//RaycastHit hitInfo;
		//State = ReturnClickedObject (out hitInfo);
		//if (State != null) {
			//isMouseDragging = true;
			//Converting world position to screen position.
			positionOfScreen = Camera.main.WorldToScreenPoint (State.transform.position);
			offsetValue = State.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
		//}

			//tracking mouse position.
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

			//converting screen position to world position with offset changes.
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

			//It will update target gameobject's current postion.
			State.transform.position = currentPosition;

	}


	/*
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
*/
}
