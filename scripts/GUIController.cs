using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public tk2dTextMesh HealthLabel;

	public tk2dTextMesh PointsLabel;

    public tk2dTextMesh MissileLabel;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
        HealthLabel.text = "HP: " + Mathf.Clamp(GameContext.Get.MainPlayer.Health,0,100);

		PointsLabel.text = "Score: " + GameData.Get.Score.Points;

        MissileLabel.text = "M: " + GameContext.Get.MainPlayer.Missiles;
	}
}
