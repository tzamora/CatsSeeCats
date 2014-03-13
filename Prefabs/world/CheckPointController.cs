using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		//
		// if the player pass trough this place then save a checkpoint
		//

		MainCatController mainCat = other.GetComponent<MainCatController>();
		
		if(mainCat!=null)
		{
			Debug.Log("el gato entro en la jugada");

			GameContext.Get.SaveCheckPoint(transform.position);
		}
	}
}
