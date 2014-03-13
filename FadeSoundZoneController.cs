using UnityEngine;
using System.Collections;

public class FadeSoundZoneController : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		MainCatController mainCat = other.GetComponent<MainCatController>();
		
		if(mainCat!=null)
		{
			GameContext.Get.FadeBackgroundSound();
		}
	}
}
