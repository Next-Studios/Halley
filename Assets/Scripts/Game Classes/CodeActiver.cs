using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeActiver : MonoBehaviour {
	public Player PlayerCode;
	bool ok = true;
	// Use this for initialization
	void Start () 
	{
		ok = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerPrefs.GetString("Watched")== "Yes" && ok == true)
		{
			PlayerCode.enabled = true;
			ok = false;
		}	
	}
}
