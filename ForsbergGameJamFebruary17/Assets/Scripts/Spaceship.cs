using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	#region Fields/Properties

	private Rigidbody _rigidbody;

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

	}

	void FixedUpdate()
	{
		_rigidbody.AddForce(transform.forward * 10f);
	}

	#endregion
	#region Methods



	#endregion
}
