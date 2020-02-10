using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	Rigidbody2D rb2d;
	//ジャンプパワー
	[SerializeField] float jumpPower = 0;

	//前進スピード
	[SerializeField] float moveSpeed = 0;

	// Start is called before the first frame update
	void Start()
	{
		//自身のRigidbody取得
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Debug.Log( rb2d.velocity.magnitude );

		if( Input.GetKeyDown( "joystick button 0" ) )
		{
			Jump(); //ジャンプ
		}
	}

	void FixedUpdate()
	{
		float axisHor = Input.GetAxis( "Horizontal" );
		float axisVer = Input.GetAxis( "Vertical" );

		if( ( axisHor != 0 ) || ( axisVer != 0 ) )
		{
			MoveForward( axisHor, axisVer );
		}

		//this.gameObject.transform.position += this.gameObject.transform.right;
	}

	//前進処理
	void MoveForward( float axisHor, float axisVer )
	{
		this.gameObject.transform.position += axisHor * ( this.gameObject.transform.right * 0.1f );
	}

	//ジャンプ処理
	void Jump()
	{
		rb2d.AddForce( Vector2.up * jumpPower );
	}

}
