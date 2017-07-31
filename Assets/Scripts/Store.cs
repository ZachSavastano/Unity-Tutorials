using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	// public variables - define gameplay
	public float BaseStoreCost, BaseStoreProfit;
	private float NextStoreCost;
	public Text StoreCostNum, StoreProfitNum;

	public float StoreTimer;

	public float StoreMultiplier;
	public Toggle ManagerUnlocked;
	public float ManagersCut;

	public bool StoreUnlocked, StartTimer;

	public int StoreTimerDivision = 10; //to reduce the time it takes stores to make a sale after so many stores are owned

	int SalesCount = 0;
	public Text SalesCountNum;

	float SalesTotal = 0;
	public Text SalesTotalNum;

	int StoreCount = 0;
	public Text StoreCountNum;
	public Text StoreCountNumInfoPanel; //Info Panel Store Count
	//int StoreTotal = 0;

	public Slider ProgressSlider;
	//public GameManager gamemanager;

	float CurrentTimer = 0;

	public GameObject TownCanvas, StorePanel, StoreInfoPanel;

	public Button BuyButton, OnClickButton;

	void Start () {
		StoreCostNum.text = BaseStoreCost.ToString ("C");
		//StoreProfitNum.text = BaseStoreProfit.ToString ("C"); //currently controlled by void updateprofit
		NextStoreCost = BaseStoreCost;
		StoreCountNumInfoPanel = StoreCountNum;
	}

	void Update () {
		if (StartTimer) {
			CurrentTimer += Time.deltaTime;
			if (CurrentTimer > StoreTimer) {
				if (ManagerUnlocked.isOn) {
					//StoreProfitNum.text = (BaseStoreProfit * StoreCount * ManagersCut).ToString ("C");
					StartTimer = true;
					GameManager.instance.AddToBalance (BaseStoreProfit * StoreCount * ManagersCut);
					SalesTotal = SalesTotal + (BaseStoreProfit * StoreCount * ManagersCut);
				} else {
					StartTimer = false;
					GameManager.instance.AddToBalance (BaseStoreProfit * StoreCount);
					SalesTotal = SalesTotal + (BaseStoreProfit * StoreCount);
					//StoreProfitNum.text = (BaseStoreProfit * StoreCount).ToString ("C");
				}
				CurrentTimer = 0f;
				SalesCount = SalesCount + (StoreCount * 1);
				SalesCountNum.text = SalesCount.ToString();
				SalesTotalNum.text = SalesTotal.ToString ("C");
			}
		}
		ProgressSlider.value = CurrentTimer / StoreTimer;
		CheckStoreBuy ();
		UpdateProfit ();
		ManagerUnlockConditions ();
		//UIManager.instance.UpdateCurrencyFormat ();
		//Debug.Log (StoreCountNumInfoPanel);
	}

	public void CheckStoreBuy()
	{
		CanvasGroup cg = this.transform.GetComponent<CanvasGroup> (); //This section makes the stores that are not unlocked AND you can't afford not appear
		if (!StoreUnlocked && !GameManager.instance.CanBuy (NextStoreCost - 20)) {
			cg.interactable = false;
			cg.alpha = 0.3f;

		} else {
			cg.interactable = true;
			cg.alpha = 1;
			StoreUnlocked = true;
		}

		if (GameManager.instance.CanBuy (NextStoreCost)) //This section changes the buy button's color when you can/can't afford it
			BuyButton.interactable = true;
		else
			BuyButton.interactable = false;
	}

	void UpdateProfit () {
		if (ManagerUnlocked.isOn) {
			StoreProfitNum.text = (BaseStoreProfit * StoreCount * ManagersCut).ToString ("C");
		} else {
			StoreProfitNum.text = (BaseStoreProfit * StoreCount).ToString ("C");
		}
	}

	void ManagerUnlockConditions(){
		if (SalesCount >= 60 && StoreCount >= 2)
			ManagerUnlocked.interactable = true;
		else
			ManagerUnlocked.interactable = false;
	}


	public void BuyStoreOnClick () {
		if (!GameManager.instance.CanBuy(NextStoreCost))
			return;
		StoreCount = StoreCount + 1;
		//StoreTotal = StoreTotal + 1;
		//Debug.Log (StoreTotal);
		GameManager.instance.AddToStoreTotal();
		StoreCountNum.text = StoreCount.ToString();
		StoreCountNumInfoPanel.text = StoreCount.ToString (); 
		GameManager.instance.AddToBalance(-NextStoreCost);
		NextStoreCost = (BaseStoreCost * Mathf.Pow(StoreMultiplier,StoreCount));
		StoreCostNum.text = NextStoreCost.ToString ("C");
		OnClickButton.interactable = true; //Do I need this line here? I am trying to get it working down in the storeonclick method

		if (StoreCount % StoreTimerDivision == 0) //this divides the store timer in half when you buy a certain # of stores
			StoreTimer = StoreTimer / 2;
	}

	public void DetailsWindow(string choice) {
		if (choice == "open" && StoreCount > 0) {
			StoreInfoPanel.SetActive (true);
			StoreInfoPanel.transform.SetParent (TownCanvas.transform);
			//StoreInfoPanel.transform.parent = TownManagerPanel.transform; //This gives the old - "Parent of RectTransform is being set with parent property"
			StoreInfoPanel.transform.SetAsLastSibling(); 
		}
		if (choice == "x-out") {
			StoreInfoPanel.SetActive (false);
			StoreInfoPanel.transform.SetParent (StorePanel.transform);
		}
	}
		
	public void StoreOnClick() {
		if (StoreCount == 0 || StartTimer) {
			//OnClickButton.interactable = false;
			//return;
		} else {
		StartTimer = true;
		OnClickButton.interactable = true;
			if (StartTimer == true)
				Debug.Log ("Start Timer True");
			else
				Debug.Log ("Start Timer False");
		}

		/*public void StoreOnClick() {
			if (StoreCount == 0 || StartTimer) 
				return;
		StartTimer = true;
*/

		//if (!StartTimer) 
		//	StartTimer = true;
	}
}
