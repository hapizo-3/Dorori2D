using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
	//自分のメッシュを指定する
	[SerializeField] Mesh myMesh;

    // Start is called before the first frame update
    void Start()
    {
		Debug.Log( transform.GetChild( 0 ).name );
	}

    // Update is called once per frame
    void Update()
    {
		
    }

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireMesh( myMesh, this.gameObject.transform.position,
							 Quaternion.identity, new Vector3( 1, 1, 1 ) );
	}
}
