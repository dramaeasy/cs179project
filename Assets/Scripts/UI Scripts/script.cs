using UnityEngine;
using System.Collections;

public class script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey("return"))
		{
			Select.level = 0;
			PlayerLives.lives = 3;
			Select.puz_piece = 0;
			Application.LoadLevel("Level01");
			Select.totalPuzPieces = 25;
			Select.powerup_got = false;
		}
	}
}
