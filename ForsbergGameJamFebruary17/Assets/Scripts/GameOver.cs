using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
	#region Fields/Properties

	
	
	#endregion
	#region Events
	
	void Awake()
	{
		
	}
	
	void Start() 
	{
	
	}

	void Update() 
	{
		if (Input.GetButtonDown("Submit"))
		{
			SceneManager.LoadScene("Main");
		}
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}