using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //player speed
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround; //true when player is touvhing ground
    private Vector3 respawnPoint; //where the player respawns
    //public GameObject fallDetector;

    //int score = 0;
    public TMP_Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {

        player = GetComponent<Rigidbody2D>(); //initialize with the rigidbody2d component to get access to stuff
        respawnPoint = transform.position;
        scoreText.text = "Score: " + Collectable.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        direction = Input.GetAxis("Horizontal");  //horizontal from input manager. changes when user presses a/d
       // Debug.Log(direction);


        if (direction > 0f) { //player is going right
            transform.localScale = new Vector2(1.7331f, transform.localScale.y); //make the player face right
            player.velocity = new Vector2(speed * direction, player.velocity.y); //!!!! Vector2(x,y), velocity of x axis = speed*direction
        }
        else if (direction < 0f) //player is going left
        {
            transform.localScale = new Vector2(-1.7331f, transform.localScale.y); //make the player face left
            player.velocity = new Vector2(speed * direction, player.velocity.y);
        }
        else   //player is not moving left or right
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        //fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    
    }

    private void OnTriggerEnter2D(Collider2D collision) //unity function, runs when it detects collision
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Collect")
        {
            //score += 1;
            Collectable.totalScore += 1;
            collision.gameObject.SetActive(false); //disable the object but it still exits
            scoreText.text = "Score: " + Collectable.totalScore;

        }
    }
}
