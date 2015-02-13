using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerupUI : MonoBehaviour {
	
	Text text;
	
	void Awake()
	{
		text = GetComponent<Text> ();
	}
	
	void Update () 
	{
		int timeLeft = (int)EnemyAI.powerUpTimer;

		if(timeLeft < 0)
		{
			timeLeft = 0;
		}

		if(Select.powerup_got)
		{
			text.text = "Power Up Time Left: " + timeLeft;
		}
		else
		{
			text.text = "";
		}

	}
}
