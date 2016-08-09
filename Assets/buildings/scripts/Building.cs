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
		
	}

}
