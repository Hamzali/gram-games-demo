using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	[SerializeField]
	private int size;
	[SerializeField]
	private Color color;

	private bool isBuilt;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = color;
	}

	// Update is called once per frame
	void Update () {
		onBuilding ();
	}

	void onBuilding () 
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			transform.position += new Vector3 (1, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			transform.position += new Vector3 (-1, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			transform.position += new Vector3 (0, 0, 1);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			transform.position += new Vector3 (0, 0, -1);
		}  
	}
}
