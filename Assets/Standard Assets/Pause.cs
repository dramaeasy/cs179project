using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

	Text text;

	void Awake()
	{
		text = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
		{
//			if (Time.timeScale == 1)
//			{
//				text.enabled = true;
//				text.text = "Pause";
//				Time.timeScale = 0;
//				
//			}
//			else
//			{
//				text.enabled = false;
//				Time.timeScale = 1;
//			}
			if(Time.timeScale > 0.01){
				
				text.enabled = true;
								text.text = "Pause";
								Time.timeScale = 0;

			}else
							{
								text.enabled = false;
								Time.timeScale = 1;
							}
		}

	
}
}

