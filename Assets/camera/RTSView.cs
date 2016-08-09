using UnityEngine;
using System.Collections;

public class RTSView : MonoBehaviour {

	private int bound;

	private int maxZoom;
	private int minZoom;

	float speed;

	float moveSensivityX;
	float moveSensivityZ;
	bool zoomUpdated = true;

	void OnPostRender () {
		GameManager.instance.DrawGrids ();
	}

	void Start () {
		bound = GameManager.instance.mapSize / 2 * -1;
		maxZoom = GameManager.instance.maxZoom;
		minZoom = GameManager.instance.minZoom;
		speed = GameManager.instance.moveSpeed;

		transform.position = new Vector3(0, 10, 0);
		transform.rotation = Quaternion.Euler (30, 45, 0);
	}


	// Update is called once per frame
	void Update () {
		CamControl ();
	}

	void CamControl () 
	{

		if(zoomUpdated) {
			//	
		}

		#region Mouse controls
		// Move.
		if(Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.x <= 1 
			|| Input.mousePosition.y >= Screen.height - 1 || Input.mousePosition.y <= 1) {
			// set the direction of the movement.
			var movementVector = new Vector3 (Input.mousePosition.x - Screen.width / 2, 0, Input.mousePosition.y - Screen.height / 2);
			movementVector =  Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * movementVector;

			var newPosition = transform.position + movementVector.normalized * speed;
			transform.position = new Vector3 (CheckBounds(newPosition.x), newPosition.y, CheckBounds(newPosition.z));
		}

		// Zoom.
		if (Input.mouseScrollDelta.y > 0 ) {
			Camera.main.orthographicSize += speed;
		} else if (Input.mouseScrollDelta.y < 0) {
			Camera.main.orthographicSize -= speed;
		}
		#endregion
			
		#region touch controls
		if(Input.touches.Length > 0) {
			// Move.
			if (Input.touches.Length == 1 && Input.touches[0].phase == TouchPhase.Moved) {
				if (zoomUpdated) {
					moveSensivityX = Camera.main.orthographicSize / 5f;
					moveSensivityZ = Camera.main.orthographicSize / 5f;
				}

				Vector3 delta = Input.touches [0].deltaPosition;

				var xMovement = delta.x * moveSensivityX * Time.deltaTime * speed; 
				var zMovement = delta.y * moveSensivityZ * Time.deltaTime * speed;
				var movementVector = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * new Vector3 (xMovement, 0, zMovement) * -1;
				var newPosition = transform.position + movementVector;
				transform.position = new Vector3 (CheckBounds(newPosition.x), newPosition.y, CheckBounds(newPosition.z));
			// Zoom 
			} else if (Input.touches.Length == 2) {
				// Store both touches.
				Touch touchZero = Input.GetTouch(0);
				Touch touchOne = Input.GetTouch(1);

				// Find the position in the previous frame of each touch.
				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				// Find the magnitude of the vector (the distance) between the touches in each frame.
				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

				// Find the difference in the distances between each frame.
				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

				Camera.main.orthographicSize += deltaMagnitudeDiff * speed;
			}
		}
		#endregion

		// Zoom bound check.
		if (Camera.main.orthographicSize <= minZoom)
			Camera.main.orthographicSize = minZoom;
		else if (Camera.main.orthographicSize >= maxZoom)
			Camera.main.orthographicSize = maxZoom;
	}

	float CheckBounds (float value) 
	{
		if (value >= 0)
			return 0;
		else if (value <= bound)
			return bound;

		return value;
	}
		
}
