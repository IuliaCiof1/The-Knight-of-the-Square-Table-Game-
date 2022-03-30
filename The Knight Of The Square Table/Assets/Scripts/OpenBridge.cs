using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBridge : MonoBehaviour
{
    public GameObject bridge;
    public GameObject bridge_child1;
    public GameObject bridge_child2;
    BoxCollider2D colBridge;
    SpriteRenderer srBridge_child1;
    SpriteRenderer srBridge_child2;
    public bool isTriggered;
    public float maxBridgeW;
    private int updateInterval = 20; //number of frames

    Animator button_anim;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(bridge.transform.childCount);
        bridge_child1 = bridge.transform.GetChild(index:0).gameObject;
        bridge_child2 = bridge.transform.GetChild(index:1).gameObject;
        srBridge_child1 = bridge_child1.GetComponent<SpriteRenderer>();
        srBridge_child2 = bridge_child2.GetComponent<SpriteRenderer>();
        colBridge = bridge_child1.GetComponent<BoxCollider2D>();
        isTriggered = false;
        button_anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bridge.transform.childCount);
        if (Time.frameCount % this.updateInterval != 0) return;  //makes update execute every updateInterval frames
        //Invoke("BuildBridge", 10);
        if (isTriggered == true && srBridge_child1.size.x < maxBridgeW-1)
        {
            Debug.Log(" " + srBridge_child1.bounds.size.x + " " + srBridge_child1.size.x);
            srBridge_child1.drawMode = SpriteDrawMode.Tiled;
            srBridge_child2.drawMode = SpriteDrawMode.Tiled;
            srBridge_child1.size = new Vector2(srBridge_child1.size.x + 1, srBridge_child1.size.y);
            srBridge_child2.size = new Vector2(srBridge_child2.size.x + 1, srBridge_child2.size.y);
            //colBridge.offset = new Vector2(srBridge_child1.size.x / 3, colBridge.offset.y);
            //colBridge.size = new Vector2(srBridge_child1.size.x / 2, colBridge.size.y);
            colBridge.offset = new Vector2(srBridge_child1.bounds.size.x, colBridge.offset.y);
            colBridge.size = new Vector2(srBridge_child1.bounds.size.x/bridge_child1.transform.localScale.x, colBridge.size.y);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // button_anim.SetBool("go", false);
        if (isTriggered==false && collision.gameObject.CompareTag("TriggerKey"))
        {
            isTriggered = true;
            //button_anim.Play("PressedButton"); //plays pressedbutton animation
            button_anim.SetBool("go", true);
            Debug.Log("y");
            
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)      //button collision needs to have isTriger true
    //{
    //    if (collision.tag == "TriggerKey")
    //    {
    //        isTriggered = true;
    //        button_anim.Play("PressedButton",0,0.0f); //plays pressedbutton animation
    //    }
    //}
}
