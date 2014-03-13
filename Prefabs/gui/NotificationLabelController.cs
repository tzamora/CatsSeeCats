using UnityEngine;
using System.Collections;

public class NotificationLabelController : MonoBehaviour {

	public tk2dTextMesh Label;

	public void ShowMessage(string message, Vector3 position)
	{
		transform.position = position;

		Label.text = message;

		StartCoroutine(UnityUtils.LerpAction(0.5f, MoveUp));
	}

	void MoveUp(float t)
	{
		transform.position = transform.position +  new Vector3(0f,Mathf.Lerp(0,1,t*Time.deltaTime*0.9f),0f);

		Label.color = Color.Lerp(Color.white, new Color(1f,1f,1f,0f), t);
	}
}