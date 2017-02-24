using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ThirdPersonCamera : MonoBehaviour 
{
	// TODO: slerp
	// TODO: up/down axis

	#region Fields

	public GameObject Target;
	public float DistanceFromTarget = 5.0f;		
	public float RotationSpeedY = 1.0f;
	public float RotationSpeedX = 1.0f;
	public float MaxAngleX = 45f;
	public float OffsetY;

	[Space(10f)]

	public bool UseSlerpRotation;
	public bool UseSlerpTranslation;
	public float SlerpSpeed = 1.0f;	

	private Camera _camera;	
	private Vector3 _offset;
	private float _currentAngleY;
	private float _currentAngleX;
	private Vector3 _offsetY;


	#endregion
	#region Properties

	private Vector3 AxisRight
	{
		get { return new Vector3(Input.GetAxis("HorizontalRight1"), 0, Input.GetAxis("VerticallRight1")); }
	}

	#endregion
	#region Events

	void Awake()
	{
		_camera = GetComponent<Camera>();
	}
	
	void Start() 
	{
		transform.position = Target.transform.position - Target.transform.forward * DistanceFromTarget;

		_offset = transform.position - Target.transform.position;
		_offsetY = new Vector3(0, OffsetY, 0);

	}

	void Update() 
	{
		_currentAngleY += AxisRight.x * RotationSpeedY;
		_currentAngleX += AxisRight.z * RotationSpeedX;

		_currentAngleX = Mathf.Clamp(_currentAngleX, -MaxAngleX, MaxAngleX);		
	}

	void LateUpdate()
	{		
		var newRotationY = Quaternion.AngleAxis(_currentAngleY, Vector3.up);
		var newRotationX = Quaternion.AngleAxis(_currentAngleX, Vector3.right);
		var newPosition = newRotationY * _offset + Target.transform.position + _offsetY;

		transform.position =
			UseSlerpTranslation ?
			Vector3.Slerp(transform.position, newPosition, Time.deltaTime * SlerpSpeed) :
			newPosition;

		transform.rotation = 
			UseSlerpRotation ? 
			Quaternion.Slerp(transform.rotation, newRotationY * newRotationX, Time.deltaTime * SlerpSpeed) : 
			newRotationY * newRotationX;
	}

	#endregion
}
