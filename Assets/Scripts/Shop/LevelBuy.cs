using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelBuy : MonoBehaviour {
	public Text cointext , Dialog;
	bool buying , yestobuy , Dialogbool;
	public static int _prize , _item = 0 , _coin;
	public GameObject BuyPanel;
	public GameObject[] BuyBtn , BuyDeActiver;
	void Awake ()
	{
		buying = yestobuy = false;

	}
	void Start () 
	{

		_coin = PlayerPrefs.GetInt ("Coin");
	}

	// Update is called once per frame
	void Update ()
	{
		if (PlayerPrefs.GetString ("0") == "LevelBuaght")
		{
			BuyBtn [0].SetActive (false);
			BuyDeActiver [0].SetActive (false);
		}
		if (PlayerPrefs.GetString ("1") == "LevelBuaght")
		{
			BuyBtn [1].SetActive (false);
			BuyDeActiver [1].SetActive (false);
		}
		if (PlayerPrefs.GetString ("2") == "LevelBuaght")
		{
			BuyBtn [2].SetActive (false);
			BuyDeActiver [2].SetActive (false);
		}
		if (PlayerPrefs.GetString ("3") == "LevelBuaght")
		{
			BuyBtn [3].SetActive (false);
			BuyDeActiver [3].SetActive (false);
		}
		_coin = PlayerPrefs.GetInt ("Coin");
		if (_coin>=_prize && buying == true && yestobuy == true)
		{
			buying = false;
			yestobuy = false;
			PlayerPrefs.SetString (_item.ToString(), "LevelBuaght");
			PlayerPrefs.SetInt ("Coin", PlayerPrefs.GetInt ("Coin") - _prize);
		}
		else if (_coin < _prize && Dialogbool == true && buying == true) {
			BuyPanel.SetActive (false);
			Dialog.text = "you don't have enough money";
			StartCoroutine (NoMoney ());
			Dialogbool = false;
			buying = false;
			yestobuy = false;
		}
	}
	public void Buy (int item)
	{
		Dialogbool = true;
		buying = true;
		BuyPanel.SetActive (true);
		_item = item;
	}
	public void SetPrize(int prize)
	{
		_prize = prize;
	}

	public void YesToBuy()
	{
		yestobuy = true;
		BuyPanel.SetActive (false);
		Dialog.text = "you buy it!";
		StartCoroutine (NoMoney ());
	}

	IEnumerator NoMoney()
	{
		yield return new WaitForSeconds (0.5f);
		Dialog.text = "";

	}
}
