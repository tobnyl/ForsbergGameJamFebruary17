using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
	#region Fields/Properties

	public UnityEngine.UI.Image Background;

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
			Background.gameObject.SetActive(true);

			SceneManager.LoadScene("Main");
		}

		if (Input.GetButtonDown("Cancel"))
		{
			Background.gameObject.SetActive(true);
			SceneManager.LoadScene("StartScreen");
		}
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}