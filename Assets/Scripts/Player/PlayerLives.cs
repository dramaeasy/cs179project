using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

	public static int lives = 3;

	void Update () 
	{
		if(PlayerLives.lives <= 0)
		{
			Application.LoadLevel("GameOverLevel");
		}
	}
}
