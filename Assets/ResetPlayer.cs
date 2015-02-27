using UnityEngine;
using System.Collections;

public class ResetPlayer : MonoBehaviour {

	public Transform playerSpawn;

	Transform playerPos;

	void Awake()
	{
		playerPos = GetComponent<Transform> ();

		playerPos.position = playerSpawn.position;
	}

	public void ResetPlayerPosition()
	{
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
