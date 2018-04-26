using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour 
{
	public float changeSpeed = 9f;
	MeshRenderer rend;

	void Start ()
	{
		rend = GetComponent<MeshRenderer>();
		rend.material = new Material (rend.sharedMaterial);
	}

	/// <summary>
	///  Reference this script and call this function via putting in a color will change the color of the material
	/// </summary>
	/// <param name="col">Col.</param>
	public void ColorChange (Color col)
	{
		StartCoroutine ("Changing");
		print ("No really it's in there");
	}

	IEnumerator Changing (Color col)
	{
		float lp = 0f;
		Color startCol = rend.material.color;

		while ( lp < 1f )
		{
			lp += changeSpeed * Time.deltaTime * 0.1f;
			rend.material.color = Color.Lerp (startCol, col, lp);

			yield return null;
		}
	}
}
