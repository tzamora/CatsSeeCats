using UnityEngine;
using System.Collections;

public class HoverEffect : MonoBehaviour {
	
	private Vector3 basePosition;
	
	public float duration = 1f;
	
	public float height = 1f;
	
	// Use this for initialization
	void Start () 
	{
		//
		// move up and down
		//
		
        basePosition = transform.localPosition;
		
		MoveUp();
	}
	
	void MoveUp()  
	{
        //
        // transform the local position to global position
        //

        Hashtable ht = 	iTween.Hash("y",basePosition.y + height, "time", duration, "onComplete", "MoveDown", "easetype", "easeInOutQuad", "islocal",true);
		
        iTween.MoveTo(gameObject,ht);
	}
	
	void MoveDown()
	{
        Hashtable ht = iTween.Hash("y",basePosition.y - height, "time", duration, "onComplete", "MoveUp", "easetype", "easeInOutQuad","islocal",true);
		
		iTween.MoveTo(gameObject,ht);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
