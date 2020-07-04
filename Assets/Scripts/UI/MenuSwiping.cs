using UnityEngine;

public class MenuSwiping : MonoBehaviour {

	public Swipe swipeControler;
	public Animator anim;
	
	void Update () 
	{
        if (swipeControler.SwipeRight)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idel Animation"))
            {
                anim.SetTrigger("Setting Active");
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("ShopIsActive Animation"))
            {
                anim.SetTrigger("Shop DeActive");
            }
        }
        else if (swipeControler.SwipeLeft)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("SettingIsActive Animation"))
            {
                anim.SetTrigger("Setting DeActive");
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idel Animation"))
            {
                anim.SetTrigger("Shop Active");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("SettingIsActive Animation"))
            {
                anim.SetTrigger("Setting DeActive");
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("ShopIsActive Animation"))
            {
                anim.SetTrigger("Shop DeActive");
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idel Animation"))
            {
                anim.SetTrigger("ExitPanelActive");
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && anim.GetCurrentAnimatorStateInfo(0).IsName("ExitPanelActiveAnimation"))
            {
                anim.SetTrigger("ExitPanelDeActive");
            }
        }
	}
}
