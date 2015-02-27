using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemiesChasingUI : MonoBehaviour {

	Text text;
	Animator anim;
	
	void Awake()
	{
		text = GetComponent<Text> ();
		anim = GetComponent<Animator> ();
		anim.enabled = true;
	}
	
	void Update () 
	{
		if(GhostChase.ghostsChasingPlayer && !Select.powerup_got)
		{
			anim.SetBool("isChasing", true);

			text.text = "Run Away! They Are Chasing You";
		}
		else
		{
			anim.SetBool("isChasing", false);
			text.text = "";
		}
		
	}
}
