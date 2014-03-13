using UnityEngine;
using System.Collections;

public class StopZoneController : MonoBehaviour {

	void OntriggerEnter(Collider other)
	{
		MainCatController mainCat = other.GetComponent<MainCatController>();

		if(mainCat != null)
		{
			LevelScrollerController levelScroller = Camera.main.gameObject.GetComponent<LevelScrollerController>();

			levelScroller.speed = 0f;

			Debug.Log("jhjh");
		}
	}
}
