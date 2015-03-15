using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {
	
	Text text;
	public static bool isPaused;
	GameObject player;
	MouseLook look;

	void Awake()
	{
		text = GetComponent<Text> ();
		PauseScript.isPaused = false;
		player = GameObject.Find ("Player");
		look = player.GetComponent<MouseLook> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale > 0.01){
				
				text.enabled = true;
				text.text = "Pause";
				Time.timeScale = 0;
				PauseScript.isPaused = true;
				look.enabled = false;
				
				
			}else
			{
				look.enabled = true;
				PauseScript.isPaused = false;
				text.enabled = false;
				Time.timeScale = 1;
			}
		}
		
		
	}
}

