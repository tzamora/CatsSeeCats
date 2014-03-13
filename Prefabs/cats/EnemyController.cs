using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float ShootDelay = 0.5f;
	
	public float bulletSpeed = 0.5f;
	
	public GameObject BulletPrefab;

	public int ScorePoints = 1;
	
	public GameObject DieParticle;

	public AudioClip audioExplosion;

	public float Health = 100f;

	public tk2dSprite Sprite2D;
	
	void OnTriggerEnter(Collider other)
	{
		BulletController bulletController = other.GetComponent<BulletController>();
		
		if(bulletController != null)
		{
			if(bulletController is PlayerBulletController)
			{
				Damage(10);
			}
		}

		MissileController missileController = other.GetComponent<MissileController>();
		
		if(missileController != null)
		{
			Damage(50);
		}
	}
	
	protected virtual void Damage(int damage)
	{
        Health -= damage;
		
		StartCoroutine(ShowHitFlash());

		if(Health <= 0)
		{
			Die();
		}
	}
	
	/*IEnumerator ShowHitFlash()
	{
		renderer.material.color = Color.red;
		
		yield return 4;
		
		renderer.material.color = Color.white;
	}*/

	IEnumerator ShowHitFlash()
	{
		//renderer.material.color = Color.red;
		
		this.Sprite2D.renderer.material.shader = Shader.Find("Cartoon FX/Mobile Particles Additive Alpha8");
		
		yield return new WaitForSeconds(0.15f);
		
		this.Sprite2D.renderer.material.shader = Shader.Find("tk2d/BlendVertexColor");
		
		//renderer.material.color = Color.white;
	}
	
	public virtual void Die()
	{
		//
		// increase my score
		//

		GameData.Get.Score.Points += ScorePoints;

		//
		// show the points gained
		//

		GameContext.Get.ShowLabelNotification("+" + ScorePoints, transform.position);

		//
		// destroy enemy
		//

		Instantiate(DieParticle, transform.position, Quaternion.identity);

		if(audioExplosion!=null)
		{
			SoundManager.Get.PlayClip (audioExplosion, false);
		}
		
		Destroy(this.gameObject);
	}

}
