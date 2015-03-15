using UnityEngine;
using System.Collections;

public class MinimapUI : MonoBehaviour {

	Camera camera;

	void Awake()
	{
		camera = GetComponent<Camera> ();
	}

	void Update () {

		if(Select.powerup_got)
		{
			if(Select.level == 0)
			{
				camera.enabled = true;
			}
		}
		else
		{
			camera.enabled = false;
		}
	}
}
