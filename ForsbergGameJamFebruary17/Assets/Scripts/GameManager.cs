﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    #region Fields/Properties

    public float DestroyItemAfterTime;
	public GameObject DetachedChunkParent;


	public Audio Test;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    #endregion
    #region Events

    void Awake()
	{
        if (_instance != null)
        {
            _instance = this;
        }
	}
	
	void Start() 
	{
        //AudioManager.Instance.Play(Test, transform.position);
	}

	void Update() 
	{
	
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}