using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	private GameObject player;
	private Light light;
	public AudioSource audio;
	bool pickedUp = false;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		light = GetComponentInParent<Light> ();
	}

	public void OnLookEnter(){
		if (renderer.enabled == true) {
			Select.puz_piece += 1;
			renderer.enabled = false;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player || pickedUp) 
		{
			if(!pickedUp)
			{
				audio.Play();
				renderer.enabled = false;
				Select.puz_piece += 1;
			}

			pickedUp = true;
		}
	}

	void Update()
	{
		if(pickedUp)
		{		
			if(!audio.isPlaying)
			{
				DestroyObject(light);
				DestroyObject(this.gameObject);
			}
		}
	}
}
