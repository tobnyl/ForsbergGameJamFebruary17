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

	[Header("Projectile")]
	public GameObject ProjecitlePrefab;
	public GameObject SpawnLeft;
	public GameObject SpawnRight;
	public float Cooldown = 1;

	private float _currentBaseAngleY;
	private float _currentCannonAngleX;
	private bool _isFiringLeft;
	private bool _isFiringRight;
	private float _currentCooldownLeft;
	private float _currentCooldownRight;


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
		Fire();

		//Debug.LogFormat("AxisLeft: ({0}, {1})", AxisLeft.x, AxisLeft.y);
		//Debug.LogFormat("AxisRight: ({0}, {1})", AxisRight.x, AxisRight.y);
	}

	void FixedUpdate()
	{
		if (_isFiringLeft)
		{
			InstantiateProjectile(SpawnLeft);

			_isFiringLeft = false;
		}

		if (_isFiringRight)
		{
			InstantiateProjectile(SpawnRight);
			_isFiringRight = false;
		}
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
		_currentCannonAngleX += AxisRight.y * CannonRotationSpeedX;

		_currentCannonAngleX = Mathf.Clamp(_currentCannonAngleX, CannonAngleLimit.x, CannonAngleLimit.y);
		
		var newRotationX = Quaternion.AngleAxis(_currentCannonAngleX, Base.transform.right) * Quaternion.AngleAxis(_currentBaseAngleY + transform.rotation.eulerAngles.y, Base.transform.up);
		Head.transform.rotation = Quaternion.Slerp(Head.transform.rotation, newRotationX, Time.deltaTime * CannonSlerpSpeedX);
	}

	private void Fire()
	{
		Debug.Log(TriggerRaw);

		if (!_isFiringLeft && _currentCooldownLeft <= 0 && TriggerRaw < 0)
		{
			_isFiringLeft = true;
			_currentCooldownLeft = Cooldown;
		}
		else if (!_isFiringRight && _currentCooldownRight <= 0 && Trigger > 0)
		{			
			_isFiringRight = true;
			_currentCooldownRight = Cooldown;
		}

		_currentCooldownLeft -= Time.deltaTime;
		_currentCooldownRight -= Time.deltaTime;
	}

	private void InstantiateProjectile(GameObject spawn)
	{
		var go = ProjecitlePrefab.Instantiate(spawn.transform.position, spawn.transform.rotation) as GameObject;
		var projectileRigidbody = go.GetComponent<Rigidbody>();

		projectileRigidbody.AddForce(go.transform.forward * 10f, ForceMode.Impulse);
	}

	#endregion

}