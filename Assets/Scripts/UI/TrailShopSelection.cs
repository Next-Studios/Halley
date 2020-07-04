using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrailShopSelection : MonoBehaviour {
    public Animator TrailSelectionAnimator;
    public Swipe swipeControler;
    public Color colorActive;
    public Color colordeActive;
    public Image Lvl1, Lvl2;
    void Update()
    {
        if (swipeControler.SwipeRight)
        {
            if (TrailSelectionAnimator.GetCurrentAnimatorStateInfo(0).IsName("1to2 Animation"))
            {
                TrailSelectionAnimator.SetTrigger("2to1");
            }

           

        }
        else if (swipeControler.SwipeLeft)
        {
            if (TrailSelectionAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idel"))
            {
                TrailSelectionAnimator.SetTrigger("1to2");
            }


        }
        //CurrentLevelShow
        if (TrailSelectionAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idel") || TrailSelectionAnimator.GetCurrentAnimatorStateInfo(0).IsName("2to1 Animation"))
        {
            Lvl1.color = colorActive;
            Lvl2.color = colordeActive;
            
            
        }
        if (TrailSelectionAnimator.GetCurrentAnimatorStateInfo(0).IsName("1to2 Animation"))
        {
            Lvl1.color = colordeActive;
            Lvl2.color = colorActive;
            

        }

    }
}
