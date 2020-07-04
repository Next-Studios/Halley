using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
public class LeaderBoard : MonoBehaviour {

    private Dictionary<string, Dictionary<string, int>> userInf;
    private int changeCounter = 0;

    public GameObject Loading;
    public RectTransform r;
    public Text HighScoreText;

    public void StartFinding () {
        r.sizeDelta = new Vector2(r.sizeDelta.y, 0);
        new GameSparks.Api.Requests.LeaderboardDataRequest().SetLeaderboardShortCode("HIGH_SCORE").SetEntryCount(100).Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Found Leaderboard Data...");
                Loading.SetActive(false);
                foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data)
                {
                    int rank = (int)entry.Rank;
                    string playerName = entry.UserName;
                    string score = entry.JSONData["SCORER"].ToString();
                    if (playerName != "fsdfsd")
                    {
                        rank--;
                        if (playerName != "JD")
                        {
                            if (int.Parse(score) <= 11) rank++;

                            SetScore(playerName, "Score", int.Parse(score));
                            SetScore(playerName, "Rank", rank);
                        }
                    }
                    if (PlayerPrefs.GetString("Username") == playerName)
                    {
                        PlayerPrefs.SetString("Rank", rank.ToString());
                        PlayerPrefs.SetInt("HighScore", int.Parse(score));
                        HighScoreText.text = PlayerPrefs.GetString("HighScore");
                    }
                    if (rank >= 100)
                    {
                        return;
                    }
                } 
            }
            else
            {
                Debug.Log("Error Retrieving Leaderboard Data...");
            }
        });
    }

    private void init()
    {
        if (userInf != null) return;
        userInf = new Dictionary<string, Dictionary<string, int>>();
    }

    public int GetScore(string username, string scoreType)
    {
        init();

        if (!userInf.ContainsKey(username))
        {
            return 0;
        }
        if (!userInf[username].ContainsKey(scoreType))
        {
            return 0;
        }

        return userInf[username][scoreType];
    }

    public void SetScore(string username, string scoreType, int amount)
    {
        init();

        changeCounter++;

        if (!userInf.ContainsKey(username))
        {
            userInf[username] = new Dictionary<string, int>();
        }

        userInf[username][scoreType] = amount;
    }

    public void ChangeScore(string username, string scoreType, int amount)
    {
        init();

        int currentScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currentScore + amount);
    }

    public string[] GetUsernames()
    {
        init();

        return userInf.Keys.ToArray();
    }

    public int GetChangeCounter()
    {
        return changeCounter;
    }
}
