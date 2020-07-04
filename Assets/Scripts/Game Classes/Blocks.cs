using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {

    public static Color randBackColor;

    private Color randColor;
    private Rigidbody2D rigid;
    private bool MovableBlock;
    private int velocity;

    public Color[] Colors;
    [Range(0,359)]
    public float Sensivity = 20;
    public Camera Cam;
    public int Speed = 5;
    private const float SCREEN_LEFT = -1.58f, SCREEN_RIGHT = 1.53f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        velocity = Speed;

        if (Player.score > 0)
        {
            if (Random.Range(1, 5) == 1)
            {
                MovableBlock = true;
            }
            else
            {
                MovableBlock = false;
            }
        }

        for (int i = 0; i < Colors.Length+1; i++)
        {
            randBackColor = Colors[Random.Range(0, Colors.Length)];
        }
    }

    void Update()
    {
        if (MovableBlock && Player.State != Player.GameStatus.Stop)
        {
            rigid.velocity = new Vector2(velocity, 0);
            if (transform.position.x <= SCREEN_LEFT)
            {
                velocity = Speed;
            }
            else if (transform.position.x >= SCREEN_RIGHT)
            {
                velocity = -Speed;
            }
        }
        else
        {
            velocity = 0;
            rigid.velocity = new Vector2(velocity, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "BlockRemover") {
			BlockPlatformer.BlockDestroyer (gameObject);
		}
	}
}