using UnityEngine;
using System.Collections;

public class PowerupListener : MonoBehaviour {

	public static float powerUpTimer = 30f; //Duration of powerup 

	void Update()
	{
		if(Select.powerup_got)
		{
			powerUpTimer -= Time.deltaTime;
		
				
			if(powerUpTimer <= 0)
			{
				Select.powerup_got = false;
				powerUpTimer = 10f;
			}			
		}
	}
}
