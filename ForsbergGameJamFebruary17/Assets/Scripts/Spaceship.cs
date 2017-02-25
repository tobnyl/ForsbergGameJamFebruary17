using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	#region Fields/Properties

	public int Index = 1;
	public float PitchTorque = 1;
	public float YawTorque = 1;

	private Rigidbody _rigidbody;

	private Vector2 AxisLeft
	{
		get { return new Vector3(Input.GetAxis("HorizontalLeft" + Index), -Input.GetAxis("VerticalLeft" + Index)); }
	}

	private Vector2 AxisRight
	{
		get { return new Vector3(Input.GetAxis("HorizontalRight" + Index), Input.GetAxis("VerticalRight" + Index)); }
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
		Debug.LogFormat("AxisLeft: ({0}, {1})", AxisLeft.x, AxisLeft.y);
		Debug.LogFormat("AxisRight: ({0}, {1})", AxisRight.x, AxisRight.y);
	}

	void FixedUpdate()
	{

		_rigidbody.AddTorque(transform.right * AxisLeft.y * PitchTorque);
		_rigidbody.AddTorque(Vector3.up * AxisLeft.x * YawTorque);
	}

	#endregion
	#region Methods



	#endregion
}
