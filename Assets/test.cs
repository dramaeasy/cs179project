using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	GameObject player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider other)
	{
			Debug.Log ("PLAYER ENTERED!");
	}
}
