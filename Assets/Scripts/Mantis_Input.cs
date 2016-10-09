using UnityEngine;
using System.Collections;

public class Mantis_Input : MonoBehaviour {

    public Renderer rend;
    public GameObject Player;
    public bool startGame = true;
    public bool grounded = false;
    public float jumpForce = 2000.0f;
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        runnerMovement();
        jump();
	}

    void runnerMovement()
    {
        if (startGame)
        {
            rend.transform.Translate(Vector2.left*0.1f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(!startGame)
        {
            rend.transform.Translate(Vector2.right*0.1f);
            //Player.GetComponent<Rigidbody2D>().AddForce(Vector2.right*speed);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
            if (coll.gameObject.name == "Ground")
            {
             grounded = true;

            } 
            if (coll.gameObject.name == "RightWall")
            {
                startGame = true;
                
            }
            else if (coll.gameObject.name == "LeftWall")
            {
                startGame = false;
                
        }
        

    }

    
    void jump()
    {
        if (Input.GetKey("space") && grounded){
            grounded = false;
            Debug.Log("pressed jump");
            Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);


        }
    }


}
