using UnityEngine.UI;
using UnityEngine;

public class LeaderboardElementManger : MonoBehaviour {

    public GameObject UserElementPrefab;
    public LeaderBoard LeadManager;

    private int lastChangeCounter = 0;

	void Start () {
        lastChangeCounter = LeadManager.GetChangeCounter();
	}

    void Update()
    {
        if (LeadManager.GetChangeCounter() == lastChangeCounter)
        {
            return;
        }
        lastChangeCounter = LeadManager.GetChangeCounter();

        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.transform.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] usernames = LeadManager.GetUsernames(); 

        foreach (string item in usernames)
        {
            GameObject go = (GameObject)Instantiate(UserElementPrefab);
            go.transform.SetParent(this.transform, false);
            go.transform.Find("Username").gameObject.GetComponent<Text>().text = item;
            go.transform.Find("Rank").gameObject.GetComponent<Text>().text = LeadManager.GetScore(item, "Rank").ToString();
            go.transform.Find("Score").gameObject.GetComponent<Text>().text = LeadManager.GetScore(item, "Score").ToString();

            RectTransform r = GetComponent<RectTransform>();
            print(r.sizeDelta.y);
            r.sizeDelta = new Vector2(r.sizeDelta.x, r.sizeDelta.y + go.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}
