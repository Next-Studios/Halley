using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour {

    [SerializeField]
    private Image LoadingBar;
    [SerializeField]
    [Range(0, 100)]
    private float CurrentAmount;
    [SerializeField]
    [Range(0,10)]
    private float Speed;
    [SerializeField]
    private bool IsReversed, ProgressOnStart = true;

    private int Zarib;
    private bool Done = false;

    void Start()
    {
        if (IsReversed) { Zarib = -1; }else { Zarib = 1; }
    }

    void Update()
    {
        if (ProgressOnStart)
        {
            LoadingBar.gameObject.SetActive(true);

            Done = CurrentAmount > 100 || CurrentAmount < 0;
            if (!Done)
            {
                CurrentAmount += Speed * Time.deltaTime * Zarib;
                LoadingBar.fillAmount = CurrentAmount / 100;
            }
            else
            {
                Done = true;
            }
        }
    }

    public void ProgressStart()
    {
        ProgressOnStart = true;
    }

    public void ProgressStop()
    {
        Speed = 0;
    }
    
    public bool IsDone{
        get { return Done; }
    }
}
