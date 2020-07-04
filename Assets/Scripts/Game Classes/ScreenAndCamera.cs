using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenAndCamera : MonoBehaviour
{

    [Range(0, 30)]
    public float StartSpeed, Acceleration;
    [Range(0, 2)]
    public float TextureSpeed;
    public Renderer texture;
    public GameObject[] MainPlayer = new GameObject[2];
    public AD ad;
    private Vector2 offset;
    public float LastSpeed = 0f;
    private Rigidbody2D rigid;
    private float timer, startTime;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ChangeState(0);
    }

    void Update()
    {
        //Block Move
        switch (Player.State)
        {
            case Player.GameStatus.Go:
                offset = new Vector2(0, TextureSpeed * Time.time);
                timer = Time.time - startTime;
                //rigid.velocity = new Vector2(0, Acceleration * Mathf.Log10(Time.time) + StartForce);
                rigid.velocity = new Vector2(0, Acceleration * Mathf.Pow(timer, 0.5f) + StartSpeed);
                texture.material.mainTextureOffset = offset;
                break;
            case Player.GameStatus.Stop:
                rigid.velocity = new Vector2(0, 0);
                break;
            case Player.GameStatus.Start:
                startTime = Time.time;
                timer = 0;
                break;
        }
    }

    //Change Speed
    public void ChangeSpeed(int Speed)
    {
        //rigid.velocity = new Vector2(0, rigid.velocity.y + Speed);
        StartSpeed += Speed;
    }



    public void ChangeState(int state)
    {
        switch (state)
        {
            case 0:
                GetComponent<Advertising>().enabled = false;
                ad.enabled = true;
                break;
            case 1:
                GetComponent<Advertising>().enabled = true;
                ad.enabled = false;
                break;
            default:
                break;
        }
    }
}