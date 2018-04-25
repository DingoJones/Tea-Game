using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour 
{
	public GameObject draggingObject;
	public Vector3 realObjPosition;
	public float moveSensitivity = 21f;
	public float scrollSensitivity = 1f;

	Vector3 lastPosition;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			Cursor.visible = false;
			CheckForObject ();
		}
		else if (Input.GetMouseButtonUp (0))
		{
			Cursor.visible = true;
			draggingObject.GetComponent<Rigidbody>().useGravity = true;
			draggingObject = null;
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
