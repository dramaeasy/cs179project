using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerupUI : MonoBehaviour {
	
	Text text;
	Animator anim;
	
	void Awake()
	{
		text = GetComponent<Text> ();
		anim = GetComponent<Animator> ();
		anim.enabled = false;
	}
	
	void Update () 
	{
		int timeLeft = (int)PowerupListener.powerUpTimer;

		if(timeLeft < 0)
		{
			timeLeft = 0;
		}

		if(Select.powerup_got)
		{
			anim.enabled = true;
			text.text = "Power Up Time Left: " + timeLeft;
		}
		else
		{
			text.text = "";
		}

	}
}
