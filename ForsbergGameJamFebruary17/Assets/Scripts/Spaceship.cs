using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MoveableBase {

	#region Fields/Properties

	[Header("Force")]
	public float ForwardForce = 1;

	[Header("Torque")]
	public float PitchTorque = 1;
	public float YawTorque = 1;
	public float RollTorque = 1;

	[Header("Max")]
	public float MaxVelocity = 20;
	public float MaxAngularVelocity = 1;

	private Rigidbody _rigidbody;
	private Transform _transform;

	

	#endregion
	#region Events

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.maxAngularVelocity = MaxAngularVelocity;
	}

	void Start()
	{
		_transform = transform;
	}

	void Update()
	{
		//Debug.Log(Trigger);

		//Debug.LogFormat("AxisLeft: ({0}, {1})", AxisLeft.x, AxisLeft.y);
		//Debug.LogFormat("AxisRight: ({0}, {1})", AxisRight.x, AxisRight.y);
		//Debug.LogFormat("Velocity: {0}", _rigidbody.velocity);
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

		_rigidbody.AddTorque(transform.right * AxisLeft.y * PitchTorque);
		_rigidbody.AddTorque(transform.up * AxisLeft.x * YawTorque);
		_rigidbody.AddTorque(transform.forward * (-AxisRight.x) * RollTorque);


	}

	#endregion
	#region Methods



	#endregion
}
