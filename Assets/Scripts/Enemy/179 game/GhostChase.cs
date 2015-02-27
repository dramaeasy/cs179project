using UnityEngine;
using System.Collections;

public class GhostChase : MonoBehaviour {

	public float timeToChase;
	public static float ghostChaseTimer;
	public float idleTime;
	public static bool ghostsChasingPlayer;

	void Awake()
	{
		ghostChaseTimer = 0;
		timeToChase = 0;
		idleTime = 15;
		ghostsChasingPlayer = false;
	}

	void Update()
	{
		if(ghostChaseTimer >= idleTime)
		{
			ghostsChasingPlayer = true;
		}

		if(ghostsChasingPlayer)
		{
			Debug.Log("Chasing Player. Time Left: " + (int)ghostChaseTimer);
			ghostChaseTimer -= Time.deltaTime;

			if(ghostChaseTimer <= 0)
			{
				ghostsChasingPlayer = false;
				ghostChaseTimer = 0;
			}
		}
		else
		{
			ghostChaseTimer += Time.deltaTime;
			int timeLeft = (15 - (int)ghostChaseTimer);
			Debug.Log("Countdown till ghosts chase player: " + timeLeft);
		}
	}
}
