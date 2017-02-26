using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour 
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

		if (Input.GetButtonDown("Cancel"))
		{
			Debug.Log("Yes?");

			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif

			Application.Quit();
		}
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}