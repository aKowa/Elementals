using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour
{
	private AttackBehavior[] attacks;

	private void Awake ()
	{
		attacks = GetComponentsInChildren<AttackBehavior> ();
	}

	private void Update ()
	{
		if (Input.GetButton("Fire1"))
		{
			attacks[0].Fire();
		}
	}
}
