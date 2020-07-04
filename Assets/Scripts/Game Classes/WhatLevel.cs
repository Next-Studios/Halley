using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatLevel : MonoBehaviour {

    public GameObject[] Blocks = new GameObject[3];
    public AudioClip[] SFX = new AudioClip[3];
    public AudioSource MainSFX;

    void Start() {
        print(LevelLoader.WhatLevelSelected);
        Instantiate(Blocks[(int)LevelLoader.WhatLevelSelected]);
        MainSFX.clip = SFX[(int)LevelLoader.WhatLevelSelected];
    }
}
