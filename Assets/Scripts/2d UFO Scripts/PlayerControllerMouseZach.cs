using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMouseZach : MonoBehaviour {

	private Vector3 destination;
	private Vector3 origin;
	private float percentageComplete = 1.0f;
	private float elapsedTime;
	private float travelTime;
	private float speed = 10.0f;

	private float maxSpeed = 80.0f; // Z Test Acceleration

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			var mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Debug.Log (mouse);
			destination = new Vector3(mouse.x, mouse.y, 0);
			origin = transform.position;
			percentageComplete = 0;
			elapsedTime = 0;
			var distance = Vector3.Distance (destination, new Vector3 (transform.position.x, transform.position.y, 0));
			travelTime = distance / speed;

			Debug.Log (speed);

			if (speed < maxSpeed) { // Z Test Acceleration
			speed += 10;
			}

			if (speed == maxSpeed) { // Z Test Reset Speed ZzZzZzZzZz
			speed = 10;
			}

		} else if (percentageComplete < 1.0f) {
			percentageComplete = elapsedTime / travelTime;
			transform.position = new Vector3 (
				Mathf.Lerp (origin.x, destination.x, percentageComplete),
				Mathf.Lerp (origin.y, destination.y, percentageComplete),
				0);
			elapsedTime += Time.deltaTime;
		}
	}
}



/*
	Vector3 newPosition;
		
	void Start () {
		newPosition = transform.position;
	}
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				newPosition = hit.point;
				transform.position = newPosition;
			}
		}
	}
}

*/