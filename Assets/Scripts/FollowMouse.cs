using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// © 2017 TheFlyingKeyboard
// theflyingkeyboard.net

public class FollowMouse : MonoBehaviour {
	
	public float moveSpeed = 0.01f;

	void Start () {
	}
		
	void Update () {
		transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed);
	}
}