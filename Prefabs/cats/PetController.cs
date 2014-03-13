using UnityEngine;
using System.Collections;

public class PetController : MonoBehaviour {

	public float speed = 1.1f;
	
	public ParticleSystem DieParticle;
	
	public GameObject BulletPrefab;
		
	public int Health = 100;

	public float rotateVelocity;
	
	public Transform pivot;

	private Transform wheel;

	public Transform target;
	public float RotationSpeed = 100f;
	public float OrbitDegrees = 100f;
	// Use this for initialization

	void Start () {
		//wheel = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
			//Shoot();
		transform.Rotate(new Vector3(0f,0.2f,0f), RotationSpeed * Time.deltaTime);
		transform.RotateAround(target.position, new Vector3(0f,0.2f,0f), OrbitDegrees*Time.deltaTime);
	
		//wheel.RotateAround(pivot.position, Vector3.up, rotateVelocity * Time.deltaTime);
//		float horizontalAxis = Input.GetAxis("Horizontal");
//		
//		float verticalAxis = Input.GetAxis("Vertical");
//	
//		transform.position += speed * Time.deltaTime * new Vector3(horizontalAxis, verticalAxis, 0f);


	}
	

	void OnTriggerEnter(Collider other)
	{
		EnemyController enemyController = other.GetComponent<EnemyController>();
		
		if(enemyController != null)
		{
			Damage(1);
		}
		
		AbissinianEnemyController abissianController = other.GetComponent<AbissinianEnemyController>();
		
		if(abissianController != null)
		{
			Damage(2);
		}
		
		BulletController bulletController = other.GetComponent<BulletController>();
		
		if(bulletController != null)
		{
			if(bulletController is EnemyBulletController)
			{
				Damage(1);
			}
		}
	}
	
	IEnumerator ShowHitFlash()
	{
		renderer.material.color = Color.red;
		
		yield return 4;
		
		renderer.material.color = Color.white;
	}
	
	void Damage(int tipo)
	{
		if(tipo==1)
			Health -= 10;
		else
			Health -= 50;
		
		StartCoroutine(ShowHitFlash());
		
		iTween.ShakePosition(Camera.main.gameObject,iTween.Hash("x",0.3f,"time",0.5f));
		
		if(Health <= 0)
		{
			Die();
		}
	}
	
	void Die()
	{
		Instantiate(DieParticle, transform.position, Quaternion.identity);
		
		Destroy(this.gameObject);
	}
	
	void Shoot()
	{
		GameObject bulletInstance = (GameObject)GameObject.Instantiate(BulletPrefab, transform.position, Quaternion.identity);
		
		bulletInstance.GetComponent<Rigidbody>().velocity = new Vector2(100f, 0);
	}
}
