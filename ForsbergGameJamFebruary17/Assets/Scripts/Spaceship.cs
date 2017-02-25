using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	#region Fields/Properties

	public int Index = 1;
	public float ForwardForce = 1;
	public float PitchTorque = 1;
	public float YawTorque = 1;
	public float RollTorque = 1;

	private Rigidbody _rigidbody;

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
	}

	void Start()
	{

	}

	void Update()
	{
		//Debug.LogFormat("AxisLeft: ({0}, {1})", AxisLeft.x, AxisLeft.y);
		//Debug.LogFormat("AxisRight: ({0}, {1})", AxisRight.x, AxisRight.y);
	}

	void FixedUpdate()
	{
		_rigidbody.AddForce(transform.forward * Trigger * ForwardForce);


		if (Mathf.Abs(AxisLeft.y) > 0.2)
		{
			_rigidbody.AddTorque(transform.right * AxisLeft.y * PitchTorque);
		}
		if (Mathf.Abs(AxisLeft.x) > 0.2)
		{
			_rigidbody.AddTorque(transform.up * AxisLeft.x * YawTorque);
		}
		if (Mathf.Abs(AxisRight.x) > 0.2)
		{
			_rigidbody.AddTorque(transform.forward * (-AxisRight.x) * RollTorque);
		}
	}

	#endregion
	#region Methods



	#endregion
}
