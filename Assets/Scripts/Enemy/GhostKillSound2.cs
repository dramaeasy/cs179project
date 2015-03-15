using UnityEngine;
using System.Collections;

public class GhostKillSound2 : MonoBehaviour {
	
	private AudioSource audio;
	EnemyAI enemyai;
	bool played = false;
	
	void Awake()
	{
		audio = GetComponent<AudioSource> ();
		audio.enabled = false;
		enemyai = GetComponentInParent<EnemyAI> ();
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
