using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!renderer.IsVisibleFrom(Camera.main))
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{

		AsteroidController asteroid = other.GetComponent<AsteroidController>();

		if(asteroid != null)
		{
			Destroy(this.gameObject);
		}
	}
}
