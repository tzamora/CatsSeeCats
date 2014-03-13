using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour
{
	private EnemyController currentTarget;

	public GameObject ExplosiveParticle;

	// Use this for initialization
	void Start () 
	{
		//
		// get all the enemies on the screen
		//

		currentTarget = null;

		/*EnemyController[] enemies = GameObject.FindObjectsOfType<EnemyController>();

		for(int i = 0; i < enemies.Length; i++)
		{
			if(enemies[i].Sprite2D.renderer.IsVisibleFrom(Camera.main))
			{
				currentTarget = enemies[i];

				break;
			}
		}*/
	}

	void OnTriggerEnter()
	{
		Instantiate(ExplosiveParticle, transform.position + new Vector3(1f,0f,0f), Quaternion.identity);

		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(currentTarget!=null)
		{
			//float rotationSpeed = 2f;

			//Vector3 targetPos = new Vector3( currentTarget.transform.position.x, currentTarget.transform.position.y, transform.position.z );

			//Vector3 myPos = new Vector3( transform.position.x, transform.position.y, transform.position.z );

			//transform.rotation = 
			//	Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos - myPos), rotationSpeed * Time.deltaTime);

//			Vector3 targetPosition = currentTarget.transform.position;
//
//			Vector3 currentPosition = transform.position;
//
//			targetPosition.x = 0;
//
//			currentPosition.x = 0;
//
//			transform.rotation = Quaternion.LookRotation(targetPosition - currentPosition, Vector3.up);

			//Vector3 pos = currentTarget.gameObject.transform.position;

			//transform.LookAt(new Vector3(pos.x, pos.y, transform.position.z));
		}

	}
}
