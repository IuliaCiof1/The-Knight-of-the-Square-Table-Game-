using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool grabbed;
    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;

    public GameObject detectedObject;
    public Transform detectionPoint;
    public float detectionRadius=0.5f;
    public LayerMask detectionLayer;
    public Rigidbody2D objec;
    public Collider2D collision;

    DragnShoot func;
    bool detected;
    bool addrb;
    // Start is called before the first frame update
    void Start()
    {
        addrb = false;
        //objec = objec.GetComponent<Rigidbody2D>(); //initialize objec with Rigidbody2d component to acces the good stuff
        //  Destroy(objec.GetComponent<Rigidbody2D>());
        //collision = detectedObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //detected = DetectObject();
        if (!grabbed && DetectObject() && Input.GetKeyDown(KeyCode.E)) //pick up when player presses E
        {

            if (!grabbed)
            {
                objec = detectedObject.GetComponent<Rigidbody2D>();
                detectedObject.GetComponent<DragnShoot>().enabled = false;
                //grab
                //Destroy(detectedObject.GetComponent<Rigidbody2D>()); //the detected object cannot have rigidbody2d component while holding (otherwise the object cannot be held and moved)
                //objec.constraints = RigidbodyConstraints2D.None;
                //objec.isKinematic = true;
              ///  objec = detectedObject.AddComponent<Rigidbody2D>();
                grabbed = true;
                grabbedObject = detectedObject;
                grabbedObject.transform.parent = transform; //parent grabbed object to player
                grabbedObjectYValue = grabbedObject.transform.position.y;
                grabbedObject.transform.localPosition = grabPoint.localPosition;
                //Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x);
            }
            else
            {
                //throw
                //objec = detectedObject.AddComponent<Rigidbody2D>();
                ////detectedObject.transform.position = transform.position;
                ////grabbedObject.transform.localPosition = grabPoint.localPosition;
                //objec.constraints = RigidbodyConstraints2D.FreezeRotation;
                //grabbedObject.transform.parent = null;
                //grabbedObject = null;
                //detectedObject.GetComponent<DragnShoot>().enabled = true;
                //DragnShoot func = detectedObject.GetComponent<DragnShoot>();
                //func.enabled = true;
                //func.Update();
                //grabbed = false;

                //grabbedObject.transform.parent = null;
                // Debug.Log(grabbedObject.transform.position.x);
                //grabbedObject.transform.position = new Vector3(grabbedObject.transform.position.x, grabbedObjectYValue, grabbedObject.transform.position.z);

                // grabbedObject = null;
                //objec = detectedObject.AddComponent<Rigidbody2D>(); //readds rigidbody2d component (no rigidbody comp. => detected object has no gravity)

            }
           

 
        }
        if (grabbed)
        {
            if (addrb==false)
            {
                //objec = detectedObject.AddComponent<Rigidbody2D>();
                objec.constraints = RigidbodyConstraints2D.FreezeRotation;
                addrb = true;
            }

            func = detectedObject.GetComponent<DragnShoot>();
            detectedObject.GetComponent<Rigidbody2D>().gravityScale=0.0f;
       
            detectedObject.transform.position = transform.position;
            //grabbedObject.transform.localPosition = grabPoint.localPosition;
            
            func.enabled = true;
           
            func.Updatee();
            if (func.thrown == true)
            {
                addrb = false;
                objec.GetComponent<Rigidbody2D>().gravityScale = 1f;
                grabbedObject.transform.parent = null;
                grabbedObject = null;
                grabbed = false;
                func.thrown = false;
                func.enabled = false;
            }
            
            objec.freezeRotation = false;
        }
    }

    bool DetectObject() //detect object to be picked (any object with the tag selected as detection layer can be held)
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        
        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            collision = detectedObject.GetComponent<Collider2D>();
            
            //  if (collision.tag == "Item")
            // {
            Physics2D.IgnoreCollision(collision, gameObject.GetComponent<Collider2D>()); //ignore collision between detected object and player (substitute for isTrigger(istrigger+eigidbody=object falls through the ground))
           // }
            return true;
        }
    }

}
