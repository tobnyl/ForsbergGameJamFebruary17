/*

EXAMPLE USE:

if (Input.GetKeyDown(Jump))
{
	if (_groundChecker.IsGrounded)
	{
		_rigidBody.AddForce(Vector3.up * JumpSpeed);
		AudioManager.Instance.Play(GameManager.Instance.PlayerJumpsSfx[Random.Range(0, GameManager.Instance.PlayerJumpsSfx.Length)], transform.position);
	}
}

*/

//using UnityEngine;
//using System.Collections;

//public class GroundChecker : MonoBehaviour 
//{
//	#region Public Fields

//    public float RayCastLength = 1f;
//    public bool IsGrounded;

//	#endregion	
//	#region Private Fields	

//    private Ray _rayCenter;
//    private Ray _rayLeft;
//    private Ray _rayRight;
//    private Vector3 _xOffset;
//    private Player _player;

//    private Vector3 _yOffset;

//	#endregion
//	#region Events

//    void Awake()
//    {
//        _yOffset = Vector3.zero;
//    }

//    void Start()
//    {
//        _player = GetComponent<Player>();

//        _xOffset = new Vector3(_player.BoxCollider.size.x/2f, 0, 0);
//        _yOffset = new Vector3(0, _player.BoxCollider.size.y/2f - _player.BoxCollider.center.y - 0.1f, 0);
//    }

//	void Update()
//	{
//        _rayLeft = new Ray(transform.position - _xOffset - _yOffset, Vector3.down);
//        _rayRight = new Ray(transform.position + _xOffset - _yOffset, Vector3.down);
//        _rayCenter = new Ray(transform.position - _yOffset, Vector3.down);

//        //Debug.DrawLine(_rayCenter.origin, _rayCenter.origin + _rayCenter.direction * RayCastLength, Color.magenta, 1f);
//        //Debug.DrawLine(_rayLeft.origin, _rayLeft.origin + _rayLeft.direction * RayCastLength, Color.yellow, 1f);
//        //Debug.DrawLine(_rayRight.origin, _rayRight.origin + _rayRight.direction * RayCastLength, Color.cyan, 1f);

//        IsGrounded = Physics.Raycast(_rayLeft, RayCastLength) ||
//               Physics.Raycast(_rayRight, RayCastLength) ||
//               Physics.Raycast(_rayCenter, RayCastLength);
//	}
	
//	#endregion
//}
