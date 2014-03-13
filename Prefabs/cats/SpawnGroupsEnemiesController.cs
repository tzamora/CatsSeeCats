using UnityEngine;
using System.Collections;

public class SpawnGroupsEnemiesController : MonoBehaviour
{


    public GameObject[] Enemies = new GameObject[3];
    public int totalEnemies = 3;
    int currentEnemy = 0;
    float secondsPassed = 0f;
    float offsetZ;
    float offsetY;
    Vector3 position; 
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(spawncats());
    }

	public void EnableSpawn()
	{
		StartCoroutine(spawncats());
	}

    IEnumerator spawncats()
    {
        while (true)
        {
        
            for (var i=0; i < totalEnemies; i++)
            {
                offsetZ = Random.Range(-4.0f, 4.0f); 
                offsetY = Random.Range(-3.0f, 3.0f); 
                position = new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z + offsetZ); 
                Instantiate(Enemies [i], position, Quaternion.identity);
            }
            yield return new WaitForSeconds(20);
        }

    }
    
}
