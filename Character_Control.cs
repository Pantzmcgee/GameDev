using UnityEngine;
using System.Collections;

public class Character_Control : MonoBehaviour {


	public float addThrustForce = 90f;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void FixedUpdate()
	{
		shipThrust ();
		shipRotation ();

	}
	void shipThrust()
	{


		float v = Input.GetAxis("Vertical");
		if (v > 0) 
		{
			rb2d.AddForce(transform.up*addThrustForce);
		}
	}
	void shipRotation()
	{
		//gets the points of the mouse and object
		Vector2 mousePos = Input.mousePosition;
		Vector2 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		
		//Gets the distance between each component
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		
		//gets the angle and rotates it to follow mouse
		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		angle = angle + 270;
		

		transform.rotation = Quaternion.Euler (0, 0, angle);
	}

	




}
