using UnityEngine;
using UnityEngine.UI;

public class SocialMedia : MonoBehaviour {

    public Button tel, ins;

    void Start()
    {
        PlayerPrefs.GetInt("tel", 0);
        PlayerPrefs.GetInt("ins", 0);

        if (PlayerPrefs.GetInt("tel") == 1)
        {
            tel.interactable = false;
        }
        if (PlayerPrefs.GetInt("ins") == 1)
        {
            ins.interactable = false;
        }
    }

	public void telegram()
    {
        Application.OpenURL("https://t.me/NEXTStudios");
    }
    public void Instagram ()
    {
        Application.OpenURL("https://www.instagram.com/nextstudios.ir?r=nametag");
    }
    public void Website ()
    {
        Application.OpenURL("http://nextstudios.ir");
    }

    public void HasSeen(int what)
    {
        switch (what)
        {
            case 0:
                tel.interactable = false;
                PlayerPrefs.SetInt("tel", 1);
                break;
            case 1:
                ins.interactable = false;
                PlayerPrefs.SetInt("ins", 1);
                break;
            default:
                break;
        }
    }

}
