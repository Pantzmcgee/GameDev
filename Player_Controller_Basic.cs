using UnityEngine;
using System.Collections;

public class Player_Controller_Basic : MonoBehaviour {

    private float moveForce;
    public float moveForceMin = 50f;
    public float moveForceMax = 200f;
    public float maxSpeedVert = 4f;
    public float maxSpeedHorz = 3f;
    public float acceleration = 5f;

    public float jumpForce = 2250f;
    public bool groundJump = false;

    private Rigidbody rb3d;

    // Use this for initialization
    void Start()
    {
        moveForce = moveForceMin;
        rb3d = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        //horizontal control
        leftRightMove();
        //jump control
        jumpMove();

    }

    void leftRightMove()
    {
        //Adds force
        if (Input.GetKey(KeyCode.A))
        {
            if (moveForce < moveForceMax)
            {
                moveForce = moveForce + acceleration;
            }
            else
            {
                moveForce = moveForceMax;
            }
            rb3d.AddForce(Vector3.right * -1 * moveForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (moveForce < moveForceMax)
            {
                moveForce = moveForce + acceleration;
            }
            else
            {
                moveForce = moveForceMax;
            }
            rb3d.AddForce(Vector3.right * moveForce);
        }

        //When these keys are released moveForce returns to min
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveForce = moveForceMin;
            rb3d.velocity = new Vector3(0, rb3d.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveForce = moveForceMin;
            rb3d.velocity = new Vector3(0, rb3d.velocity.y);
        }

                //Caps Max Horz Velocity
        if (Mathf.Abs(rb3d.velocity.x) > maxSpeedHorz)
        {
            rb3d.velocity = new Vector3(Mathf.Sign(rb3d.velocity.x) * maxSpeedHorz, rb3d.velocity.y);
        }
        

    }

    void jumpMove()
    {
        //jump if you hit space
        if (Input.GetKeyDown("space"))
        {
            if (groundJump)
            {

                //adds the jump force and sets ground to false
                rb3d.AddForce(Vector2.up * jumpForce);
               
            }

        }
        //Caps Vertical Velocity
        if (Mathf.Abs(rb3d.velocity.y) > maxSpeedVert)
        {
            rb3d.velocity = new Vector3(rb3d.velocity.x, Mathf.Sign(rb3d.velocity.y) * maxSpeedVert);
        }
    }

    //resets jumps if you touch the ground
    void OnCollisionStay(Collision col)
    {
        Debug.Log("You hit " + col.collider.name);
        if (col.gameObject.tag == "Ground")
        {
            groundJump = true;
        }

    }
    //sets jump to false if you are not touching the ground
    void OnCollisionExit(Collision col)
    {
        Debug.Log("You hit " + col.collider.name);
        if (col.gameObject.tag == "Ground")
        {
            groundJump = false;
        }

    }
}
