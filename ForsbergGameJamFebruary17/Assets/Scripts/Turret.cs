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
		RotateBaseCannon();

		//Debug.LogFormat("AxisLeft: ({0}, {1})", AxisLeft.x, AxisLeft.y);
		Debug.LogFormat("AxisRight: ({0}, {1})", AxisRight.x, AxisRight.y);
	}

	#endregion
	#region Methods

	private void RotateBaseCannon()
	{
		_currentBaseAngleY += AxisRight.x * BaseRotationSpeedY;

		Debug.Log(_currentBaseAngleY);

		//_currentBaseAngleY = Mathf.Clamp(_currentBaseAngleY, BaseAngleLimit.x, BaseAngleLimit.y);

		var newRotationY = Quaternion.AngleAxis(_currentBaseAngleY + transform.rotation.eulerAngles.y, Base.transform.up);

		Base.transform.rotation = Quaternion.Slerp(Base.transform.rotation, newRotationY, Time.deltaTime * BaseSlerpSpeedY);		
	}

	#endregion

}