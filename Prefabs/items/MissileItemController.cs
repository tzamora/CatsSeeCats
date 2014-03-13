using UnityEngine;
using System.Collections;

public class MissileItemController : ItemController {

	public override void OnItemTake (MainCatController mainCat)
	{
		//
		// add 50 to health
		//
		
		mainCat.Missiles += 3;
		
		GameContext.Get.ShowLabelNotification("+3 Missile", mainCat.transform.position);
		
		base.OnItemTake (mainCat);
	}
}
