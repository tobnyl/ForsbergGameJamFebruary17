﻿﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	#region Fields/Properties

	public int DamageAmount = 10;
	
	#endregion
	#region Events

	void OnCollisionEnter(Collision c)
	{
		Debug.Log("Something!");

		if (c.gameObject.layer == Layers.Ground.Index)
		{
			Destroy(gameObject);
		}
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}