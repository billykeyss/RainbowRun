using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	
	float playerScore = 0;
	
	void Update() {
		playerScore += Time.deltaTime;
	}
	
	public void IncreaseScore(int amount)
	{
		playerScore += amount;
	}
	
	void OnDisable()
	{
		PlayerPrefs.SetInt ("Score", (int)(playerScore * 100));
		PlayerPrefs.Save ();
	}
	
	void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(5, 5, 100, 30), "Score: " + (int) (playerScore * 100)); 
	}
}