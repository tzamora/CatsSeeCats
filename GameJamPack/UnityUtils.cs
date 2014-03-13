using UnityEngine;
using System.Collections;
using System;

public class UnityUtils 
{
	public static IEnumerator LerpAction(float duration, Action<float> IntervalHandler)
	{
		float i = 0f;
		
		float rate = 1f / duration;
		
		float durationSinceStart = 0f;
		
		while(i < 1)
		{
			durationSinceStart += Time.deltaTime;
			
			i += Time.deltaTime * rate;

			IntervalHandler(i);

			if(IntervalHandler != null)
			{
			}
			
			yield return null;
		}
	}

	public static IEnumerator Move(Transform target, Vector3 pointA, Vector3 pointB, float time)
    {
		return LerpAction(time, delegate (float t){

			target.localPosition = Vector3.Lerp(pointA, pointB, t);

		});
        /*float i = 0.0f;

        float rate = 1.0f / time;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;

            this.transform.localPosition = Vector3.Lerp(pointA, pointB, i);

            yield return null;
        }*/
    }
}
