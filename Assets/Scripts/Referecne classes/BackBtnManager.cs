using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBtnManager : MonoBehaviour {
    public Animator MainUI, Home;
    public GameObject TrailPre , HighScore , Lastscore;
	public UIHandler UIHandler;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& MainUI.GetCurrentAnimatorStateInfo(0).IsName("Idel Animation"))
        {
            MainUI.SetTrigger("ExitPanelActive");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && MainUI.GetCurrentAnimatorStateInfo(0).IsName("ExitPanelActive Animation"))
        {
            MainUI.SetTrigger("BackToMenu");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && 
            (MainUI.GetCurrentAnimatorStateInfo(0).IsName("LevelSelectionIsActive Animation")||
            MainUI.GetCurrentAnimatorStateInfo(0).IsName("TrialActive Animation") ||
            MainUI.GetCurrentAnimatorStateInfo(0).IsName("BoostActive Animation") ||
			MainUI.GetCurrentAnimatorStateInfo(0).IsName("SettingIsActive Animation") ||
            MainUI.GetCurrentAnimatorStateInfo(0).IsName("CoinActive Animation")||
			MainUI.GetCurrentAnimatorStateInfo(0).IsName("CoinActive Animation")||
			MainUI.GetCurrentAnimatorStateInfo(0).IsName("GiftActive Animation")))
        {
            MainUI.SetTrigger("BackToMenu");
            Home.SetTrigger("DeActive");
            TrailPre.SetActive(false);
            PlayerPrefs.SetString("TrailPlay", "Show");
			HighScore.SetActive (true);
			Lastscore.SetActive (true);
			UIHandler.OpenGameObject(Lastscore);
        }
        if (Input.GetKeyDown(KeyCode.Escape) &&
            (MainUI.GetCurrentAnimatorStateInfo(0).IsName("AudioPanelActive Animation")||
            MainUI.GetCurrentAnimatorStateInfo(0).IsName("CreditPanelActive Animation")))
        {
            MainUI.SetTrigger("BackToMenu");
            Home.SetTrigger("Active");
        }
       
    }
}
