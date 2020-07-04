using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftActs : MonoBehaviour
{

    public enum DashVelocity { Low = 5, Medium = 10, High = 20 }
    public enum CurrentAction { DoubleCoiner, InfiniteDash, Nothing }

    private GameObject PlayerGameObject, ProgressBar;
    private GameObject[] Blocks;
    private AudioSource music;
    private Behaviour halo;
    private int Velocity;
    private CurrentAction Action = CurrentAction.Nothing;

    /// <summary>
    /// Iniitiates Principle Parameters.
    /// </summary>
    /// <param name="PlayerGameObject">Sets the Main Player of the Game.</param>
    /// <param name="ProgressBar">Sets the Progress Bar object to determinates Time.</param>
    public GiftActs(GameObject PlayerGameObject, GameObject ProgressBar, GameObject[] Blocks, AudioSource Music)
    {
        this.PlayerGameObject = PlayerGameObject;
        this.ProgressBar = ProgressBar;
        this.Blocks = Blocks;
        this.music = Music;

        this.halo = (Behaviour)PlayerGameObject.GetComponent("Halo");
    }

    /// <summary>
    /// Updates Blocks Game Object.
    /// </summary>
    /// <param name="Blocks"></param>
    public void UpdateBlock(GameObject[] Blocks)
    {
        this.Blocks = Blocks;
    }

    /// <summary>
    /// Doubles Coins when You eate Gift.
    /// </summary>
    public void DoubleCoiner()
    {
        Action = CurrentAction.DoubleCoiner;

        halo.enabled = false;

        music.Play();
        this.ProgressBar.SetActive(true);
        this.ProgressBar.GetComponent<ProgressBar>().ProgressStart();

        Player.MultipleCoinAmount = 2;
    }
    /// <summary>
    /// Ends work of Double Coiner.
    /// </summary>
    public void EndDoubleCoiner()
    {
        Action = CurrentAction.Nothing;

        Player.MultipleCoinAmount = 1;
    }

    /// <summary>
    /// Dashs in Game without Collision.
    /// </summary>
    /// <param name="Velocity">Sets the Velocity of Player Dashing.</param>
    /// <returns>Returns the Current Speed of Player.</returns>
    public void InfiniteDash(DashVelocity Velocity, ScreenAndCamera cam)
    {
        Action = CurrentAction.InfiniteDash;

        this.Velocity = (int)Velocity;

        this.ProgressBar.SetActive(true);
        this.ProgressBar.GetComponent<ProgressBar>().ProgressStart();

        halo.enabled = true;

        BoxCollider2D[] col = this.Blocks[0].GetComponents<BoxCollider2D>();
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].isTrigger)
            {
                col[i].size = new Vector2(20, col[i].size.y);
                continue;
            }
            else
            {
                col[i].enabled = false;
            }
        }
        col = this.Blocks[1].GetComponents<BoxCollider2D>();
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].isTrigger)
            {
                col[i].size = new Vector2(20, col[i].size.y);
                continue;
            }
            else
            {
                col[i].enabled = false;
            }
        }
        print(cam.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        //cam.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, cam.gameObject.GetComponent<Rigidbody2D>().velocity.y + this.Velocity);
        cam.ChangeSpeed(this.Velocity);
        print(cam.gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    /// <summary>
    /// Ends work of InfiniteDash.
    /// </summary>
    public void EndInfiniteDash(ScreenAndCamera cam)
    {
        Action = CurrentAction.Nothing;

        //cam.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, cam.gameObject.GetComponent<Rigidbody2D>().velocity.y - this.Velocity);
        cam.ChangeSpeed(-this.Velocity);

        halo.enabled = false;

        BoxCollider2D[] col = this.Blocks[0].GetComponents<BoxCollider2D>();
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].isTrigger)
            {
                col[i].size = new Vector2(2.07f, col[i].size.y);
                continue;
            }
            else
            {
                col[i].enabled = true;
            }
        }
        col = this.Blocks[1].GetComponents<BoxCollider2D>();
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].isTrigger)
            {
                col[i].size = new Vector2(2.07f, col[i].size.y);
                continue;
            }
            else
            {
                col[i].enabled = true;
            }
        }
    }

    /// <summary>
    /// Gets the Current Action is Playing.
    /// </summary>
    public CurrentAction getCurrentAction()
    {
        return Action;
    }
}
