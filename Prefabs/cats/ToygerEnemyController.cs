using UnityEngine;
using System.Collections;

public class ToygerEnemyController : EnemyController {

	public float RotationSpeed = 100f;
	// Use this for initialization
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
		}
	}

	void Shoot()
	{
		GameObject bulletInstance = (GameObject)GameObject.Instantiate(BulletPrefab, transform.position, Quaternion.identity);
		
		bulletInstance.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector2(bulletSpeed, 0));
	}
}
