using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{

	[SerializeField] bool debugMode = false;

	Rigidbody2D rb2d;	//MyRigidbody
	[SerializeField] float jumpPower = 0;   //ジャンプパワー
	[SerializeField] float moveSpeed = 0;   //前進スピード

	[SerializeField] GameObject ballObject;

	KeyCode latestDownkey;	//最後に押されたキー
	int axisHorInt = 0; //プレイヤーの向き

	
	float axisHor;  //水平スティックの情報を取得
	float axisVer;	//垂直スティックの情報を取得

	// Start is called before the first frame update
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		//ジャンプ処理
		if( Input.GetKeyDown( "joystick button 0" ) )
		{
			Jump();
		}

		//キーが押されたらキーコードを取得し、キー情報を保存する
		GetDownKeycode();
		//スティック操作量
		GetStickMoveValue();

		if( Input.GetKeyDown( "joystick button 5" ) )
		{
			ThrowBall();
		}
	}
	
	//画面にデバッグログ描画
	private void OnGUI()
	{
		if( debugMode == true )
		{
			GUI.Label( new Rect( 0, 0, 100, 50 ), latestDownkey.ToString() );
			GUI.Label( new Rect( 0, 20, 100, 50 ), Input.GetAxis( "Horizontal" ).ToString() );
			GUI.Label( new Rect( 0, 40, 100, 50 ), Input.GetAxis( "Vertical" ).ToString() );
			GUI.Label( new Rect( 0, 60, 100, 50 ), axisHorInt.ToString() );
		}
	}

	void FixedUpdate()
	{
		//方向判定
		if( axisHor >= 0.0000001f )
			axisHorInt = 1;
		else if( axisHor <= -0.0000001f )
			axisHorInt = -1;

		//前進処理
		if( ( axisHor != 0 ) || ( axisVer != 0 ) )
		{
			MoveForward( axisHor, axisVer );
		}
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

	//押されたキーの取得
	void GetDownKeycode()
	{
		//いずれかのキーが押されたらキーコードを取得し、最新のキー情報を取得する
		if( Input.anyKeyDown )
		{
			foreach( KeyCode code in Enum.GetValues( typeof( KeyCode ) ) )
			{
				if( Input.GetKeyDown( code ) )
				{
					latestDownkey = code;
					break;
				}
			}
		}
	}

	//スティックの倒れた量
	void GetStickMoveValue()
	{
		axisHor = Input.GetAxis( "Horizontal" );	//水平
		axisVer = Input.GetAxis( "Vertical" );		//垂直
	}

	//ボール投げる
	void ThrowBall()
	{
		GameObject ballObj = Instantiate( ballObject, 
			new Vector3( gameObject.transform.position.x, 
						 gameObject.transform.position.y, 
						 gameObject.transform.position.z - 0.3f ), 
						 Quaternion.identity ) 
			as GameObject;

		BallAttatchAddforce( ballObj );
	}

	void BallAttatchAddforce( GameObject ballObj )
	{
		Rigidbody2D ballObjRb = ballObj.GetComponent<Rigidbody2D>();
		ballObjRb.AddForce( new Vector2( 5, 5 ) );
	}
}
