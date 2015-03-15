using UnityEngine;
using System.Collections;

public class ResetPlayer : MonoBehaviour {

	public Transform playerSpawn;

	Transform playerPos;
	PlayerDeathSound sound;
	GameObject player;
	RedFlash flash;

	void Awake()
	{
		playerPos = GetComponent<Transform> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		sound = GetComponentInChildren<PlayerDeathSound> ();
		flash = GameObject.FindGameObjectWithTag("UI2").GetComponent<RedFlash> ();

		playerPos.position = playerSpawn.position;
	}

	public void ResetPlayerPosition()
	{
		sound.playDeathSound ();
		flash.playFlash ();
		if(PlayerLives.lives <= 0)
		{
			//Lose game
		}
		else
		{
			playerPos.position = playerSpawn.position;
		}
	}
}
