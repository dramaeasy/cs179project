using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	private GameObject player;
	private Light light;

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
		if (other.gameObject == player) 
		{
			Select.puz_piece += 1;
			DestroyObject(light);
			DestroyObject(this.gameObject);
		}
	}
}
