using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	//public static UIManager instance;
	public Text CurrentBalanceText;


	string curCulture = System.Threading.Thread.CurrentThread.CurrentCulture.ToString(); //sets the currency format

	void Start () {
	}

	void Update () {
	}

	void OnEnable()
	{
		GameManager.OnUpdateBalance += UpdateUI;
	}

	void OnDisable()
	{
		GameManager.OnUpdateBalance -= UpdateUI;
	}

	/*void Awake()
	{
		if (instance == null)
			instance = this;
	}*/


	public void UpdateUI()
	{
		CurrentBalanceText.text = GameManager.instance.GetCurrentBalance().ToString ("C");
		UpdateCurrencyFormat ();
	}

	public void UpdateCurrencyFormat()
	{
		System.Globalization.NumberFormatInfo currencyFormat = new System.Globalization.CultureInfo(curCulture).NumberFormat;
		currencyFormat.CurrencyNegativePattern = 1;
		CurrentBalanceText.text = GameManager.instance.GetCurrentBalance().ToString ("C", currencyFormat);
		if (GameManager.instance.GetCurrentBalance() < 0)
			CurrentBalanceText.color = Color.red;
		else
			CurrentBalanceText.color = new Color (0.10f, 0.38f, 0);

	}
}
