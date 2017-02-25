﻿﻿using UnityEngine;
using System.Collections;

public class Turret : MoveableBase 
{
	#region Fields/Properties
		
	[Header("Base")]
	public GameObject Base;
	public float BaseRotationSpeedY = 10f;
	public float BaseSlerpSpeedY = 1f;
	public Vector2 BaseAngleLimit;

	[Header("Head")]
	public GameObject Head;

	private float _currentBaseAngleY;
	private float _currentCanonAngleX;

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
	}

	#endregion
	#region Methods

	private void RotateBaseCannon()
	{
		_currentBaseAngleY += AxisRight.x * BaseRotationSpeedY;
		_currentBaseAngleY = Mathf.Clamp(_currentBaseAngleY, BaseAngleLimit.x, BaseAngleLimit.y);

		var newRotationY = Quaternion.AngleAxis(_currentBaseAngleY + transform.rotation.eulerAngles.y, Base.transform.up);

		Base.transform.rotation = Quaternion.Slerp(Base.transform.rotation, newRotationY, Time.deltaTime * BaseSlerpSpeedY);		
	}

	#endregion

}