using UnityEngine;
using TapsellSDK;
using UnityEngine.UI;

public class AD : MonoBehaviour {
	public int coin;
    private enum MobileRotation { LockedPortrait, LockedLandscape, Unlocked, ReversedPortrait, ReversedLandscape }

    //On Inspector
    [SerializeField]
    private string zoneID;
    [SerializeField]
    private bool cashed, EnableBack, ImmersiveMode;
    [SerializeField]
    private MobileRotation Rotation;
    [SerializeField]
    private Text CoinText;

    //Private Variables
    private TapsellAd adID = null;
    private bool created = false;

    void Start () {

        Tapsell.SetRewardListener((TapsellAdFinishedResult result) =>
        {
            if (result.completed && result.rewarded)
            {
                AchiveThat(coin);
            }
        }
        );

        RequestAd();
    }

    public void RequestAd()
    {
        Tapsell.RequestAd(this.zoneID, this.cashed,
            (TapsellAd result) =>
            {
                // onAdAvailable

                adID = result;
            },
            (string zone) =>
            {
                // onNoAdAvailable
            },
            (TapsellError error) =>
            {
                // onError
                Debug.Log(error.message);
            },
            (string zone) =>
            {
                // onNoNetwork
            },
            (TapsellAd result) =>
            {
                // onExpiring

                adID = null;
                RequestAd();
            }
        );
    }

    public void ShowAd()
    {
        if (adID != null)
        {
            TapsellShowOptions options = new TapsellShowOptions();
            options.backDisabled = this.EnableBack;
            options.immersiveMode = this.ImmersiveMode;
            options.showDialog = true;
            options.rotationMode = TapsellShowOptions.ROTATION_UNLOCKED;
            Tapsell.ShowAd(adID, options);
        }
        else
        {
            RequestAd();
        }
    }

    public void AchiveThat(int value) {
        Player.Coin += value;
        PlayerPrefs.SetInt("Coin", Player.Coin);
        CoinText.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}
