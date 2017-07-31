using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerZach : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start () 
	{
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame, LateUpdate is called after (best for cameras waiting on player movement)
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
	}
}
