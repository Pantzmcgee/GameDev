using UnityEngine;
using System.Collections;

public class Bullet_Motion : MonoBehaviour {

	private Rigidbody2D rb2d;
	public int bulletSpeed = 5000; 

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.AddForce (transform.up*bulletSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//rb2d.AddForce (transform.up*bulletSpeed);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (gameObject);
		
	}

}
