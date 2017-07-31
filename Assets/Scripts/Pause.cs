using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	public static Pause instance;

	//public float speed;
	public Transform target;

	public Animator animator;

	bool paused = false;

	void Update () 
	{
		//transform.position = Vector3.Lerp (transform.position, target.position, speed * Time.deltaTime);
		if (paused == true)
			Debug.Log ("pause is true");
	}
		
	void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void OnPause () {
		//PausePanel.SetActive (true);
		paused = true;
		//Invoke ("pauseTime", .5f);
		//Time.timeScale = 0f;
		animator.SetBool ("Is Open", true);
		StartCoroutine("pauseTime");
		//StoreInfoPanel.transform.SetParent (TownManagerPanel.transform);
		//StoreInfoPanel.transform.SetAsLastSibling(); 
	}

	public void OnResume () {
		//PausePanel.SetActive (false);
		paused = false;
		Time.timeScale = 1.0f;
		//Invoke ("resumeTime", .5f);
		animator.SetBool ("Is Open", false);
		//StoreInfoPanel.transform.SetParent (StorePanel.transform);
	}

	//public void pauseTime (){
	//	Time.timeScale = 0f;
	//}

	IEnumerator pauseTime ()
	{
			yield return new WaitForSeconds(.4f);
			Time.timeScale = 0f;
	}

	//public void resumeTime (){
	//	Time.timeScale = 1f;
	//}

	//IEnumerator resumeTime ()
	//{
	//	yield return new WaitForSeconds(.5f);
	//	Time.timeScale = 1f;
	//}
}
