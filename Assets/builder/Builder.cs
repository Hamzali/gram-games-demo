using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

	public GameObject Map;

	public GameObject builderUI;

	public GameObject CancelButton;

	public GameObject buildingSelector;

	public GameObject building;

	private bool isOK;


	// Use this for initialization
	void Start () {
		builderUI.SetActive (false);
		CancelButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartBuilding() {
		GameManager.instance.isBuilding = true;

		if (building != null) {
			building = null;
		}

		var buildingType = GameManager.instance.buildingTypes [GameManager.instance.currentSelection];
		building = Instantiate (buildingType, Vector3.zero, Quaternion.identity) as GameObject;

		building.transform.parent = gameObject.transform;

		builderUI.SetActive (true);
		CancelButton.SetActive (true);

		buildingSelector.SetActive (false);

	}

	public void Construct() 
	{
		

		if (isOK) {
			GameManager.instance.isBuilding = false;
		} else {
			
		}
	}

	public void Cancel () 
	{
		GameManager.instance.isBuilding = false;
		builderUI.SetActive (false);
		CancelButton.SetActive (false);

		buildingSelector.SetActive (true);

		Destroy (building);
		building = null;
		transform.position = Vector3.zero;
	}

	void CheckContruction () 
	{
		
	}

	public void MoveLeft() {
		transform.position += new Vector3 (-1, 0, 0);
	}

	public void MoveRight() {
		transform.position += new Vector3 (1, 0, 0);
	}

	public void MoveUp() {
		transform.position += new Vector3 (0, 0, 1);
	}

	public void MoveDown() {
		transform.position += new Vector3 (0, 0, -1);
	}

}
