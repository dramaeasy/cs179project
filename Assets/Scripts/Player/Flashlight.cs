using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	Light flashlightSource;
	bool lightOn = false;
	public float drainPower = 0.1f;
	public float batteryLife = 0.0f;
	public float maxBatteryLife = 2.0f;

	AudioSource turnOn;
	AudioSource turnOff;

	// Use this for initialization
	void Start () {
		batteryLife = maxBatteryLife;
		flashlightSource = GetComponent<Light> ();
		flashlightSource.enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(batteryLife >= 0 && lightOn)
		{
			batteryLife -= drainPower * Time.deltaTime;
		}

		flashlightSource.intensity = batteryLife;

		if(batteryLife <= 0)
		{
			lightOn = false;
		}

		if(Input.GetKeyDown(KeyCode.F))
		{
			//TODO play flash light sounds
			toggleFlashlight();

			if(lightOn)
			{
				lightOn = false;
			}
			else if(batteryLife >= 0)
			{
				lightOn = true;
			}
		}



	
	}

	void toggleFlashlight()
	{
		if (lightOn) 
		{
			flashlightSource.enabled = false;
		}
		else
		{
			flashlightSource.enabled = true;
		}
	}
}
