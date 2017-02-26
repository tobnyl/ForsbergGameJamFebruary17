using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Base : MonoBehaviour 
{
	#region Fields/Properties

	public FracturedObject Mitten;

	private List<Diamond> diamondList;
	
	#endregion
	#region Events
	
	void Awake()
	{
		diamondList = GetComponentsInChildren<Diamond>().ToList();
	}
	
	void Start() 
	{
	
	}

	void Update() 
	{
		//var count = !diamondList.Any(x => !x.IsExploded);

		if (!diamondList.Any(x => !x.IsExploded))
		{
			Debug.Log("Explode base!!!");
			Mitten.Explode(Mitten.gameObject.transform.position, 100f);
		}
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}