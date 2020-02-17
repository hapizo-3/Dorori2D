using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove3D : MonoBehaviour
{

	[SerializeField] float sensitivity;

	//親オブジェクト
	Transform parentObj;

	float axisVer;
	float axisHor;

    // Start is called before the first frame update
    void Start()
    {
		parentObj = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
		CameraRotate();
	}
	
	//カメラ回転処理
	void CameraRotate()
	{
		//スティックの倒れた量
		GetStickValue3D();

		//カメラを動かす
		//横のカメラの動きを制御
		parentObj.transform.Rotate( 0, axisHor, 0 );

		float verRot = gameObject.transform.eulerAngles.x + axisVer;
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
		gameObject.transform.Rotate( axisVer, 0, 0 );
	}

	//カメラが動く量
	void GetStickValue3D()
	{
		axisHor = Input.GetAxis( "Horizontal2" ) * sensitivity;		//水平
		axisVer = Input.GetAxis( "Vertical2" ) * sensitivity;				//垂直
	}

	private void OnGUI()
	{
		GUI.Label( new Rect( 0, 0, 100, 50 ), axisHor.ToString() );
		GUI.Label( new Rect( 0, 20, 100, 50 ), axisVer.ToString() );
	}
}
