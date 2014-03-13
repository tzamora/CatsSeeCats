using UnityEngine;
using System.Collections;

public class GameData : MonoSingleton<GameData> {

	public PlayerScore Score;

	public bool ReachedCheckpoint = false;
	
	public Vector3 LastCheckpoint = Vector3.zero;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);

		Score = new PlayerScore();
	}

	public void ResetLevelData ()
	{
		Score.Reset();
	}
}
