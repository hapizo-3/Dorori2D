using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor3D : MonoBehaviour
{
	//右スティック情報変数
	private float axisHorParentR;
	private float axisVerParentR;

	//左スティック情報変数
	private float axisHorParentL;
	private float axisVerParentL;

	/// <summary>
	/// プロパティメソッドコレクション
	/// </summary>

	//水平方向入力R
	public float axisHorR
	{
		set {
			axisHorParentR = value;
		}
		get {
			return axisHorParentR;
		}
	}
	//垂直方向入力R
	public float axisVerR
	{
		set {
			axisVerParentR = value;
		}
		get {
			return axisVerParentR;
		}
	}
	
	//水平方向入力L
	public float axisHorL
	{
		set {
			axisHorParentL = value;
		}
		get {
			return axisHorParentL;
		}
	}

	//垂直方向入力L
	public float axisVerL
	{
		set {
			axisVerParentL = value;
		}
		get {
			return axisVerParentL;
		}
	}

}
