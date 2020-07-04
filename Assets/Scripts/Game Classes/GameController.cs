using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public GameObject[] Block, Particle ,LevelBTN,Textures;
    public AudioSource[] SFX;
    public ScreenAndCamera screenandcamera;
    public static  bool checker;
    public static int levelnum ;
    public GameObject camera;
    public Text highscore;
    GameObject particleingame;
    GameObject Rendereringame;
    public Image[] UI;
    public Color[] Color;
    public Text[] Text;
    private void Awake()
    {
        
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("Level")==2)
        {
			UI[0].color = UI[1].color = UI[2].color = UI[3].color = UI[4].color = UI[5].color = UI[6].color = UI[7].color = UI[8].color = Text[0].color = Text[1].color = Text[2].color = Text[3].color = Text[4].color = Color[1]= Text[5].color = Color[1]= Text[6].color = Color[1];
        }
        else
        {
			UI[0].color = UI[1].color = UI[2].color = UI[3].color = UI[4].color = UI[5].color = UI[6].color = UI[7].color = UI[8].color = Text[0].color = Text[1].color = Text[2].color = Text[3].color = Text[4].color = Color[0]= Text[5].color = Color[0]= Text[6].color = Color[0];
        }
        
        highscore.text =highscore.text + " " + Player.HighScore.ToString();
        LevelBTN[PlayerPrefs.GetInt("Level")].SetActive(true);
        Instantiate(Textures[PlayerPrefs.GetInt("Level")]);
        Rendereringame = GameObject.FindGameObjectWithTag("Texture");
        screenandcamera.texture = Rendereringame.GetComponent<Renderer>();
        Instantiate(Block[PlayerPrefs.GetInt("Level")]);
        Instantiate(Particle[PlayerPrefs.GetInt("Level")]);
        particleingame = GameObject.FindGameObjectWithTag("Particle");
        particleingame.transform.parent = camera.transform;
        Rendereringame.transform.parent = camera.transform;
        SFX[PlayerPrefs.GetInt("Level")].Play();
        
        MakeTrueLevel();
    }
    // Update is called once per frame
    void Update ()
    {
        
        particleingame.GetComponent<ParticleSystem>().Play();
        
    }
    public void SetLevel(int level = 0)
    {
        
        levelnum = level;
        PlayerPrefs.SetInt("Level", levelnum);
        checker = true;
        SceneManager.LoadScene(0);
    }
   private void MakeTrueLevel()
    {
        
       
        
    }
    


}
