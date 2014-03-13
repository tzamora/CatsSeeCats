using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	private Transform mainPlayer;

	private float Speed = 0.5f;

	// Use this for initialization
	void Start () 
	{
		mainPlayer = GameContext.Get.MainPlayer.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.position = Vector3.Lerp(transform.position, mainPlayer.position, Speed * Time.deltaTime);
	}
}
