﻿﻿using UnityEngine;
using System.Collections;

public class MoveableBase : MonoBehaviour 
{
	#region Fields/Properties

	public int Index;
	public Audio LazerSfx;

	[Header("Projectile")]
	public GameObject ProjecitlePrefab;
	public GameObject SpawnLeft;
	public GameObject SpawnRight;
	public float ProjectileForce = 10f;
	public float Cooldown = 1;

	[Header("Health")]
	public int StartHealth = 100;
	[ReadOnly, SerializeField]
	protected int _currentHealth;

	protected bool _isFiringRight;
	protected float _currentCooldownRight;

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
		get { return Input.GetButton("Fire" + Index); }
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

	protected void Fire()
	{
		if (!_isFiringRight && _currentCooldownRight <= 0 && FireButtonDown)
		{
			_isFiringRight = true;
			_currentCooldownRight = Cooldown;
		}

		_currentCooldownRight -= Time.deltaTime;
	}

	protected void InstantiateProjectile(GameObject spawn)
	{
		var go = ProjecitlePrefab.Instantiate(spawn.transform.position, spawn.transform.rotation) as GameObject;
		var projectileRigidbody = go.GetComponent<Rigidbody>();
		var collider = go.GetComponentInChildren<Collider>();

		projectileRigidbody.AddForce(go.transform.forward * ProjectileForce, ForceMode.Impulse);

		//Physics.IgnoreCollision(c, collider);
	}

	#endregion

}