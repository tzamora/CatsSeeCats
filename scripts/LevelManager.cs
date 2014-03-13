using UnityEngine;
using System.Collections;

public class LevelManager 
{
	private MonoBehaviour parentBehaviour;

	public LevelManager(MonoBehaviour behavior)
	{
		parentBehaviour = behavior;
	}

	public void LoadLevel(string levelName, float delay)
	{
		//
		// each time a level is loaded reset the score
		//

		GameData.Get.ResetLevelData();

		parentBehaviour.StartCoroutine(LoadLevelCoroutine(levelName, delay));
	}

	IEnumerator LoadLevelCoroutine(string levelName, float delay)
	{
		yield return new WaitForSeconds(delay);

		Application.LoadLevel(levelName);
	}


}
