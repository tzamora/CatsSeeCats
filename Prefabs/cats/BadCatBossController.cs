using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BadCatBossController : EnemyController
{
	public Transform MachineGun;
	public GameObject MissilePrefab;
	public AudioClip BossMusic;
	public List<GameObject> Explosions;
	public AudioClip BossShout;
	public AudioClip BossDieSound;
    public bool FacingLeft = true;

	void Start ()
	{
		GameContext.Get.StartBossLevel1 += StartBossHandler;
	}
	
	void StartBossHandler ()
	{
		StartCoroutine (StartBoss ());
	}

	IEnumerator StartBoss ()
	{
		//
		// first make the boss appear
		//

		GameContext.Get.CrossFadeSounds (BossMusic);

		//SoundManager.Get.PlayClip (, true);

		yield return StartCoroutine (UnityUtils.LerpAction (5f, MakeBossAppear));

		//
		// then start shooting
		//

		Debug.Log ("start Shooting");

		StartCoroutine ("StartShootingMissiles");

		//Debug.Log ("Move down");

		while (true) 
		{
			StartCoroutine (UnityUtils.LerpAction (2f, MoveDown));

			//Debug.Log ("wait 2");

			yield return new WaitForSeconds (2f);

			//Debug.Log ("Move up");

            StartCoroutine (UnityUtils.LerpAction (2f, MoveUp));

			yield return new WaitForSeconds (2f);

            //
            // While we move up, toss a coin to see if we are going to move forwards and return
            //

            /*int hasToMove = Random.Range(0, 2);

            Debug.Log("has to move " + hasToMove);

            if(hasToMove == 0)
            {
                StartCoroutine (BossForwardAttack(5f));
            }*/

			//Debug.Log ("wait 2");

            //yield return new WaitForSeconds (2);

			//Debug.Log ("stop shooting");

            yield return StartCoroutine (BossForwardAttack());

		}
				
	}

	protected override void Damage (int damage)
	{
		base.Damage (damage);

		//
		// validate that only 22% of health is left in the boss
		//

		if (Health < 400) {
			this.Sprite2D.SetSprite ("gato_malo_damage");

			//SoundManager.Get.PlayClip(BossShout, false);
		}
	}

    IEnumerator BossForwardAttack()
    {
		MoveLeft(1f);

		yield return new WaitForSeconds(1f);

		MoveRight(1f);

		yield return new WaitForSeconds(1f);
    }

	void MoveLeft (float duration)
	{
		Vector3 from = transform.position;
		
		Vector3 to = new Vector3 (550, transform.position.y, transform.position.z);
		
		StartCoroutine (UnityUtils. Move(transform, from, to, duration));
	}

	void MoveRight (float duration)
	{
		Vector3 from = transform.position;
		
		Vector3 to = new Vector3 (568, transform.position.y, transform.position.z);
		
		StartCoroutine (UnityUtils. Move(transform, from, to, duration));
	}

	void Move(Vector3 from, Vector3 to, float t)
	{
		transform.position = Vector3.Lerp (from, to, t);
	}

//	void MoveRight (float t)
//	{
//		transform.position = Vector3.Lerp (new Vector3 (550, transform.position.y, transform.position.z), new Vector3 (568, transform.position.y, transform.position.z), t);
//	}

	void MoveDown (float t)
	{
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, -7f, transform.position.z), t);
	}

	void MoveUp (float t)
	{
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, 7f, transform.position.z), t);
	}

	void StopShooting ()
	{
		StopCoroutine ("StartShootingMissiles");

		StopCoroutine ("StartShootingBullets");
	}

	IEnumerator StartShootingMissiles ()
	{
		while (true) {
			yield return new WaitForSeconds (1.0f);

			ShootMissile ();
		}
	}

	IEnumerator StartShootingBullets ()
	{
		while (true) {
			yield return new WaitForSeconds (0.2f);
				
			ShootBullet ();
		}
	}

	void ChangeSide ()
	{
		transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y, transform.localScale.z);
	}

	void ShootMissile ()
	{
		GameObject missile = (GameObject)Instantiate (MissilePrefab, MachineGun.transform.position, Quaternion.identity);

		missile.transform.localScale = new Vector3 (-missile.transform.localScale.x, missile.transform.localScale.y, missile.transform.localScale.z);

		if (GameContext.Get.MainPlayer != null) {
			missile.GetComponent<Rigidbody> ().velocity = (GameContext.Get.MainPlayer.transform.position - MachineGun.position);
		}
	}

	void ShootBullet ()
	{

	}

	void MakeBossAppear (float t)
	{
		transform.position = Vector3.Lerp (transform.position, new Vector3 (568, transform.position.y, 0f), t);
	}

	public override void Die ()
	{
		StartCoroutine (DispatchExplosions ());

		//base.Die ();
	}

	public void DieForReal ()
	{
		//
		// increase my score
		//

		GameData.Get.Score.Points += ScorePoints;
		
		//
		// show the points gained
		//
		
		GameContext.Get.ShowLabelNotification ("+" + ScorePoints, transform.position);
		
		//
		// destroy enemy
		//
		
		Instantiate (DieParticle, transform.position, Quaternion.identity);
		
		if (audioExplosion != null) {
			SoundManager.Get.PlayClip (BossDieSound, false);
		}

		GameContext.Get.ShowLevelEndingView ();
		
		Destroy (this.gameObject);
	}

	IEnumerator DispatchExplosions ()
	{
		foreach (GameObject particle in Explosions) {
			particle.GetComponent<ParticleSystem> ().Play ();

			yield return new WaitForSeconds (0.6f);
		}

		SoundManager.Get.PlayClip (BossDieSound, false);

		yield return new WaitForSeconds (0.8f);

		DieForReal ();
	}
}
