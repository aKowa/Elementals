using System.Collections;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
	public Transform Animation;
	private Transform[] origins;

	public void Awake ()
	{
		var children = GetComponentsInChildren<Transform>();
		this.origins = new Transform[children.Length - 1];

		for (int i = 1; i <= this.origins.Length; i++)
		{
			this.origins[i-1] = children[i];
		}

		Animation.SetParent(origins[0], false);
		Animation.gameObject.SetActive(false);
	}

	public void Fire()
	{
		Animation.gameObject.SetActive(true);
	}
}
