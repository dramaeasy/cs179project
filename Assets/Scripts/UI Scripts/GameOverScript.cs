using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	
	Text text;
	
	void Awake()
	{
		text = GetComponent<Text> ();
	}
	
	void Update () 
	{
		if(PlayerLives.lives <= 0)
		{
			text.text = "GAME OVER!";
		}
		else
		{
			text.text = "";
		}
	}
}
