using UnityEngine;
using System.Collections;

public class power : MonoBehaviour {

	private GameObject player;


	// Use this for initialization
	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public void OnPickupEnter(){

		if (Select.powerup_got == false) {
			Select.powerup_got = true; 
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			Select.powerup_got = true;
			DestroyObject(GameObject.FindGameObjectWithTag("PowerUp"));
		}
	}
}
