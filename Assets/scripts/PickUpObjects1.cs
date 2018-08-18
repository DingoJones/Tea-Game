using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects1 : MonoBehaviour 
{
	public GameObject draggingObject;
	public Vector3 realObjPosition;
	public Vector3 objLimits = new Vector3 (8f, 0f, 8f);
	public float moveSensitivity = 21f;
	public float scrollSensitivity = 1f;

	Vector3 lastPosition;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && draggingObject == null)
		{
			CheckForObject ();
			//Cursor.visible = false;
		}
		else if (Input.GetMouseButtonDown (0) && draggingObject != null)
		{
			draggingObject.GetComponent<Rigidbody>().useGravity = true;
			draggingObject = null;
			//Cursor.visible = true;
		}

		if (draggingObject != null)
		{
			DraggingObject ();
		}
	}

	void DraggingObject ()
	{
		Vector3 mousePos = Camera.main.ScreenToViewportPoint (Input.mousePosition);
		Vector3 movement = new Vector3 (mousePos.x - lastPosition.x, mousePos.y - lastPosition.y, 0f) * moveSensitivity;
		movement.z = Input.mouseScrollDelta.y * scrollSensitivity;
		draggingObject.transform.position += movement;

		if (Mathf.Abs (draggingObject.transform.position.x) > Mathf.Abs (objLimits.x)) 
			draggingObject.transform.position = new Vector3 (objLimits.x * Mathf.Sign (draggingObject.transform.position.x), draggingObject.transform.position.y, draggingObject.transform.position.z);
		if (Mathf.Abs (draggingObject.transform.position.z) > Mathf.Abs (objLimits.z)) 
			draggingObject.transform.position = new Vector3 (draggingObject.transform.position.x, draggingObject.transform.position.y, objLimits.z * Mathf.Sign (draggingObject.transform.position.z));

		lastPosition = mousePos;
	}

	void CheckForObject ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray.origin, ray.direction * 100f, out hit))
		{
			draggingObject = hit.collider.gameObject;
			draggingObject.GetComponent<Rigidbody>().useGravity = false;
			realObjPosition = draggingObject.transform.position;
			lastPosition = Camera.main.ScreenToViewportPoint (Input.mousePosition);
		}
	}
}
