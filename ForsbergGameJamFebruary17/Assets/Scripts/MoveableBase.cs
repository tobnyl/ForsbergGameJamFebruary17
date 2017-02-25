﻿﻿using UnityEngine;
using System.Collections;

public class MoveableBase : MonoBehaviour 
{
	#region Fields/Properties

	public int Index;

	protected Vector2 AxisLeft
	{
		get { return new Vector2(Input.GetAxis("HorizontalLeft" + Index), -Input.GetAxis("VerticalLeft" + Index)); }
	}

	protected Vector2 AxisRight
	{
		get { return new Vector2(Input.GetAxis("HorizontalRight" + Index), Input.GetAxis("VerticalRight" + Index)); }
	}

	protected float Trigger
	{
		get { return Input.GetAxis("TriggerRight1") * -1; }
	}

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
	
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}