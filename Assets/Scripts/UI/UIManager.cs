using UnityEngine;


public class UIManager : MonoBehaviour {
    public static bool isplay = false;
    
  
    private void Awake()
    {
        Time.timeScale = 1;
        isplay = false;
    }
    

    // Update is called once per frame

    public void Play()
    {
        isplay = true;
    }
}
