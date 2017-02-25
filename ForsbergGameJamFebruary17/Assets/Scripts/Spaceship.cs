using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	#region Fields/Properties

	public int Index = 1;

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

	private Vector2 AxisLeft
	{
		get { return new Vector3(Input.GetAxis("HorizontalLeft" + Index), -Input.GetAxis("VerticalLeft" + Index)); }
	}

	private Vector2 AxisRight
	{
		get { return new Vector3(Input.GetAxis("HorizontalRight" + Index), Input.GetAxis("VerticalRight" + Index)); }
	}

	private float Trigger
	{
		get { return Input.GetAxis("TriggerRight1") * -1; }
	}

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
		Debug.Log(Trigger);

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

		_rigidbody.AddForce(transform.forward * Trigger * ForwardForce);

		//_rigidbody.AddTorque(transform.right * AxisLeft.y * PitchTorque);
		_rigidbody.AddTorque(transform.up * AxisLeft.x * YawTorque);
		//_rigidbody.AddTorque(transform.forward * (-AxisLeft.x) * RollTorque);


	}

	#endregion
	#region Methods



	#endregion
}
