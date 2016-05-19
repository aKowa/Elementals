using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public struct Jump
{
	public float _Force;
	public int _MaxAmount;
	private int _amount;

	public void ResetAmount()
	{
		_amount = 0;
	}

	public float Force
	{
		get
		{
			if ( _amount < _MaxAmount )
			{
				IncreaseAmount();
				return _Force;
			}
			else
			{
				return 0;
			}
		}

		set { _Force = value; }
	}

	private void IncreaseAmount()
	{
		_amount++;
	}
}
