using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float forwardSpeed;
	public float maxSpeed = 20;
	public Vector2 jumpSpeed;
	public Vector2 extraJump;
	public float acceleration;

	//boolean variables for jumping
	bool jump;
	bool doubleJump;
	bool checkDoubleJump;
	bool inAir;
	bool longJump;

	//variables to store how long the button has been pressed down
	float elapsedTime;
	float downTime;

	//variables for rotating of the character
	public float startAngle = 0;
	public float targetAngle = 0;
	public float startTime = 0;
	float smooth = 0.49f; // The number of seconds taken to rotate
	public float angle = 0;
	public float temp = 0;

	// Use this for initialization
	void Start () {
		//Sets conditions for a jump
		PostJump ();
		angle = transform.eulerAngles.y;
	}
	
	void PostJump() {
		//iniatilized after every jump
		jump = false;
		inAir = false;
		elapsedTime = 0;
		downTime = 0;
		longJump = true;
		smooth = 0.45f;
		checkDoubleJump = false;
		doubleJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		//If jump button is pressed and the block is not in air, make it jump
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			if (inAir == false) {
				jump = true;
				Debug.Log ("space");
			}

			//used for rotating the character sprite after every jump
			startTime = Time.time;
			startAngle = angle;
			targetAngle = targetAngle + 90;
		}

		//Tests conditions for a second jump
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) && inAir == true) {
			doubleJump = true;
		}

		//Records how long a button has been pressed
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {
			downTime += Time.deltaTime;
			elapsedTime = (float)downTime;
		}
		else {
			elapsedTime = 0f;
		}
		
		if (elapsedTime > 0.10) {
				Debug.Log (elapsedTime);
					if (longJump) {	
						GetComponent<Rigidbody2D>().AddForce (extraJump);
						longJump = false;
						smooth = 0.75f;
					}
				}

		//Caps the character speed to 25
		if (GetComponent<Rigidbody2D>().velocity.x > 24.9f) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (25, GetComponent<Rigidbody2D>().velocity.y);
		}
		else {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (forwardSpeed + acceleration, GetComponent<Rigidbody2D>().velocity.y);
		}

		//Rotating of the block
		temp =(Mathf.LerpAngle(startAngle, targetAngle, (Time.time - startTime)/smooth));
		angle = (float)temp;
		transform.eulerAngles = new Vector3(0.0f, 0.0f, -angle);
		acceleration += Time.deltaTime / 5;

		//Displays speed of the character
		Debug.Log ("Velocity is:" + GetComponent<Rigidbody2D>().velocity.x);
	}
	
	void FixedUpdate () {
		if (jump && inAir == false) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , 0);
			GetComponent<Rigidbody2D>().AddForce( jumpSpeed );
			jump = false;
			inAir = true;
			elapsedTime = 0;
			downTime = 0;
		}

		if (doubleJump == true && checkDoubleJump == false) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , 0);
			GetComponent<Rigidbody2D>().AddForce( jumpSpeed );
			doubleJump =false;
			checkDoubleJump = true;
		}
	}
	

	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 normal = collision.contacts[0].normal;
		if (normal.y > 0) {
			PostJump ();
			Debug.Log (elapsedTime);
			Debug.Log (inAir);
			Debug.Log ("Collision");
		}
	}
}
