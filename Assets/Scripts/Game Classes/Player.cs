using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

using System.Collections;

public class Player : MonoBehaviour
{

    public enum GameStatus { Start, Go, Stop, Continue };

    #region Variables
    //statics
    public static GameStatus State;
    public static int Coin = 0, _coin = 0, HighScore = 0, score = 0, rnd = 0, MultipleCoinAmount = 1;
    public static GameObject TheCollisionedBlock = null;

    //publics
    public WhatLevel levelManage;
    public Animator PlayerAnim;
    public ScreenAndCamera ScreenAndCam;
    public ParticleSystem Particle;
    public GameObject HoldPanel, Block, Gift, UIhandle;
    public Blur CameraBlur;
    public float BlockDistance;
    public Text CoinText, ScoreText, _HighScore, LastScoreText;
    public AudioSource music, GiftMusic;
    private Vector3[] Points = new Vector3[2];
    public UIManager UIManager;
    public GameController GameController;
    public Player PlayerCode;
    [Range(0, 0.5f)]
    public float BlockDistancePlus;

    //private
    private int startGift, CoinPlus = 0;
    private BlockPlatformer Blocks;
    private Gift _gift;
    public static bool MovableBlock = false;
    private GiftActs giftActs;
    private GameObject[] blooooooooock = new GameObject[2] { null, null };
    private int activeBlooooooook = 0;
    private ParticleSystem part;
    private GameObject survivePanel, hold, progressBar;
    private bool play, hitblock;
    private WaitForSeconds wait = new WaitForSeconds(0.5f);


    //constants
    private const float SCREEN_LEFT = -1.58f, SCREEN_RIGHT = 1.53f;
    #endregion
    private void Awake()
    {
        hitblock = false;
        play = false;
        Block = GameController.Block[PlayerPrefs.GetInt("Level")];
    }
    void Start()
    {
        progressBar = GameObject.Find("RadialProgressBar");
        CoinPlus = 0;
        hold = GameObject.Find("HoldPanel");
        survivePanel = GameObject.Find("Survive Panel");
        survivePanel.GetComponentInChildren<ProgressOficial>().Speed = 0;
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        PlayerPrefs.SetInt("coinplus", 0);
        this.Points = new Vector3[2] { GameObject.Find("lu").transform.position, GameObject.Find("rd").transform.position };
        ScreenAndCam = GameObject.Find("Main Camera").GetComponent<ScreenAndCamera>();

        Time.timeScale = 1;

        MultipleCoinAmount = 1;
        _coin = 0;
        score = 0;
        ScoreText.text = "0";
        startGift = Random.Range(5, 11);
        LastScoreText = GameObject.Find("Last Score Text").GetComponent<Text>();
		LastScoreText.text = (PlayerPrefs.GetInt("LastScore", 0)).ToString();

        State = GameStatus.Start;

        HighScore = PlayerPrefs.GetInt("HighScore", HighScore);
        Coin = PlayerPrefs.GetInt("Coin", Coin);

        CoinText = GameObject.Find("Coin Text").GetComponent<Text>();
        CoinText.text = Coin.ToString();

        giftActs = new GiftActs(gameObject, progressBar, blooooooooock, GiftMusic);
        Blocks = new BlockPlatformer(Block, BlockDistance);
        //_gift = new Gift(this.Gift, this.Points, this.progressBar);

        new GameSparks.Api.Requests.LogEventRequest().SetEventKey("LEADERBOARD_SCORER").SetEventAttribute("SCORER", int.Parse(PlayerPrefs.GetInt("HighScore", 0).ToString())).Send((response) => {
            if (!response.HasErrors)
            {
                Debug.Log("Score Posted Successfully...");
            }
            else
            {
                Debug.Log("Error Posting Score...");
            }
        });
    }

    void Update()
    {
        this.Points = new Vector3[2] { GameObject.Find("lu").transform.position, GameObject.Find("rd").transform.position };
        //_gift.Points = this.Points;

        #region Touch & Go
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && (State == GameStatus.Start || State == GameStatus.Continue) && play == true)
        {
            GetComponent<ParticleSystem>().Play();
            Blocks.FirstBlockCreator(SCREEN_LEFT, SCREEN_RIGHT, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y);
        }
        else if (Input.GetMouseButtonDown(0) && (State == GameStatus.Start || State == GameStatus.Continue) && play == true)
        {
            GetComponent<ParticleSystem>().Play();
            Blocks.FirstBlockCreator(SCREEN_LEFT, SCREEN_RIGHT, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }

        if ((Input.touchCount > 0 && Input.touchCount < 2 && play == true)
            || (Input.GetMouseButton(0)) && State != GameStatus.Stop && play == true)
        {
            UIHandler.StartGame(HoldPanel);
            PlayerAnim.enabled = false;
            Particle.Play();
            hold.transform.localScale = new Vector3(0, 0, 0);
            State = GameStatus.Go;

            Plane plane = new Plane(-Camera.main.transform.forward, this.transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float ray_distance;
            if (plane.Raycast(ray, out ray_distance))
            {
                this.transform.position = ray.GetPoint(ray_distance);
            }
        }
        else if (State != GameStatus.Start && State != GameStatus.Continue)
        {
            EndGo();
            play = false;
        }
        #endregion

        //#region Gift
        //if (startGift == score)
        //{
        //    if (giftActs.getCurrentAction() == GiftActs.CurrentAction.Nothing)
        //    {
        //        _gift.CreateGift();
        //    }
        //    startGift += Random.Range(5, 9);
        //}
        //if (progressBar.GetComponent<ProgressBar>().IsDone)
        //{
        //    switch (giftActs.getCurrentAction())
        //    {
        //        case GiftActs.CurrentAction.DoubleCoiner:
        //            giftActs.UpdateBlock(blooooooooock);
        //            giftActs.EndDoubleCoiner();
        //            break;
        //        case GiftActs.CurrentAction.InfiniteDash:
        //            giftActs.UpdateBlock(blooooooooock);
        //            //Invoke("HaloOff", 2.4f);
        //            giftActs.EndInfiniteDash(ScreenAndCam);
        //            break;
        //    }
        //}
        //#endregion
        if (UIManager.isplay == true)
        {
            PlayerAnim.SetTrigger("StartPlay");
            play = true;

        }
    }

    //Collisions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            TheCollisionedBlock = other.gameObject;
            hitblock = true;
            EndGo();
        }

        if (other.gameObject.tag == "Gift")
        {
            giftActs.UpdateBlock(blooooooooock);
            other.gameObject.GetComponent<AudioSource>().Play();
            switch (Random.Range(1, 3))
            {
                case 2:print("FF"); giftActs.DoubleCoiner(); break;
                case 1: giftActs.InfiniteDash(GiftActs.DashVelocity.High, ScreenAndCam); break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            score++;
            ScoreText.text = score.ToString();

            if (score % 2 == 0)
            {
                CoinPlus += MultipleCoinAmount;
                PlayerPrefs.SetInt("coinplus", CoinPlus);
            }

            if (activeBlooooooook == 0)
            {
                blooooooooock[0] = Blocks.BlockCreator(SCREEN_LEFT, SCREEN_RIGHT, BlockDistancePlus, true);
                activeBlooooooook++;
            }
            else
            {
                blooooooooock[1] = Blocks.BlockCreator(SCREEN_LEFT, SCREEN_RIGHT, BlockDistancePlus, true);
                activeBlooooooook--;
            }
            giftActs.UpdateBlock(blooooooooock);

            other.enabled = false;

            if (score > HighScore)
            {
                HighScore = score;
                PlayerPrefs.SetInt("HighScore", HighScore);
            }
        }
    }

    private void EndGo()
    {
        new GameSparks.Api.Requests.LogEventRequest().SetEventKey("LEADERBOARD_SCORER").SetEventAttribute("SCORER", score).Send((response) => {
            if (!response.HasErrors)
            {
                Debug.Log("Score Posted Successfully...");
            }
            else
            {
                Debug.Log("Error Posting Score...");
            }
        });

        State = GameStatus.Stop;
        PlayerPrefs.SetInt("LastScore", int.Parse(ScoreText.text));
        progressBar.SetActive(false);
        Coin += PlayerPrefs.GetInt("coinplus");
        PlayerPrefs.SetInt("Coin", Coin);
        if (SurviveScript.IsWatched == true || hitblock == false)
        {
            UIHandler.ShowPauseMenu();
        }
        else
        {
            UIHandler.ShowSurvivePanel(survivePanel);
        }

        PlayerCode.enabled = false;
    }

    public void HaloOff()
    {
        GetComponent<Animation>().Play();
    }
}