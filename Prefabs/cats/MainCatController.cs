using UnityEngine;
using System.Collections;

public class MainCatController : MonoBehaviour
{

    public float speed = 1.1f;
    public ParticleSystem DieParticle;
    public GameObject BulletPrefab;
    public GameObject MissilePrefab;
    public Transform ShootPoint;
    public int Health = 100;
    public int Missiles = 3;
    public tk2dSprite sprite;
	public AudioClip DieSound;
	public AudioClip HitSound;
	public AudioClip ShootSound;
	public float horizontalAxis;
	public float verticalAxis;

	public float fireRate = 0.1f;

	float timer = 0;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        //float horizontalAxis = 0;

        //float verticalAxis = 0;

#if UNITY_IOS || UNITY_ANDROID
        horizontalAxis = GameContext.Get.Joystick.position.x;//Input.GetAxis("Horizontal");
        
        verticalAxis = GameContext.Get.Joystick.position.y;//Input.GetAxis("Vertical");

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            for(int i =0; i < Input.touches.Length;i++)

            if (Input.touches[i].position.x > Screen.width/2)
            {
                //
                // validate that we havent clicked an enemy
                // shot a raycast if we havent touch an enemy then simply shot
                //

                // [TODO]

                Shoot();
            }
        }
#else

		horizontalAxis = Input.GetAxis("Horizontal");
		
		verticalAxis = Input.GetAxis("Vertical");
		
		if(Input.GetKey(KeyCode.Space))
		//if(Input.GetButton("Fire1"))
		{
			timer += Time.deltaTime;
			
			if(timer > fireRate)
			{
				Shoot();
				
				timer = 0; // reset timer for fire rate
			}
			
		}
		
		//if(Input.GetKeyDown(KeyCode.M))
		if(Input.GetButton("Fire2"))
		{
			ShootMisille();
		}

#endif

        transform.position += speed * Time.deltaTime * new Vector3(horizontalAxis, verticalAxis, 0f);

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -11, 11), Mathf.Clamp(transform.localPosition.y, -8, 8), transform.localPosition.z);
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyController enemyController = other.GetComponent<EnemyController>();

        if (enemyController != null)
        {
            Damage(5);
        }

        AsteroidController asteroidController = other.GetComponent<AsteroidController>();

        if (asteroidController != null)
        {
            Die();
        }

		CatHandController catHand = other.GetComponent<CatHandController>();
		
		if (catHand != null)
		{
			Die();
		}

        BulletController bulletController = other.GetComponent<BulletController>();

        if (bulletController != null)
        {
            if (bulletController is EnemyBulletController)
            {
                Damage(10);
            }
        }

		MissileController missileController = other.GetComponent<MissileController>();
		
		if (missileController != null)
		{
			Damage(25);
		}

        AbissinianEnemyController abissinian = other.GetComponent<AbissinianEnemyController>();

        if (abissinian != null)
        {
            Damage(37);
        }

		BadCatBossController BadCatBoss = other.GetComponent<BadCatBossController>();
		
		if (BadCatBoss != null)
		{
			Damage(50);
		}
    }

    IEnumerator ShowHitFlash()
    {
        renderer.material.color = Color.red;

        this.sprite.renderer.material.shader = Shader.Find("Cartoon FX/Mobile Particles Additive Alpha8");
        
        yield return new WaitForSeconds(0.15f);

        this.sprite.renderer.material.shader = Shader.Find("tk2d/BlendVertexColor");

        //renderer.material.color = Color.white;
    }

    void Damage(int damage)
    {
        Health -= damage;

        StartCoroutine(ShowHitFlash());

		SoundManager.Get.PlayClip(HitSound, false);

        iTween.ShakePosition(this.gameObject, iTween.Hash("x", 0.1f, "time", 0.1f));

        if (Health <= 0)
        {
            Die();
        }
    }

    IEnumerator DieFalling()
    {
		Debug.Log("vamos a ver que es lo que pasa ahora con la vida");

		SoundManager.Get.PlayClip(DieSound, false);

//        rigidbody.isKinematic = false;
//
//        yield return new WaitForSeconds(1f);
//
//        Instantiate(DieParticle, transform.position, Quaternion.identity);
//
//        //Destroy(this.gameObject);
//
//        sprite.gameObject.SetActive(false);
//
        yield return new WaitForSeconds(0.5f);
//
//        Application.LoadLevel("StartMenu");

        //Application.LoadLevel("Level1");
    }

    void Die()
    {
		Debug.Log("vamos a ver que es lo que pasa ahora con la vida 2");

		SoundManager.Get.PlayClip(DieSound, false);

        Instantiate(DieParticle, transform.position, Quaternion.identity);

		GameContext.Get.LevelManager.LoadLevel("Level2", 1f);

        Destroy(this.gameObject);

        //sprite.gameObject.SetActive(false);

        //yield return new WaitForSeconds(1.5f);

        //Application.LoadLevel();

        //Application.LoadLevel("Level1");
    }

    public void Shoot()
    {
		//SoundManager.Get.PlayClip(ShootSound,false);

		GetComponent<AudioSource>().Play();

		GameObject bulletInstance = (GameObject)GameObject.Instantiate(BulletPrefab, ShootPoint.position, Quaternion.identity);

		bulletInstance.GetComponent<Rigidbody>().velocity = new Vector2(100f, 0);

		/*if(horizontalAxis < 0 )
		{
			bulletInstance.GetComponent<Rigidbody>().velocity = new Vector2(-100f, 0);
		}*/

        
    }

    public void ShootMisille()
    {
        if (Missiles > 0)
        {
            Missiles--;

            GameObject missileInstance = (GameObject)GameObject.Instantiate(MissilePrefab, ShootPoint.position, Quaternion.identity);
            
            missileInstance.GetComponent<Rigidbody>().velocity = new Vector2(20f, 0);
        }
    }
}
