using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour 
{
	public ParticleSystem itemTakeParticle;

	public AudioClip ItemSound;

	// Use this for initialization
	void Start ()
	{

	}

	public virtual void OnItemTake(MainCatController mainCat)
	{
		SoundManager.Get.PlayClip(ItemSound, false);

		Instantiate(itemTakeParticle, transform.position, Quaternion.identity);

		Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		MainCatController mainCat = other.GetComponent<MainCatController>();

		if(mainCat != null)
		{
			OnItemTake(mainCat);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, 1f);
	}
}
