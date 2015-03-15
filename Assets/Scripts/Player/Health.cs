using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	Text text;
	
	void Awake()
	{
		text = GetComponent<Text> ();
	}

	void Update () 
	{
		text.text = "Lives Left: " + PlayerLives.lives;
	}
}
