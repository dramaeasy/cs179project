using UnityEngine;
using System.Collections;

public class RedFlash : MonoBehaviour {

	Animator anim;
	bool playerDied;
	float timer = 0;
	
	// Use this for initialization
	void Awake() 
	{
		anim = GetComponent <Animator> ();
		timer = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		/*
		if(playerDied)
		{
			playerDied = false;
			timer += Time.deltaTime;

			if(timer >= 0.5f)
			{
				anim.SetBool("playerDied", false);
				timer = 0;
			}
		}
		*/
	}

	public void playFlash()
	{
		/*
		playerDied = true;
		anim.enabled = true;
		anim.SetBool ("playerDied", true);
		*/
		anim.Play ("redFlash");
	}
}
