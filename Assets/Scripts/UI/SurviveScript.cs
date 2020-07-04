using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class SurviveScript : MonoBehaviour {

    public GameObject  ProgressSurvive , LoadingPanel;
    GameObject Play;
    public Text Score, FinalScore, HighScore;
    public static bool IsWatched = false;
    private bool isFirst = true;

    void Awake()
    {
        IsWatched = false;
        Play = GameObject.FindWithTag("Player");
        isFirst = true;
		PlayerPrefs.SetString ("Watched", "No");

    }

    void Update()
    {
		HighScore.text ="High Score : " + PlayerPrefs.GetInt ("HighScore").ToString ();
        if (!isFirst && gameObject.transform.localScale.x == 1)
        {
            switch (Advertising.State)
            {
			case Advertising.Status.NoAdAvailable:
			case Advertising.Status.Error:
			case Advertising.Status.NoNetwork:
			case Advertising.Status.Expiring:
				UIHandler.ShowPauseMenu ();
				gameObject.transform.localScale = new Vector3 (0, 0, 0);
				Time.timeScale = 1;
				IsWatched = true;
                    break;
            }
        }
        isFirst = false;
        if ((Input.GetKeyDown(KeyCode.Escape) || ProgressSurvive.GetComponent<ProgressOficial>().Done) && gameObject.transform.localScale.x == 1)
        {
            UIHandler.ShowPauseMenu();
			gameObject.transform.localScale = new Vector3(0, 0, 0);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        gameObject.GetComponentInChildren<ProgressOficial>().Speed = 0;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        Time.timeScale = 1;
        ProgressSurvive.GetComponent<ProgressOficial>().Renew();
        IsWatched = true;
		PlayerPrefs.SetString ("Watched", "Yes");
		LoadingPanel.SetActive (false);
        UIHandler.ContinueWithAd(Play, gameObject); 
    }

}
