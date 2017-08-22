using UnityEngine;
using System.Collections;

public class Gun_Motion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//gets the points of the mouse and object
		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);

		//Gets the distance between each component
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

	 	//gets the angle and rotates it to follow mouse
		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		angle = angle + 270;



		if (angle < 180 && angle > 130) 
		{
			angle = 130;
		}
		if (angle > 180 && angle < 240) 
		{
			angle = 240;
		}
		transform.rotation = Quaternion.Euler (0, 0, angle);

	
	}
}
