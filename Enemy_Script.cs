using UnityEngine;
using System.Collections;

public class Enemy_Script : MonoBehaviour {
	public Vector3 StartVec;
	public Vector3 EndVec;
	public Vector3 currentPos;
	public bool downswitch;

	// Use this for initialization
	void Start () {
		//sets starting locations, ending locations and current pos
		StartVec = this.transform.position;
		EndVec = this.transform.position;
		currentPos = this.transform.position;
		EndVec.y -= 10;
		downswitch = true;

		//randomizes the start location
		float Rand = Random.Range (1, 10);
		currentPos.y -= Rand;
		transform.position = currentPos; 
	
	}
	void FixedUpdate()
	{
		currentPos = this.transform.position;
		float time = Time.deltaTime*5;


		if (downswitch) 
		{
			currentPos.y -= time;
			transform.position = currentPos;

		} 
		else 
		{
			currentPos.y += time;
			transform.position = currentPos;
		}

		if (transform.position.y < EndVec.y) 
		{
			downswitch = false;
		}

		if(transform.position.y > StartVec.y)
		{
			downswitch = true;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
