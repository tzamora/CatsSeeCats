using UnityEngine;
using System.Collections;

public class PlanetSpawnerController : MonoBehaviour {

	public GameObject PlanetPrefab;

	public float delay;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(StartPlanetSpawn());
	}

	IEnumerator StartPlanetSpawn()
	{
		while(true)
      	{
			yield return new WaitForSeconds(delay);

			GameObject planetGO = Instantiate(PlanetPrefab, transform.position, Quaternion.identity) as GameObject;

			Destroy(planetGO, 30f);
		}
	}
}
