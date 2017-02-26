using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour 
{
	#region Fields/Properties

	public UnityEngine.UI.Image Background;

	#endregion
	#region Events

	void Awake()
	{
		UnityEngine.Cursor.visible = false;
		UnityEngine.Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Start() 
	{
	
	}

	void Update() 
	{
		if (Input.GetButtonDown("Submit"))
		{
			Background.gameObject.SetActive(true);

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