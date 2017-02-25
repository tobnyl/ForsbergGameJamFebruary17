﻿﻿using UnityEngine;
using System.Collections;

public class Turret : MoveableBase 
{
	#region Fields/Properties
		
	[Header("Base")]
	public GameObject Base;
	public float BaseRotationSpeedY = 10f;
	public float BaseSlerpSpeedY = 1f;	

	[Header("Head")]
	public GameObject Head;
	public float CannonRotationSpeedX = 10f;
	public float CannonSlerpSpeedX = 1f;
	public Vector2 CannonAngleLimit;

	private float _currentBaseAngleY;
	private float _currentCannonAngleX;

	#endregion
	#region Events

	void Awake()
	{
		
	}
	
	void Start() 
	{
	
	}

	void Update() 
	{
		RotateBase();
		RotateCannon();

		//Debug.LogFormat("AxisLeft: ({0}, {1})", AxisLeft.x, AxisLeft.y);
		Debug.LogFormat("AxisRight: ({0}, {1})", AxisRight.x, AxisRight.y);
	}

	#endregion
	#region Methods

	private void RotateBase()
	{
		_currentBaseAngleY += AxisLeft.x * BaseRotationSpeedY;

		var newRotationY = Quaternion.AngleAxis(_currentBaseAngleY + transform.rotation.eulerAngles.y, Base.transform.up);

		Base.transform.rotation = Quaternion.Slerp(Base.transform.rotation, newRotationY, Time.deltaTime * BaseSlerpSpeedY);		
	}

	private void RotateCannon()
	{
		_currentCannonAngleX += (-AxisRight.y) * CannonRotationSpeedX;

		_currentCannonAngleX = Mathf.Clamp(_currentCannonAngleX, CannonAngleLimit.x, CannonAngleLimit.y);
		Debug.Log(_currentCannonAngleX);

		var newRotationX = Quaternion.AngleAxis(_currentCannonAngleX, Base.transform.right);
		Head.transform.rotation = Quaternion.Slerp(Head.transform.rotation, newRotationX, Time.deltaTime * CannonSlerpSpeedX);
	}

	#endregion

}