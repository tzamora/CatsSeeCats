using UnityEngine;
using System.Collections;

public class SelkirkEnemyController : EnemyController {

	public float RotationSpeed = 100f;
	public Transform ShootPoint0;
	public Transform ShootPoint90;
	public Transform ShootPoint180;
	public Transform ShootPoint270;
	//Quaternion rotation = Quaternion.identity;

	//int angulo=0;
	void Start () 
	{
		StartCoroutine(PrepareShooting());
	}

	void Update()
	{
		transform.Rotate(new Vector3(0f,0f,0.2f), RotationSpeed * Time.deltaTime);
	}

	IEnumerator PrepareShooting()
	{
		while(true)
		{

			Shoot();

			yield return new WaitForSeconds(ShootDelay);
//			angulo += 90;
//			transform.rotation = Quaternion.Euler (0, 0, angulo);
		}
	}

	void Shoot()
	{
		//GameObject bulletInstance = (GameObject)GameObject.Instantiate(BulletPrefab, ShootPoint0.position, Quaternion.identity);

		//bulletInstance.GetComponent<Rigidbody>().velocity = new Vector2(100f, 0);

		//GameObject missileInstance = (GameObject)GameObject.Instantiate (MissilePrefab, ShootPoint.position, Quaternion.identity);
		
		//missileInstance.GetComponent<Rigidbody>().velocity = new Vector2 (20f, 0);

		GameObject bulletInstance0 = (GameObject)GameObject.Instantiate(BulletPrefab, ShootPoint0.position, Quaternion.Euler (0, 0, 0));		
		bulletInstance0.GetComponent<Rigidbody>().velocity = ShootPoint0.TransformDirection(new Vector2(100f, 0));
		GameObject bulletInstance90 = (GameObject)GameObject.Instantiate(BulletPrefab, ShootPoint90.position, Quaternion.Euler (0, 0, 90));		
		bulletInstance90.GetComponent<Rigidbody>().velocity = ShootPoint90.TransformDirection(new Vector2(100f, 0));
		GameObject bulletInstance180 = (GameObject)GameObject.Instantiate(BulletPrefab, ShootPoint180.position, Quaternion.Euler (0, 0, 180));		
		bulletInstance180.GetComponent<Rigidbody>().velocity = ShootPoint180.TransformDirection(new Vector2(100f, 0));
		GameObject bulletInstance270 = (GameObject)GameObject.Instantiate(BulletPrefab, ShootPoint270.position, Quaternion.Euler (0, 0, 270));		
		bulletInstance270.GetComponent<Rigidbody>().velocity = ShootPoint270.TransformDirection(new Vector2(100f, 0));
	}
}
