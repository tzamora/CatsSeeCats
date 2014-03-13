using UnityEngine;
using System.Collections;

public class AbissinianEnemyController : EnemyController
{
		public float waitTime = 1.5f;

		// Use this for initialization
		void Start ()
		{
				StartCoroutine (WaitAndDie ());
		}

		IEnumerator WaitAndDie ()
		{
				yield return new WaitForSeconds (waitTime);

				//
				// spawn particles and destroy
				//

				Die ();
		}

		// Update is called once per frame
		void Update ()
		{
				
				//MyLookAt (GameContext.Get.MainPlayer.transform.position - transform.position);

				//Vector3 pos = GameContext.Get.MainPlayer.transform.position;

				//transform.LookAt(new Vector3(0,0, 1));

				//Vector3 relative = transform.InverseTransformPoint (GameContext.Get.MainPlayer.transform.position);

				//float angle = Mathf.Atan2 (relative.x, relative.z) * Mathf.Rad2Deg;

				//transform.Rotate (0, angle, 0);
				if (GameContext.Get.MainPlayer != null) {

						if (GameContext.Get.MainPlayer.transform.position.x > transform.position.x) {
								transform.localScale = new Vector3 (-1, 1, 1);
						} else {
								transform.localScale = new Vector3 (1, 1, 1);
						}

						transform.position = Vector3.Lerp (transform.position, GameContext.Get.MainPlayer.transform.position, Time.deltaTime * 2);
				}
		                                                                                                                                                                                        
		}

		void MyLookAt (Vector3 direction)
		{        
				float yRot = Mathf.Atan2 (direction.z, direction.x);
				float xRot = Mathf.Atan2 (direction.y, Mathf.Sqrt (direction.x * direction.x + direction.z * direction.z));
				transform.rotation = Quaternion.Euler (-xRot * Mathf.Rad2Deg, 90 - yRot * Mathf.Rad2Deg, 0);
		}
	
		void MyLookAt2 (Vector3 direction)
		{
				float yRot = Mathf.Atan2 (direction.z, direction.x);
				Vector3 V = direction;
				V.y = 0.0f;
				float xRot = Mathf.Atan2 (direction.y, V.magnitude);
				transform.rotation = Quaternion.Euler (-xRot * Mathf.Rad2Deg, 90 - yRot * Mathf.Rad2Deg, 0);
		}

		void OnTriggerEnter (Collider other)
		{
				BulletController bulletController = other.GetComponent<BulletController> ();
		
				if (bulletController != null) {
						if (bulletController is PlayerBulletController) {
								Damage (10);
						}
				}
		
				MissileController missileController = other.GetComponent<MissileController> ();
		
				if (missileController != null) {
						Damage (50);
				}

				MainCatController maincatController = other.GetComponent<MainCatController> ();
		
				if (maincatController != null) {
						Die ();
				}
		}
}
