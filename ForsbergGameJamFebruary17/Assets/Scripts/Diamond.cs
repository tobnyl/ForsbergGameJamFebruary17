﻿﻿using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour 
{
	#region Fields/Properties

	[Header("Health")]
	public int StartHealth = 100;
	[ReadOnly, SerializeField]
	protected int _currentHealth;

	public GameObject Collider;
	public float ExplosionForce = 1;

	private FracturedObject _fracturedObject;

	#endregion
	#region Events

	void Awake()
	{
		_fracturedObject = GetComponentInChildren<FracturedObject>();
		_currentHealth = StartHealth;
	}
	
	void Start() 
	{
	
	}

	void Update() 
	{
	
	}

	void OnCollisionEnter(Collision c)
	{
		var projectile = c.gameObject.GetComponentInParent<Projectile>();

		if (projectile != null && projectile.gameObject.layer == Layers.SpaceshipProjectile.Index)
		{
			_currentHealth -= projectile.DamageAmount;
			Destroy(c.transform.gameObject);

			if (_currentHealth <= 0)
			{
				_fracturedObject.Explode(c.transform.position, 100f);
				Destroy(Collider);
			}
		}
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}