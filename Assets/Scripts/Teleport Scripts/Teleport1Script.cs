using UnityEngine;
using System.Collections;

public class Teleport1Script : MonoBehaviour {

	private GameObject player;
	Transform playerLoc;
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerLoc = player.GetComponent<Transform> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			float x = 0.3f;
			float y = 7.87f;
			float z = 5.7f;
			Vector3 newLoc = new Vector3(x, y, z);
			playerLoc.position = newLoc;
		}
	}
}
