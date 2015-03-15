using UnityEngine;
using System.Collections;

public class Teleport2Script : MonoBehaviour {

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
			float x = 30.66f;
			float y = 3.66f;
			float z = 0.22f;
			Vector3 newLoc = new Vector3(x, y, z);
			playerLoc.position = newLoc;
		}
	}
}
