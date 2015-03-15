using UnityEngine;
using System.Collections;

public class RestartGameListener : MonoBehaviour {

 	void OnGui(){
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),"Press Enter to Restart Game");
	}
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
				Select.puz_piece = 0;
				PlayerLives.lives = 3;
				Application.LoadLevel ("Level01"); 
				Select.level = 0;
		}
	}
}
