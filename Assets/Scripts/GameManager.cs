using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	public class GameManager : MonoBehaviour {

	public delegate void UpdateBalance(); 
	public static event UpdateBalance OnUpdateBalance;

	public static GameManager instance;

	float CurrentBalance;
	//public Text CurrentBalanceText;

	public int StoreTotal;

	//float Daylength = 15.0f;

	float DaysNum = 1;
	public Text DaysNumText;

	void Start () {
		CurrentBalance = 110f;
		InvokeRepeating ("Calendar", 15, 15);
		if (OnUpdateBalance != null)
			OnUpdateBalance ();
	}

	void Update () 
	{
	}

	void Awake()
	{
		if (instance == null)
			instance = this;
	}
		
	public void AddToStoreTotal()
	{
		StoreTotal = StoreTotal + 1;
		Debug.Log ("Store Total equals: " + StoreTotal);
	}

	void Calendar()
	{
		DaysNum = DaysNum + 1;
		DaysNumText.text = DaysNum.ToString();
		//CurrentBalance = (CurrentBalance - 10 * StoreTotal);
		AddToBalance (-10 * StoreTotal);
	}

	public void AddToBalance(float amt) //AddToBalance should eventually be renamed ModifyBalance after Tycoon tuts are done
	{
		CurrentBalance += amt;
		if (OnUpdateBalance != null)
			OnUpdateBalance ();
		//UIManager.instance.UpdateUI ();
	}

	public bool CanBuy(float AmtToSpend)
	{
		return AmtToSpend <= CurrentBalance;
			
		//if (AmtToSpend > CurrentBalance)
		//	return false;
		//else
		//	return true;
	}

	public float GetCurrentBalance()
	{
		return CurrentBalance;
	}
		
	public void PauseWindow(string choice) {
		if (choice == "pause") {
			Pause.instance.OnPause ();
		}
		if (choice == "x-out") {
			Pause.instance.OnResume ();
		}
	}
}