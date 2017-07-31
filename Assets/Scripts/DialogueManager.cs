using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public GameObject Stores;

	//public string[] sentences;
	private Queue<string> sentences;

	private Queue<string> altSentences;//Z

	public Animator animator;

	void Start () 
	{
		sentences = new Queue<string> ();

		altSentences = new Queue<string> ();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		
		Stores.SetActive (false);
		//Time.timeScale = 0f;

		animator.SetBool ("Is Open", true);

		//Debug.Log ("Starting conversation with " + dialogue.name);

		nameText.text = dialogue.name;

		sentences.Clear ();

		//altSentences.Clear ();//Z

		foreach (string sentence in dialogue.sentences) 
		{
			sentences.Enqueue (sentence);
		}

		foreach (string altSentence in dialogue.altSentences)
		{
			altSentences.Enqueue (altSentence);
		}

		DisplayNextSentence ();

		//DisplayNextAltSentence (); //Z

	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0) 
		{
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		//dialogueText.text = sentence;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		//Debug.Log (sentence);
	}

	public void DisplayNextAltSentence () //Z
	{
		if (altSentences.Count == 0) 
		{
			EndDialogue ();
			return;
		}

		string altSentence = altSentences.Dequeue ();
		dialogueText.text = altSentence;
		//StopAllCoroutines();
		//StartCoroutine(TypeSentence(altSentence));
		//Debug.Log (sentence);
	} 

	IEnumerator TypeSentence (string sentence) //this types out the letters
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			//yield return null;
			yield return new WaitForSeconds (.05f);
		}
	}

	void EndDialogue()
	{
		//Time.timeScale = 1f;
		animator.SetBool ("Is Open", false);
		Stores.SetActive (true);
	}



}
