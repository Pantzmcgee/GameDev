using UnityEngine;
using System.Collections;

public class Large_Astroid_Behavior : MonoBehaviour {
	private Computation calc;

	public float addextraForce = 60;
	public float addextraTorque = 10;

	private Rigidbody2D rb2d;
	private Vector2 velocity;


	void Start () {
		//gets
		rb2d = GetComponent<Rigidbody2D> ();

		//creates a random number that will be either -1 or 1
		float randF = Random.Range (-1, 1);
		Debug.Log (randF);
			if (randF >= 0) {
				randF = 1;
			} 
			else 
			{
			randF = -1;
			}
		Debug.Log (randF);
		//creates a random number that will be either -1 or 1
		float randT = Random.Range (-1, 1);
		if (randT >= 0) {
			randT = 1;
		} 
		else 
		{
			randT = -1;
		}

		//creates vector that will be used for force
		Vector2 randForce = new Vector2 (Random.Range(5,15)*addextraForce*randF,Random.Range(5,15)*addextraForce*randF);

		//adds torque and force to astroid
		rb2d.AddTorque (Random.Range(5,10)*addextraTorque*randT,ForceMode2D.Impulse);
		rb2d.AddForce (randForce);

	}
	
	// Update is called once per frame
	void Update () {

		//Ray2D ray = new Ray2D (this.gameObject.transform.position, this.gameObject);
		RaycastHit hit;

		//if(Physics.Raycast(ray,out hit,this.gameObject.collider.bounds.size.x+5f))
	
	}
	void OnCollisionEnter2D(Collision2D col)
	{

	}
}
