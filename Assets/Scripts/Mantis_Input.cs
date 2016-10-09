using UnityEngine;
using System.Collections;

public class Mantis_Input : MonoBehaviour {

    public Renderer rend;
    public GameObject Player;
   
    public bool runsRight = true;
    public bool grounded = false;
    public float jumpForce = 200;
    public bool stands = false;
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        runnerMovementChecker();
        runnerMovement();
	}

    void runnerMovementChecker()
    {
        if (!stands) { 
            if (runsRight)
            {
                rend.transform.Translate(Vector2.left * 0.25f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (!runsRight)
            {
                // Debug.Log("Shit has triggert");
                rend.transform.Translate(Vector2.left * 0.25f);
                //Player.GetComponent<Rigidbody2D>().AddForce(Vector2.right*speed);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else if (stands)
        {
            rend.transform.Translate(Vector2.left * 0);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {       
            


            if (coll.gameObject.name == "Ground")
            {
             grounded = true;

            } 
            else if (coll.gameObject.name == "RightWall")
            {
                runsRight = true;
                
            }
            else if (coll.gameObject.name == "LeftWall")
            {
                runsRight = false;
                
        } 
    }

    void runnerMovement()
    {
        if (Input.GetKey("space") && grounded){
            grounded = false;
            Debug.Log("pressed jump");
            if(runsRight)
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 800));
            else if (!runsRight)
                Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 800));


        }

        else if (Input.GetKey("a"))
        {
            stands = false;
            runsRight = false;
        }
        else if (Input.GetKey("d"))
        {
            stands = false;
            runsRight = true;
        }
        else if (Input.GetKey("s"))
        {
            stands = true;
        }
    }


}
