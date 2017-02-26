﻿﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	#region Fields/Properties

	public int DamageAmount = 10;
	public float DestroyAfter = 5;
	
	#endregion
	#region Events

	void Awake()
	{
		Invoke("DestroyProjectile", DestroyAfter);
	}

	void OnCollisionEnter(Collision c)
	{
		//Debug.Log("ProjectileColl: " + c.gameObject.name);

		if (c.gameObject.layer == Layers.Ground.Index)
		{
			Destroy(gameObject);
		}
	}
	
	#endregion
	#region Methods
	
	public void DestroyProjectile()
	{
		Destroy(gameObject);
	}
	
	#endregion
	
}