using UnityEngine;
using System.Collections;

public class StartButtonController : MonoBehaviour {

	public tk2dUIItem buttonItem;

	public string SceneName = "";

	// Use this for initialization
	void Start () 
	{
		buttonItem.OnClick += OnButtonClickHandler;
	}

	void OnButtonClickHandler()
	{
		Debug.Log("vamos a ver porque es que esta vara esta pasando");

		Application.LoadLevel(SceneName);
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}
}
