using UnityEngine;
using System.Collections;

public class PowerupListener : MonoBehaviour {
	public static float powerUpTime = 11f;
	public static float powerUpTimer = powerUpTime; //Duration of powerup 
	public AudioSource audio;
	

	void Update()
	{
		if(Select.powerup_got)
		{
			if(!audio.isPlaying)
			{
				audio.Play();
			}

			powerUpTimer -= Time.deltaTime;
		
				
			if(powerUpTimer <= 0)
			{
				Select.powerup_got = false;
				powerUpTimer = 10f;
			}			
		}
	}
}
