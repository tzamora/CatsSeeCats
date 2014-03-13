using UnityEngine;
using System.Collections;

public class FollowEnemyController : EnemyController
{
	public Transform ShootPoint;

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
		StartCoroutine(colision(bulletInstance));
	}

	IEnumerator colision(GameObject bulletInstance)
	{
		while(true)
		{
			if(bulletInstance!=null)
				if(GameContext.Get.MainPlayer!=null)
					bulletInstance.GetComponent<Rigidbody>().velocity = (GameContext.Get.MainPlayer.transform.position-transform.position);
					//transform.TransformDirection( Vector3.L	erp (transform.position, GameContext.Get.MainPlayer.transform.position, bulletSpeed * Time.deltaTime*200));

			yield return new WaitForSeconds(0.1f);
		}

	}
}
