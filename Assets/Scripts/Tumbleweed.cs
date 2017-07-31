using UnityEngine;
//using System;
using System.Collections;
using UnityEngine.UI;

public class Tumbleweed : MonoBehaviour {

	public float speed,RotationSpeed;
		
	void Start(){
		InvokeRepeating ("positionRandomizer", 1, 75);
	}

	void Update(){
		transform.position += Vector3.right * speed;
		transform.Rotate (0,0,-RotationSpeed);
	}

	void positionRandomizer () {
		int randomizer = Random.Range (0, 3);

		switch (randomizer) {
		case 0: 
			transform.localPosition = new Vector3(-900, -238, 0);
			break;
		case 1: 
			transform.localPosition = new Vector3(-900, -50, 0);
			break;
		case 2:
			transform.localPosition = new Vector3 (-900, 109, 0);
			break;
		}
	}

	//void ResetPosition () {
	//	transform.localPosition = new Vector3(-900, -50, 0);
	//}
}
