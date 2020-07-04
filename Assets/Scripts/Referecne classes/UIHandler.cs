using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIHandler : MonoBehaviour
{

    public enum CurruntPanel { Pause, Survive, Start };

    #region Variables
    public static CurruntPanel status;
    public static int Quality;
    public static string Music = "Unmute";
    public GameObject SurvivePanel, hold, CoinPlusobj;
    public Text CoinPlus;
    public Text CoinText;
    public AudioMixer AudioMixer;


    #endregion
    private void Start()
    {

        AudioMixer.SetFloat("LowPass", 0);
        CoinText.text = PlayerPrefs.GetInt("Coin", 0).ToString();
    }
    public void Update()
    {
        CoinPlus.text = "+ " + PlayerPrefs.GetInt("coinplus").ToString();
    }

    public static void EndGameUI(GameObject SelfPlayer, GameObject block, GameObject SurvivePanel)
    {
        status = CurruntPanel.Survive;

        Time.timeScale = 0;

        block.SetActive(false);
        SelfPlayer.SetActive(false);
        SurvivePanel.transform.localScale = new Vector3(1, 1, 1);
    }

    public static void ShowPauseMenu()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    public static bool StartGame(GameObject HoldPanel)
    {

        HoldPanel.SetActive(false);

        if (HoldPanel.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Exit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
    public static void ContinueWithAd(GameObject Play, GameObject SurvivePanel)
    {
        Player.State = Player.GameStatus.Continue;
        Destroy(Player.TheCollisionedBlock);
        SurvivePanel.transform.localScale = new Vector3(0, 0, 0);
    }
    public static void ShowSurvivePanel(GameObject SurvivePanel)
    {
        if (PlayerPrefs.GetString("Connect") == "Fail")
        {
            SurvivePanel.transform.localScale = new Vector3(1, 0, 0);
        }
        else
        {
            status = CurruntPanel.Survive;
            SurvivePanel.transform.localScale = new Vector3(1, 1, 1);
            SurvivePanel.GetComponentInChildren<ProgressOficial>().Speed = 40;
        }


    }
    public void Play()
    {
        AudioMixer.SetFloat("LowPass", -80);
        hold.transform.localScale = new Vector3(1, 1, 1);
        CoinPlusobj.transform.localScale = new Vector3(1, 1, 1);
    }
	public void closeGameObject(GameObject Close)
	{
		Close.transform.localScale = new Vector3(0, 0 ,0 );
	}
	public void OpenGameObject(GameObject Close)
	{
		Close.transform.localScale = new Vector3(1, 1 ,1 );
	}

}
