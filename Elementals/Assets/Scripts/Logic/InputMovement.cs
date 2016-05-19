using System;
using UnityEngine;
using System.Collections;

public class InputMovement : MonoBehaviour
{
	public Move Move;
	public Jump Jump;
	private Rigidbody2D _rigid;

	public void Awake ()
	{
		// assign parameters
		_rigid = this.GetComponent<Rigidbody2D> ();
		if (_rigid == null)
			throw new NullReferenceException ( "Assign Rigidbody2D to: " + this.name );
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
		if (_rigid.velocity.magnitude <= Move.MaxSpeed)
			_rigid.AddForce ( Vector2.right * h * Move.Speed );
	}

	// make player jump
	private void ApplyJump ( float f )
	{
		_rigid.AddForce ( Vector2.up * f );
	}

	public void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.transform.tag == "Ground" )
		{
			Jump.ResetAmount();
		}
	}
}
