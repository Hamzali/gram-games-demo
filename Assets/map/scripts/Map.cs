using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour {

	private int size;

	public List<GameObject> buildings;

	void Start ()
	{
		size = GameManager.instance.mapSize;
		gameObject.GetComponent<Transform> ().localScale = new Vector3 (size, 0, size);
		gameObject.GetComponent<Transform> ().position = new Vector3(0, -.5f, 0);
	}

	void Update ()
	{
		
	}
		
	#region Building Managements
	void Built (GameObject building) 
	{
		
	}
		
	void Demolish (GameObject building)
	{
		
	}
	#endregion


}
