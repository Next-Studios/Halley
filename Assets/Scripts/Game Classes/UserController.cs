using UnityEngine;
using GameSparks.Core;
using GameSparks.Api.Requests;
using UnityEngine.UI;

public class UserController : MonoBehaviour {

    public Animator anim,Hanim;
    public GameObject Login, Profile;
    public Text User, Rank, High;

    private bool isSigned, isFirst = false;

    void Start()
    {
        Rank.text = PlayerPrefs.GetString("Rank", "Has not set yet!");
        User.text = PlayerPrefs.GetString("Username", User.text);
        new LogEventRequest().SetEventKey("LOAD_USER").Send((response) => {
            if (!response.HasErrors)
            {
                GSData data = response.ScriptData.GetGSData("player_Data");
                User.text = data.GetString("username");
                PlayerPrefs.SetString("Username", User.text);
            }
            else
            {
                print(response.Errors.JSON);
            }
        });
        High.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        if (!isFirst)
        {
            isSigned = GS.Authenticated || GS.GSPlatform.UserId != "";
            isFirst = true;
        }
    }

    public void CheckSign(string panel)
    {
        if (isSigned)
        {
            if (panel == "Login") {
                anim.SetTrigger("LeaderbordActive");
            }
            else if (panel == "Profile")
            {
                Rank.text = PlayerPrefs.GetString("Rank", "Has not set yet!");
                anim.SetTrigger("LoginActive");
                Profile.SetActive(true);
                Login.SetActive(false);
            }
        }
        else
        {
            anim.SetTrigger("LoginActive");
            if (panel == "Login")
            {
                Login.SetActive(true);
                Profile.SetActive(false);
            }
            else if (panel == "Profile")
            {
                Rank.text = PlayerPrefs.GetString("Rank", "Has not set yet!");
                Profile.SetActive(false);
                Login.SetActive(true);
            }
        }
        Hanim.SetTrigger("Active");
    }
}
