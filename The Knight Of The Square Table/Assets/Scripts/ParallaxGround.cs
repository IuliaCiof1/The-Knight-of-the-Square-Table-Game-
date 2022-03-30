using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParallaxGround : MonoBehaviour
{
   private Transform cameraTransform;
    public Transform grid;
    public Transform pet;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Camera main=GetComponent<Camera>();

        cameraTransform.position = new Vector3(cameraTransform.position.x + 0.005f, cameraTransform.position.y,cameraTransform.position.z); //make camera move to the right continuously
        Vector3 p = main.ViewportToWorldPoint(new Vector3(0, 0, main.nearClipPlane)); //gets position of the bottom left corner of the camera
        grid.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, 0); //move ground(tilemap) with the camera
        pet.position = new Vector3(p.x+2, pet.position.y, pet.position.z); //adjust pet location whenever screen size is changing
    }

    
}
