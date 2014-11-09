using UnityEngine;
using System.Collections;

public class GroundMoveScript : MonoBehaviour {

	float speed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
	}
}
