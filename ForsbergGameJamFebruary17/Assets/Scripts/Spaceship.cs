﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MoveableBase {

	#region Fields/Properties

	public GameObject Mesh;
	public Audio AmbientSfx;
	public Audio ExplosionSfx;
	public Audio HitSfx;
	public GameObject Particles;
	public GameObject LoadingScreen;

	[Header("Force")]
	public float ForwardForce = 1;
	public float IdleForce = 1;

	[Header("Torque")]
	public bool InvertedPitch = true;
	public float PitchTorque = 1;
	public float YawTorque = 1;
	public float RollTorque = 1;

	[Header("Max")]
	public float MaxVelocity = 20;
	public float MaxAngularVelocity = 1;

	private Collider _collider;
	private FracturedObject _fracturedObject;
	private Rigidbody _rigidbody;
	private bool _isDead;

	#endregion
	#region Events

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.maxAngularVelocity = MaxAngularVelocity;

		_currentHealth = StartHealth;
		_collider = Mesh.GetComponent<Collider>();
		_fracturedObject = GetComponentInChildren<FracturedObject>();
	}

	void Start()
	{
		AudioManager.Instance.Play(AmbientSfx, transform.position);
	}

	void Update()
	{
		if (!_isDead)
		{
			Fire();
		}
	}

	void FixedUpdate()
	{
		if (!_isDead)
		{
			if (_rigidbody.velocity.magnitude > MaxVelocity)
			{
				_rigidbody.velocity = _rigidbody.velocity.normalized * MaxVelocity;

			}

			if (Trigger > 0)
			{
				_rigidbody.AddForce(transform.forward * Trigger * ForwardForce);
			}

			_rigidbody.AddForce(transform.forward * IdleForce);


			_rigidbody.AddTorque(transform.right * (InvertedPitch ? AxisLeft.y : -AxisLeft.y) * PitchTorque);
			_rigidbody.AddTorque(transform.up * AxisLeft.x * YawTorque);
			_rigidbody.AddTorque(transform.forward * (-AxisRight.x) * RollTorque);

			if (_isFiringRight)
			{
				AudioManager.Instance.Play(LazerSfx, transform.position);

				InstantiateProjectile(SpawnLeft);
				InstantiateProjectile(SpawnRight);
				_isFiringRight = false;
			}
		}
	}

	void OnTriggerEnter(Collider c)
	{
		var projectile = c.gameObject.GetComponentInParent<Projectile>();

		if (projectile != null && projectile.gameObject.layer == Layers.TurretProjectile.Index)
		{
			_currentHealth -= projectile.DamageAmount;
			Destroy(c.transform.parent.gameObject);

			if (_currentHealth <= 0)
			{
				AudioManager.Instance.Play(ExplosionSfx, transform.position);
				_fracturedObject.Explode(c.transform.position, 100f);
				_isDead = true;
				Destroy(Particles);
				//Destroy(Mesh);
				
				Invoke("LoadGameOverScreen", GameManager.Instance.TimeAfterDeath);
			}
			else
			{
				AudioManager.Instance.Play(HitSfx, transform.position);
			}
		}
	}

	void OnCollisionEnter(Collision c)
	{
		AudioManager.Instance.Play(ExplosionSfx, transform.position);
		_fracturedObject.Explode(c.contacts[0].point, 100f);
		Destroy(Particles);
		_isDead = true;

		Invoke("LoadGameOverScreen", GameManager.Instance.TimeAfterDeath);
	}

	#endregion
	#region Methods

	public void LoadGameOverScreen()
	{
		LoadingScreen.gameObject.SetActive(true);
		SceneManager.LoadScene("GameOver");
	}

	#endregion
}
