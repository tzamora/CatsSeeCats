using UnityEngine;
using System.Collections;

public class PersianEnemyController : EnemyController {

	// Use this for initialization
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
}
