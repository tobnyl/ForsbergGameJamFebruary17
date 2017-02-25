﻿﻿﻿using UnityEngine;
using System.Collections;

public class MoveableBase : MonoBehaviour 
{
	#region Fields/Properties

	public int Index;

	[Header("Projectile")]
	public GameObject ProjecitlePrefab;
	public GameObject SpawnLeft;
	public GameObject SpawnRight;
	public float ProjectileForce = 10f;
	public float Cooldown = 1;

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
		get { return Input.GetAxis("TriggerRight" + Index) * -1; }
	}

	protected float TriggerRaw
	{
		get { return Input.GetAxisRaw("TriggerRight" + Index) * -1; }
	}

	protected bool FireButtonDown
	{
		get { return Input.GetButtonDown("Fire" + Index); }
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