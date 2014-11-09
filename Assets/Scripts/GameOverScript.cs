using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	
	int score = 0;
	
	void start() {
		score = PlayerPrefs.GetInt("Score");
		PlayerPrefs.Save ();
	}
	
	void OnGUI()
	{
		score = PlayerPrefs.GetInt("Score");
		
		GUI.Label(new Rect(Screen.width/2 - 40, 50, 80, 30), "GAME OVER");
		
		GUI.Label(new Rect(Screen.width/2 - 40, 300, 80, 30), "Score: " + score);
		
		if(GUI.Button(new Rect(Screen.width / 2 - 30, 350, 60,30), "Retry?"))
		{
			Application.LoadLevel(0);
		}
	}
}