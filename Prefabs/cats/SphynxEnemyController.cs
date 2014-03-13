using UnityEngine;
using System.Collections;

public class SphynxEnemyController : EnemyController
{
	public float speed = 4f;
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
		int side = 1;
		
		if(transform.localScale.x < 0)
		{
			side = -1;
		}
		else
		{
			side = 1;
		}

		GameObject bulletInstance = (GameObject)GameObject.Instantiate(BulletPrefab, transform.position, Quaternion.identity);
		
		bulletInstance.GetComponent<Rigidbody>().velocity = new Vector2(side*bulletSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(this.Sprite2D.renderer.IsVisibleFrom(Camera.main))
		{
			MainCatController mainCat = GameContext.Get.MainPlayer;

			if(mainCat==null)
			{
				return;
			}

			if(mainCat.transform.position.x > transform.position.x)
			{
				transform.localScale = new Vector3(-1,1,1);
			}
			else
			{
				transform.localScale = new Vector3(1,1,1);
			}

			//
			// Move towards the player
			//
			transform.position = Vector3.Lerp(transform.position, GameContext.Get.MainPlayer.transform.position, Time.deltaTime*speed);

		}
	}
}
