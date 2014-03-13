using UnityEngine;
using System.Collections;

public class LevelScrollerController : MonoBehaviour {

	public float speed = 0.07f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//
		// just move forward slowly
		//


		//transform.position = transform.position + new Vector3(0.3f, 0f, 0f);

		transform.position = transform.position + new Vector3(speed, 0f, 0f);
			 
	}
}
