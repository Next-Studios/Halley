using UnityEngine;

public class NextAndPre : MonoBehaviour {

    public GameObject List , NEXTBtn , PREBtn;
    public float High, Distance, Minimum;
    public static int trailnum;
    public GameObject[] BtnPack;
	// Use this for initialization
	void Start ()
    {
        trailnum = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (List.transform.position.x == High)
        {
            NEXTBtn.SetActive(false);
        }
        else
        {
            NEXTBtn.SetActive(true);
        }
        if (List.transform.position.x == Minimum)
        {
            PREBtn.SetActive(false);
        }
        else
        {
            PREBtn.SetActive(true);
        }
        

        for (int i = 0; i < BtnPack.Length; i++)
        {
            if (i == trailnum)
            {
                BtnPack[i].SetActive(true);
            }
            else
            {
                BtnPack[i].SetActive(false);
            }
        }
        


    }

    public void NEXT ()
    {
        trailnum = trailnum + 1;
        List.transform.position = new Vector3(List.transform.position.x + Distance, List.transform.position.y);
    }

    public void PRE()
    {
        trailnum = trailnum - 1;
        List.transform.position = new Vector3(List.transform.position.x - Distance, List.transform.position.y);
    }
}
