using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour{

	public GameObject dropDownBuildings;

	// Map variables.
	public int mapSize;
	public bool isBuilding;

	// Building management.
	public List<GameObject> buildingTypes;

	// Camera options.
	public int maxZoom;
	public int minZoom;
	public float moveSpeed;

	public int currentSelection;

	// Singleton implementation.
	public static GameManager instance = null;
	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	void Start () 
	{
		initGame ();
	}

	void initGame () 
	{
		List<string> options = new List<string>();
		for (int i = 0 ; i < buildingTypes.Count; i++) {
			options.Add (buildingTypes[i].name);
		}
			
		dropDownBuildings.GetComponent<Dropdown> ().AddOptions(options);
	}

	public void SetSelection () 
	{
		currentSelection = dropDownBuildings.GetComponent<Dropdown> ().value;
	}


	#region SAVE/LOAD
	public void Save() 
	{
		
	}

	public void Load()
	{
		
	}
	#endregion

	#region Grids
	public void DrawGrids ()
	{	
		var start = -1 * mapSize / 2 + 0.5f;
		var end = mapSize / 2 - 0.5f;
		if (isBuilding) {
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Begin (GL.LINES);

			GL.Color (Color.green);
			for (float i = start; i <= end; i++) {
				GL.Vertex3(start, -.5f, i);
				GL.Vertex3(end, -.5f, i);

				GL.Vertex3(i, -.5f, start);
				GL.Vertex3(i, -.5f, end);

			}

			GL.PopMatrix();
			GL.End();
		} 
	}
	#endregion

}
