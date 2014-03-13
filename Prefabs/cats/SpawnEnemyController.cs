using UnityEngine;
using System.Collections;

public class SpawnEnemyController : MonoBehaviour {


	public GameObject Enemy;

	public float Health = 100f;

	private float tick  = 0; 
	public float speed = 5; 
	public float paso  = 1;


	// Update is called once per frame
	void Update () 
	{
		tick+= Time.deltaTime; 
		//speed = Random.Range(0.0f, 5.0f); 
		float offsetX = Random.Range(-4.0f, 4.0f); 
		float offsetY = Random.Range(-3.0f, 3.0f); 
		if (tick>=paso){ 
			tick = 0;
			Vector3 position  = new Vector3(transform.position.x+offsetX,transform.position.y+offsetY, 0); 
			Instantiate(Enemy, position, Quaternion.identity);
		}
	}
	
}
