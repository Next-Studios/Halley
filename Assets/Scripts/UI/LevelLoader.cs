using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public enum LevelName{WorldColor, Hell, Iceland}

    public static LevelName WhatLevelSelected = LevelName.WorldColor;

    public GameObject LevelSelectionCanvas;
    public GameObject MainMenuCanvas;
    public Animator loading;
    int sceneIndex;
    public static bool OK = false;

    public void LoadLevel(int current)
	{
        sceneIndex = current;
        LevelSelectionCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        loading.SetTrigger("Load");
        OK = true;
        WhatLevelSelected = (LevelName) sceneIndex-1;
    }
    private void Update()
    {
        if (loading.GetCurrentAnimatorStateInfo(0).IsName("Slider Animation")&& OK == true)
        {
            StartCoroutine(LoadAsynchronously());
        }
    }


    IEnumerator LoadAsynchronously(){
        OK = false;
        AsyncOperation operation = SceneManager.LoadSceneAsync (1);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
			
			yield return null;
		}
        
        Player.State = Player.GameStatus.Start;
        Time.timeScale = 1;
    }
    
}
