using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProgressOficial : MonoBehaviour
{
    
    public Image LoadingBar;
    [Range(0, 100)]
    public float CurrentAmount = 100;
    [Range(0, 100)]
    public float Speed;
    public bool Reverse = false;
    public bool CanTrustMe = false, ForGift = false;

    private static float Amount = 100;
    private static float fixedAmount = 0;
    private int zarib = 1;
    private ProgressBar ProgressLoad;

    public bool Done;

    void Start()
    {
        //ProgressLoad = new ProgressBar(LoadingBar, CurrentAmount, Speed, Reverse);
        CanTrustMe = false;
        Done = false;
        fixedAmount = Amount = CurrentAmount;

        if (Reverse) { zarib = -1; } else { zarib = 1; }
    }

    void Update()
    {
        Done = Amount > 100 || Amount < 0;

        CurrentAmount = Amount;

        if (!Done)
        {
            Amount += Speed * Time.deltaTime * zarib;
            LoadingBar.fillAmount = Amount / 100;
        }
        else
        {
            Renew();

            gameObject.SetActive(false);
        }
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            Speed = 0;
        }
        else
        {
            Speed = 20;
        }
    }

    public void Renew()
    {
        Amount = fixedAmount;
    }
}
