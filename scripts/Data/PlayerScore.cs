using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerScore
{
	public int Points = 0;

	public int Missiles = 2;

	public int Lives = 2;

	public void Reset ()
	{
		Points = 0;
		
		Missiles = 2;
		
		Lives = 2;
	}
}
