using UnityEngine;
using System;
using System.Collections;

public class Clock : MonoBehaviour {

	public Transform hourshand;
	//public int seconds, minutes, hours; //this just shows you can write multiple things on one line
	float MoveSpeed = 24f;

	void Update () {
		hourshand.transform.Rotate (Vector3.back, MoveSpeed * Time.deltaTime);
	}
}






	/*
	private const float
	hoursToDegrees = 360f / 12f,
	minutesToDegrees = 360f / 60f,
	secondsToDegrees = 360f / 60f;

	public Transform hours, minutes, seconds;
	public bool analog;

	void Update () {
		if (analog) {
			TimeSpan timespan = DateTime.Now.TimeOfDay;
			hours.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalHours * -hoursToDegrees);
			minutes.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalMinutes * -minutesToDegrees);
			seconds.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalSeconds * -secondsToDegrees);
		}
		else {
			DateTime time = DateTime.Now;
			hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
			seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
		}
	}
}

*/