using UnityEngine;
using TapsellSDK;
using UnityEngine.UI;

public class Advertising : MonoBehaviour
{
    //Enums
    public enum Status { OnAdAvailable, NoAdAvailable, Error, NoNetwork, Expiring, Nothing, Shown}
    private enum MobileRotation { LockedPortrait, LockedLandscape, Unlocked, ReversedPortrait, ReversedLandscape}
    private enum AchievementMode { ResumeGame, AddCoin}

    #region Variables

    //On Inspector
    [SerializeField]
    private string tapsellKey, zoneID;
    [SerializeField]
    private bool cashed, debugMode, EnableBack, ImmersiveMode;
    [SerializeField]
    private MobileRotation Rotation;
    [SerializeField]
    private AchievementMode Achieve;
    [SerializeField]
    private GameObject  SurvivePanel;
    [SerializeField]
    private Animator loading;
    [SerializeField]
    private Text CoinText;
    //Private Variables
    private TapsellAd adID = null;
    private bool created = false;

    //Public Static Variables
    public static Status State;

    #endregion

    #region Getters and Setters

    /// <summary>
    /// Get and Set the Value of the Cash Mode of your Ad.
    /// </summary>
    public bool Cashed
    {
        get { return this.cashed; }
        set { this.cashed = value; }
    }

    /// <summary>
    /// Get and Set the value of the Tapsell Key.
    /// </summary>
    public string TapsellKey
    {
        get { return this.tapsellKey; }
        set { this.tapsellKey = value; }
    }

    /// <summary>
    /// Get the ID of your Ad.
    /// </summary>
    public TapsellAd ID
    {
        get { return this.adID; }
    }

    /// <summary>
    /// Get and Set the Value of the Debug Mode of your Ad.
    /// </summary>
    public bool DebugMode
    {
        get { return this.debugMode; }
        set { this.debugMode = value; }
    }

    #endregion

    #region Functions

    void Start()
    {        
        State = Status.Nothing;

        Tapsell.Initialize(tapsellKey);
        Tapsell.SetDebugMode(debugMode);
        
        Tapsell.SetRewardListener((TapsellAdFinishedResult result) =>
            {
                if (result.completed && result.rewarded)
                {
                    State = Status.Shown;
                    SurvivePanel.GetComponent<SurviveScript>().Resume();
                }
            }
        );

        RequestAd();
    }

    /// <summary>
    /// Requests an Ad from Tapsell Website.
    /// </summary>
    public void RequestAd()
    {
        Tapsell.RequestAd(this.zoneID, this.cashed,
            (TapsellAd result) =>
            {
                // onAdAvailable

                adID = result;
                State = Status.OnAdAvailable;
            },
            (string zone) =>
            {
                // onNoAdAvailable

                State = Status.NoAdAvailable;
            },
            (TapsellError error) =>
            {
                // onError
                Debug.Log(error.message);
                State = Status.Error;
            },
            (string zone) =>
            {
                // onNoNetwork

                State = Status.NoNetwork;
            },
            (TapsellAd result) =>
            {
                // onExpiring
                
                adID = null;
                State = Status.Expiring;
                RequestAd();
            }
        );
    }

    /// <summary>
    /// Shows your Requested Ad.
    /// </summary>
    public void ShowAd()
    {
		
        if(Achieve == AchievementMode.ResumeGame) loading.SetTrigger("Load");
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
    #endregion
}
