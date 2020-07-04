using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailShow : MonoBehaviour
{
    public GameObject Trail;
    public GameObject Background;
    public GameObject TrailSelectionCanvas;
    public Animator TrailSelection;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.touchCount < 2)
            || Input.GetMouseButton(0))
        {


            Plane plane = new Plane(-Camera.main.transform.forward, this.transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float ray_distance;
            if (plane.Raycast(ray, out ray_distance))
            {
                this.transform.position = ray.GetPoint(ray_distance);
            }

        }
        if (Input.GetMouseButtonUp(0) && TrailSelection.GetCurrentAnimatorStateInfo(0).IsName("Closer Animation"))
        {
            
            Trail.SetActive(false);
            TrailSelection.SetTrigger("Opener");
            Background.SetActive(true);
        }
    }
}

