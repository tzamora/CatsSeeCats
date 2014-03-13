using UnityEngine;
using System.Collections;

public class BossZoneController : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		MainCatController mainCat = other.GetComponent<MainCatController>();

		if(mainCat!=null)
		{
			//
			// first stop the scroller
			//
			
			LevelScrollerController scroller = Camera.main.GetComponent<LevelScrollerController>();
			
			scroller.speed = 0;

			//
			// first center the camera to the boss zone
			//

			Vector3 cameraPos = Camera.main.transform.position;

			Vector3 destPos = new Vector3(transform.position.x, cameraPos.y, cameraPos.z);

			StartCoroutine(UnityUtils.LerpAction(1f,delegate(float t){

				Camera.main.transform.position = 
					Vector3.Lerp(Camera.main.transform.position, destPos, t);

			}));

			Invoke("CompleteCentering",1.2f);
		}
	}

	void CompleteCentering()
	{
		//
		// now enable the boss
		//
		
		GameContext.Get.StartBossLevel1();
		
		//
		// and remove this sensor
		//
		
		Destroy(this.gameObject);
	}
}
