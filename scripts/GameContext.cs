using UnityEngine;
using System.Collections;
using System;

public class GameContext: MonoSingleton<GameContext> {

	public Action StartBossLevel1;

	public MainCatController MainPlayer;

	public ScreenJoystick Joystick;

	public LevelManager LevelManager;

	public NotificationLabelController label;

	public LevelEndViewController levelEndView;

	public AudioClip LevelBackgroundSound;

	public void Awake()
	{
		LevelManager = new LevelManager(this);

		if(GameData.Get.ReachedCheckpoint)
		{
			//
			// The starting points should be a checkpoint point
			//

			Vector3 checkpointPos = new Vector3(GameData.Get.LastCheckpoint.x,GameData.Get.LastCheckpoint.y,Camera.main.transform.position.z);

			Camera.main.transform.position = checkpointPos;
		}

		//
		// Start the background sound
		//

		SoundManager.Get.PlayClip(LevelBackgroundSound, true);
	}

	public void ShowLevelEndingView()
	{
		levelEndView.gameObject.SetActive(true);
	}

	public void FadeBackgroundSound()
	{
		StartCoroutine(UnityUtils.LerpAction(2f, delegate(float t) {
			
			SoundManager.Get.SetVolume(LevelBackgroundSound, Mathf.Lerp(1f,0f, t));
			
		}));
	}

	public void CrossFadeSounds(AudioClip clip)
	{
		SoundManager.Get.PlayClip(clip, true);

		StartCoroutine(UnityUtils.LerpAction(2f, delegate(float t) {
			
			SoundManager.Get.SetVolume(clip, Mathf.Lerp(0f,1f, t));
			
		}));
	}

	public void ShowLabelNotification(string message, Vector3 position)
	{
		label.gameObject.SetActive(true);
			
		label.ShowMessage(message, position);
	}

	//
	// keep saved the last position the player has advanced
	//
	public void SaveCheckPoint (Vector3 position)
	{
		GameData.Get.LastCheckpoint = position;

		GameData.Get.ReachedCheckpoint = true;
	}
}
