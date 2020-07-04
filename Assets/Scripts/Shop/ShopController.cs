using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopController : MonoBehaviour {
	public Text cointext , Dialog;
	public ScreenAndCamera screenandcam;
	bool buying , yestobuy , Dialogbool;
	public static int _prize , _item = 0 , _coin , lastItem ;
	public GameObject BuyPanel;
	public GameObject[] BuyBtn , EnableDeActiver;
	void Awake ()
	{
		
		buying = yestobuy = false;
		EnableDeActiver [PlayerPrefs.GetInt("Trail")].SetActive (true);
		

	}
	void Start () 
	{
        PlayerPrefs.SetString("TrailPlay", "Show");
        Instantiate (screenandcam.MainPlayer [PlayerPrefs.GetInt("Trail" , lastItem)]);
		_coin = PlayerPrefs.GetInt ("Coin");
        
    }
	
	// Update is called once per frame
	void Update ()
	{
		cointext.text = PlayerPrefs.GetInt ("Coin").ToString ();
		lastItem = PlayerPrefs.GetInt ("Trail");
		if (PlayerPrefs.GetString ("0") == "TrailBuaght")
		{
			BuyBtn [0].SetActive (false);

		}
		if (PlayerPrefs.GetString ("1") == "TrailBuaght")
		{
			BuyBtn [1].SetActive (false);

		}
		if (PlayerPrefs.GetString ("2") == "TrailBuaght")
		{
			BuyBtn [2].SetActive (false);

		}
		if (PlayerPrefs.GetString ("3") == "TrailBuaght")
		{
			BuyBtn [3].SetActive (false);

		}
        if (PlayerPrefs.GetString("4") == "TrailBuaght")
        {
            BuyBtn[4].SetActive(false);

        }
        _coin = PlayerPrefs.GetInt ("Coin");
		if (_coin >=_prize && buying == true && yestobuy == true)
		{
			buying = false;
			yestobuy = false;
			PlayerPrefs.SetString (_item.ToString(), "TrailBuaght");
			PlayerPrefs.SetInt ("Coin", PlayerPrefs.GetInt ("Coin") - _prize);
		}
		if (_coin < _prize && Dialogbool == true && buying == true) {
			BuyPanel.SetActive (false);
			Dialog.text = "you don't have enough money";
			StartCoroutine (NoMoney ());
			Dialogbool = false;
			buying = false;
			yestobuy = false;
			_item = lastItem;
		}
        if (PlayerPrefs.GetString("TrailPlay") == "Hide")
        {
            GameObject.FindGameObjectWithTag("Player").transform.localScale = new Vector3(0, 0, 0);
        }
        if (PlayerPrefs.GetString("TrailPlay") == "Show")
        {
            GameObject.FindGameObjectWithTag("Player").transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
	public void Buy (int item)
	{
		Dialogbool = true;
		buying = true;
		_item = item;
        if (_coin >= _prize)
        {
            BuyPanel.SetActive(true);
        }
	}
	public void SetPrize(int prize)
	{
		_prize = prize;
	}
	public void enable (int item)
	{
		_item = item;
		PlayerPrefs.SetInt ("Trail", _item);
		Destroy(GameObject.FindGameObjectWithTag("Player"));
		Instantiate (screenandcam.MainPlayer [_item]);
		Dialog.text = "enabled!";
		StartCoroutine (NoMoney ());
	}
	public void YesToBuy()
	{
		yestobuy = true;
		BuyPanel.SetActive (false);
		Dialog.text = "you buy it!";
		StartCoroutine (NoMoney ());
	}
    public void HidePlayer()
    {
        PlayerPrefs.SetString("TrailPlay", "Hide");
    }
    public void ShowPlayer()
    {
        PlayerPrefs.SetString("TrailPlay", "Show");
    }


    IEnumerator NoMoney()
	{
		yield return new WaitForSeconds (0.5f);
		Dialog.text = "";

	}
}
