using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	public GameObject [] obj;
	public float spawnMin;
	public float spawnMax;

	public float acceleration;
	public float forwardSpeed = 5;
	
	void Start() 
	{
		Spawn();
	}

	void Update()
	{
		/*acceleration += Time.deltaTime * 20;
		Debug.Log ("Velocity is:" + rigidbody2D.velocity.x);
		
		if (rigidbody2D.velocity.x > 30.0f) {
			rigidbody2D.velocity = new Vector2 (31, rigidbody2D.velocity.y);
		} else {
			rigidbody2D.velocity = new Vector2 (forwardSpeed + acceleration, rigidbody2D.velocity.y);
		}*/

		if (GetComponent<Rigidbody2D>().velocity.x > 20) {
			spawnMin = 0.5f;
			spawnMax = 1f;
		}
	}

	void Spawn()
	{
		Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
		Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	}
}