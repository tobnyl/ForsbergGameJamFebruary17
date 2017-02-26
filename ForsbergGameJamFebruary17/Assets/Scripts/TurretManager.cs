﻿﻿using UnityEngine;
using System.Linq;
using System.Collections;

public class TurretManager : MonoBehaviour 
{
	#region Fields/Properties

	public Turret[] Turrets;

	private Turret _currentTurret;
	private int _currentTurretIndex;
	private int Count;
	
	public bool PreviousTurretButton
	{
		get { return Input.GetButtonDown("PreviousTurret2"); }
	}

	public bool NextTurretButton
	{
		get { return Input.GetButtonDown("NextTurret2"); }
	}

	#endregion
	#region Events

	void Awake()
	{
		
	}
	
	void Start() 
	{
		Count = Turrets.Length;

		DisableAllTurretCameras();

		_currentTurret = Turrets.First();
		_currentTurret.CameraEnabled = true;
	}

	void Update() 
	{
		if (PreviousTurretButton)
		{
			_currentTurretIndex--;
			
			if (_currentTurretIndex < 0)
			{
				_currentTurretIndex = Count - 1;
			}

			SwitchTurret(_currentTurretIndex);
		}

		if (NextTurretButton)
		{
			_currentTurretIndex++;

			if (_currentTurretIndex > Count - 1)
			{
				_currentTurretIndex = 0;
			}

			SwitchTurret(_currentTurretIndex);
		}

		//Debug.Log(_currentTurretIndex);
	}
	
	#endregion
	#region Methods
	
	private void SwitchTurret(int index)
	{
		DisableAllTurretCameras();

		_currentTurret = Turrets[index];
		_currentTurret.CameraEnabled = true;
	}

	private void DisableAllTurretCameras()
	{
		foreach (var turret in Turrets)
		{
			turret.CameraEnabled = false;
		}
	}
	
	#endregion
	
}