using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(RotatePlanet());
	}

	IEnumerator RotatePlanet()
	{
		while(true)
		{
			this.gameObject.transform.Rotate(Vector3.up, 0.2f);

			yield return null;
		}
	}
}
