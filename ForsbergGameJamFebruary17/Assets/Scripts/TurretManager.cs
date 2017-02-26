﻿﻿using UnityEngine;
using System.Linq;
using System.Collections;

public class TurretManager : MonoBehaviour 
{
	#region Fields/Properties

	public Turret[] Turrets;

	private Turret _currentTurret;
	
	#endregion
	#region Events
	
	void Awake()
	{
		
	}
	
	void Start() 
	{
		foreach (var turret in Turrets)
		{
			turret.CameraEnabled = false;
		}

		_currentTurret = Turrets.First();
		_currentTurret.CameraEnabled = true;
	}

	void Update() 
	{
	
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}