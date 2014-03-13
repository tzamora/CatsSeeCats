using UnityEngine;
using System.Collections;

public class SphynxEnemyControllerBak : EnemyController	
{
	void Start () 
	{
		StartCoroutine(PrepareShooting());
	}

	IEnumerator PrepareShooting()
	{
		while(true)
		{
			Shoot();

			yield return new WaitForSeconds(ShootDelay);
		}
	}

	void Shoot()
	{
		GameObject bulletInstance = (GameObject)GameObject.Instantiate(BulletPrefab, transform.position, Quaternion.identity);
		
		bulletInstance.GetComponent<Rigidbody>().velocity = new Vector2(bulletSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameContext.Get.MainPlayer!=null)
		{
			float distanceBetween = Vector3.Distance(GameContext.Get.MainPlayer.transform.position, transform.position);

			if(distanceBetween == 1f)
			{
				transform.position = Vector3.Lerp(transform.position, GameContext.Get.MainPlayer.transform.position, Time.deltaTime*2);
			}


		}
	}
}
