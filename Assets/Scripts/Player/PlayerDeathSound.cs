using UnityEngine;
using System.Collections;

public class PlayerDeathSound : MonoBehaviour {

	AudioSource audio;

	void Awake()
	{
		audio = GetComponent<AudioSource> ();
		audio.enabled = false;
	}

	public void playDeathSound()
	{
		audio.enabled = true;
		audio.Play();
	}
}
