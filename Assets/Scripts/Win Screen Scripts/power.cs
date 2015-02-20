using UnityEngine;
using System.Collections;

public class power : MonoBehaviour {

	private GameObject player;


	// Use this for initialization
	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
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
