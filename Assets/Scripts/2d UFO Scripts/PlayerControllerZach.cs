using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerZach : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;

	private int count;
	public Text countText;
	public Text winText;


	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		count = 0;
		winText.text = "";
		SetCountText ();
		Cursor.visible = false; //Disables mouse cursor
	}

 	void Update()
	{		
		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			Screen.fullScreen = !Screen.fullScreen;
		}
	}


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}
