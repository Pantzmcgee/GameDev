using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class Player_Controller_Velocity : MonoBehaviour {

 
    //movement
    public float speed;
    public float jump;
    private float moveVelocity;
    public float maxSpeedVert = 4f;

    //grounded var
    bool grounded = true;
  
	void FixedUpdate () {

        jumpMovement();
        leftrightMovement();
        
    }

    //jumping
    void jumpMovement()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (grounded)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jump, GetComponent<Rigidbody>().velocity.z);
            }
        }

        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.y) > maxSpeedVert)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, Mathf.Sign(GetComponent<Rigidbody>().velocity.y) * maxSpeedVert);
        }


    }
    //left Right movement
    void leftrightMovement()
    {
        
        moveVelocity = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(moveVelocity, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
    }
    //resets jumps if you touch the ground
    void OnCollisionStay(Collision col)
    {
        Debug.Log("You hit " + col.collider.name);
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }
    //sets jump to false if you are not touching the ground
    void OnCollisionExit(Collision col)
    {
        Debug.Log("You hit " + col.collider.name);
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }

    }
}
