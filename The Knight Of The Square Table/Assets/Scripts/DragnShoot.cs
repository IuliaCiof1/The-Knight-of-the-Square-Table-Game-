using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragnShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    public bool thrown;

    Camera cam; //for mouse position
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    TrajectoryLine tl;

    public TMP_Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tl = GetComponent<TrajectoryLine>();
        cam = Camera.main; //grab first camera object it finds
        
    }

    // Update is called once per frame
    public void Updatee()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition); //gets mouse coordonates when clicked
            startPoint.z = 15; //prevents coordonates from going behind the screen
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            tl.RenderLine(startPoint, currentPoint, force);
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb = GetComponent<Rigidbody2D>();
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition); //gets mouse coordonates when clicked
            endPoint.z = 15; //prevents coordonates from going behind the screen

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x,maxPower.x),Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));

            //Debug.Log(force);
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
            thrown = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //if pet collects collectables
    {
        if (collision.tag == "Collect")
        {
            Collectable.totalScore += 1;
            collision.gameObject.SetActive(false);
            scoreText.text = "Score: " + Collectable.totalScore;
        }
    }
}
