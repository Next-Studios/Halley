using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColor : MonoBehaviour {

    void Start () {
        Invoke("changeColor", 0.5f);
    }

    private void changeColor()
    {
        GetComponent<SpriteRenderer>().color = Blocks.randBackColor;
    }
}
