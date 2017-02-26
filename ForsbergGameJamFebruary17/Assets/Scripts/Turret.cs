using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Turret : MoveableBase 
{
	#region Fields/Properties
		
	[Header("Base")]
	public GameObject Base;
	public float BaseRotationSpeedY = 10f;
	public float BaseSlerpSpeedY = 1f;	

	[Header("Head")]
	public GameObject Head;
	public float CannonRotationSpeedX = 10f;
	public float CannonSlerpSpeedX = 1f;
	public Vector2 CannonAngleLimit;

	private float _currentBaseAngleY;
	private float _currentCannonAngleX;
	private List<MeshRenderer> _meshRenderers;

	public Camera _camera;

	public bool CameraEnabled
	{
		set { _camera.gameObject.SetActive(value); }
	}

	#endregion
	#region Events

	void Awake()
	{
		_meshRenderers = GetComponentsInChildren<MeshRenderer>().ToList();
		_currentHealth = StartHealth;

		_camera = GetComponentInChildren<Camera>();
	}
	
	void Start() 
	{
	
	}

	void Update() 
	{
		RotateBase();
		RotateCannon();
		Fire();
	}

	void FixedUpdate()
	{
		if (_isFiringRight)
		{
			InstantiateProjectile(SpawnLeft);
			InstantiateProjectile(SpawnRight);
			_isFiringRight = false;

			AudioManager.Instance.Play(LazerSfx, transform.position);
		}
	}

	void OnTriggerEnter(Collider c)
	{
		var projectile = c.gameObject.GetComponentInParent<Projectile>();

		if (projectile != null && projectile.gameObject.layer == Layers.SpaceshipProjectile.Index)
		{
			_currentHealth -= projectile.DamageAmount;
			Destroy(c.transform.parent.gameObject);

			if (_currentHealth <= 0)
			{
				foreach (var mr in _meshRenderers)
				{
					mr.enabled = false;
				}
			}
		}
	}

	#endregion
	#region Methods

	private void RotateBase()
	{
		_currentBaseAngleY += AxisLeft.x * BaseRotationSpeedY;

		var newRotationY = Quaternion.AngleAxis(_currentBaseAngleY + transform.rotation.eulerAngles.y, Base.transform.up);

		Base.transform.rotation = Quaternion.Slerp(Base.transform.rotation, newRotationY, Time.deltaTime * BaseSlerpSpeedY);
	}

	private void RotateCannon()
	{
		_currentCannonAngleX += AxisRight.y * CannonRotationSpeedX;

		_currentCannonAngleX = Mathf.Clamp(_currentCannonAngleX, CannonAngleLimit.x, CannonAngleLimit.y);
		
		var newRotationX = Quaternion.AngleAxis(_currentCannonAngleX, Base.transform.right) * Quaternion.AngleAxis(_currentBaseAngleY + transform.rotation.eulerAngles.y, Base.transform.up);
		Head.transform.rotation = Quaternion.Slerp(Head.transform.rotation, newRotationX, Time.deltaTime * CannonSlerpSpeedX);
	}

	#endregion

}