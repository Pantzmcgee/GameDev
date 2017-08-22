using UnityEngine;
using System.Collections;

public class Camera_Script : MonoBehaviour {

	public Transform player;
	public int offset = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x,player.position.y,player.position.z-offset);
	}
}
