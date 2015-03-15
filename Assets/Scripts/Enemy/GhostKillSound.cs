using UnityEngine;
using System.Collections;

public class GhostKillSound : MonoBehaviour {

	private AudioSource audio;
	EnemyAI2 enemyai;
	bool played = false;

	void Awake()
	{
		audio = GetComponent<AudioSource> ();
		audio.enabled = false;
		enemyai = GetComponentInParent<EnemyAI2> ();
	}

	void Update()
	{
		if(enemyai.enemyDead && !played)
		{
			played = true;
			audio.enabled = true;
			audio.Play();
		}
		else if(played)
		{
			if(!enemyai.enemyDead)
			{
				played = false;
			}
		}
	}
}
