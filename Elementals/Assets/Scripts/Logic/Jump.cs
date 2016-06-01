using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public struct Jump
{
	public float force;
	public int MaxAmount;
	private int amount;

	public void ResetAmount()
	{
		amount = 0;
	}

	public float Force
	{
		get
		{
			if ( amount < MaxAmount )
			{
				IncreaseAmount();
				return force;
			}
			else
			{
				return 0;
			}
		}

		set { force = value; }
	}

	private void IncreaseAmount()
	{
		amount++;
	}
}
