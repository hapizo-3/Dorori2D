using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player3D : Actor3D
{

	//スティック感度
	[SerializeField] float sensitivity;

	//プレイヤースピード
	[SerializeField] float playerSpeed;

	//子オブジェクト
	Transform childObj;

	//キーコード変数
	KeyCode latestDownkey;

	[SerializeField] GUISkin guiskin;

	// Start is called before the first frame update
	void Start()
    {
		//子オブジェクト取得
		childObj = GetComponent<Transform>().GetChild( 0 );
    }

    // Update is called once per frame
    void Update()
    {
		//キーコード取得
		GetDownKeycode();
    }

	private void FixedUpdate()
	{
		//カメラ回転
		CameraRotate();

		//プレイヤー移動
		PlayerMove();

		//近い敵との距離
		EnemyDistance();
	}

	//カメラ回転処理
	public void CameraRotate()
	{
		//スティックの倒れた量
		GetRightStickValue3D();

		gameObject.transform.Rotate( 0, axisHorR, 0 );

		//カメラが回転する範囲を設定
		float verRot = gameObject.transform.eulerAngles.x + axisVerR;
		if( gameObject.transform.eulerAngles.x <= 95.0f && verRot > 85.0f )
		{
			verRot = 85.0f - verRot;
			gameObject.transform.Rotate( verRot, 0, 0 );
		}
		else if( gameObject.transform.eulerAngles.x >= 260 && verRot < 275.0f )
		{
			verRot = 275.0f - verRot;
			gameObject.transform.Rotate( verRot, 0, 0 );
		}
		childObj.transform.Rotate( axisVerR, 0, 0 );
	}

	//前進処理
	public void PlayerMove()
	{
		//スティック情報取得
		GetLeftStickValue3D();

		Vector3 nextPosition = new Vector3();
		nextPosition += gameObject.transform.forward * axisVerL * ( 0.1f * playerSpeed );
		nextPosition += gameObject.transform.right * axisHorL * ( 0.1f * playerSpeed );
		gameObject.transform.position += nextPosition;
	}

	//カメラが動く量
	private void GetRightStickValue3D()
	{
		axisHorR = Input.GetAxis( "Horizontal2" ) * sensitivity;     //水平
		axisVerR = Input.GetAxis( "Vertical2" ) * sensitivity;       //垂直
	}

	private void GetLeftStickValue3D()
	{
		axisHorL = Input.GetAxis( "Horizontal" );     //水平
		axisVerL = Input.GetAxis( "Vertical" );       //垂直
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

	void EnemyDistance()
	{

	}

	//GUI表示
	private void OnGUI()
	{
		GUI.Box( new Rect( 0, 0, 150, 60 ), "", guiskin.GetStyle( "Box" ) );
		GUI.color = Color.black;
		GUI.Label( new Rect( 0, 0, 100, 50 ), "R" );
		GUI.Label( new Rect( 0, 20, 100, 50 ), axisVerL.ToString() );
		GUI.Label( new Rect( 0, 40, 100, 50 ), axisHorL.ToString() );

		GUI.Label( new Rect( 80, 0, 100, 50 ), "L" );
		GUI.Label( new Rect( 80, 20, 100, 50 ), axisVerR.ToString() );
		GUI.Label( new Rect( 80, 40, 100, 50 ), axisHorR.ToString() );

		GUI.Label( new Rect( 160, 0, 100, 50 ), "Key" );
		GUI.Label( new Rect( 160, 20, 100, 50 ), latestDownkey.ToString() );
	}
}
