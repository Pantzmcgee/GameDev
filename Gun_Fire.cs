using UnityEngine;
using System.Collections;

public class Gun_Fire : MonoBehaviour {

	public GameObject bullet;
	public float fireRate = 0.1F;
	public float nextFire = 0.1F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Vector2 bulletPos = transform.position;
			bulletPos.x = bulletPos.x + transform.up.x;
			bulletPos.y = bulletPos.y + transform.up.y;
			Instantiate(bullet, transform.position, transform.rotation);

		}
	
	}
}
