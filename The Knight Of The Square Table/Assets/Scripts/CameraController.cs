using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset; //distance of camera from the player when player changes direction
    public float offsetSmoothing; //the bigger the number the faster camera will catch up
    private Vector3 playerPosition; //the bigger the number the faster camera will catch up

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f) //if player faces right
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
