using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputMovement : MonoBehaviour
{
	public Move Move;
	public Jump Jump;
	private Rigidbody2D rigid;
	private bool faceRight = false;

	public void Awake ()
	{
		this.rigid = GetComponent<Rigidbody2D> ();
	}

	private void Update ()
	{
		var h = Input.GetAxis ( "Horizontal" );
		var jumpButtonPressed = Input.GetButtonDown ( "Jump" );

		if (Mathf.Abs ( h ) > 0)
		{
			ApplyMove ( h );
		}
		if (jumpButtonPressed)
		{
			ApplyJump ( Jump.Force );
		}
	}

	// make player move
	private void ApplyMove ( float h )
	{
		if (this.rigid.velocity.magnitude <= Move.MaxSpeed)
		{
			this.rigid.AddForce ( Vector2.right * h * Move.Speed );
		}

		if (h > 0 && !faceRight)
		{
			Flip();
		}
		else if (h < 0 && faceRight)
		{
			Flip();
		}
	}

	// make player jump
	private void ApplyJump ( float f )
	{
		this.rigid.AddForce ( Vector2.up * f );
	}

	// reset jump parameters when hitting the ground
	public void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.transform.tag == "Ground" )
		{
			Jump.ResetAmount();
		}
	}

	private void Flip()
	{
		faceRight = !faceRight;
		//var targetScale = transform.localScale;
		//targetScale.x *= -1;
		//transform.localScale = targetScale;
		var targetEuler = transform.rotation.eulerAngles;
		targetEuler.y = faceRight ? 180 : 0;
		transform.rotation = Quaternion.Euler(targetEuler);
	}
}
