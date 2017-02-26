using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MoveableBase {

	#region Fields/Properties

	public GameObject Mesh;

	[Header("Force")]
	public float ForwardForce = 1;
	public float IdleForce = 1;

	[Header("Torque")]
	public float PitchTorque = 1;
	public float YawTorque = 1;
	public float RollTorque = 1;

	[Header("Max")]
	public float MaxVelocity = 20;
	public float MaxAngularVelocity = 1;

	private Collider _collider;

	private Rigidbody _rigidbody;

	#endregion
	#region Events

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.maxAngularVelocity = MaxAngularVelocity;

		_currentHealth = StartHealth;
		_collider = Mesh.GetComponent<Collider>();
	}

	void Start()
	{
	}

	void Update()
	{
		Fire();
	}

	void FixedUpdate()
	{
		if (_rigidbody.velocity.magnitude > MaxVelocity)
		{
			_rigidbody.velocity = _rigidbody.velocity.normalized * MaxVelocity;

		}

		if (Trigger > 0)
		{
			_rigidbody.AddForce(transform.forward * Trigger * ForwardForce);
		}
		else
		{
			_rigidbody.AddForce(transform.forward * Trigger * IdleForce);
		}

		_rigidbody.AddTorque(transform.right * -AxisLeft.y * PitchTorque);
		_rigidbody.AddTorque(transform.up * AxisLeft.x * YawTorque);
		_rigidbody.AddTorque(transform.forward * (-AxisRight.x) * RollTorque);

		if (_isFiringRight)
		{
			
			InstantiateProjectile(SpawnLeft);
			InstantiateProjectile(SpawnRight);
			_isFiringRight = false;
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
				Destroy(Mesh);
			}
		}
	}

	#endregion
	#region Methods



	#endregion
}
