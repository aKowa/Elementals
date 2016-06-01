using System.Collections;
using UnityEngine;

[RequireComponent ( typeof ( ParticleSystem ) )]
public class AttackParticles : MonoBehaviour
{
	public float Duration = 1f;
	private ParticleSystem particles;

	private void Awake ()
	{
		this.particles = GetComponent<ParticleSystem> ();
	}

	private void OnEnable ()
	{
		this.particles.Play ();
		StartCoroutine(WaitToDisable());
	}

	private IEnumerator WaitToDisable ()
	{
		yield return new WaitForSeconds(Duration);
		
		this.particles.Stop();

		while (particles.particleCount > 0)
		{
			yield return null;
		}
		gameObject.SetActive (false);
	}
}
