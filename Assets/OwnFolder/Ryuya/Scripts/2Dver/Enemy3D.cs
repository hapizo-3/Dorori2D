using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3D : Actor3D
{

	[SerializeField] GameObject playerObj;

	[SerializeField] GUISkin guiskin;

	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		EnemyMove();
    }

	//敵移動処理
	void EnemyMove()
	{

	}

	private void OnGUI()
	{
		GUI.color = Color.yellow;
		GUI.Box( new Rect( Screen.width - 50, 10, 40, 20 ), Screen.width.ToString(), guiskin.GetStyle( "Box" ) );
		//GUI.Box( new Rect( Screen.width - 50, 30, 40, 20 ), Screen.width.ToString(), guiskin.GetStyle( "Box" ) );
	}

}
