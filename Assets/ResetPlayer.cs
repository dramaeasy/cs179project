using UnityEngine;
using System.Collections;

public class ResetPlayer : MonoBehaviour {

	Transform playerPos;

	void Awake()
	{
		playerPos = GetComponent<Transform> ();
	}

	public void ResetPlayerPosition()
	{
		if(PlayerLives.lives <= 0)
		{
			//Lose game
		}
		else
		{
			playerPos.position = new Vector3(1.63f, 1.6f, -11.36f);
		}
	}
}
