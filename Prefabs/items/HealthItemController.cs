using UnityEngine;
using System.Collections;

public class HealthItemController : ItemController
{
	public override void OnItemTake (MainCatController mainCat)
	{
		//
		// add 50 to health
		//

		mainCat.Health += 50;

		mainCat.Health = Mathf.Clamp(mainCat.Health, 0, 100);

		GameContext.Get.ShowLabelNotification("+50 hp", mainCat.transform.position);

		base.OnItemTake (mainCat);
	}
}
