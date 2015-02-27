using UnityEngine;
using System.Collections;

public class power : MonoBehaviour {

	private GameObject player;
	ParticleSystem explosionParticle;
	bool pickedUp = false;
	MeshRenderer mesh;

	// Use this for initialization
	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		explosionParticle = GetComponentInChildren<ParticleSystem> ();
		mesh = GetComponent<MeshRenderer> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			if(!pickedUp)
			{
				mesh.enabled = false;
				explosionParticle.Play();
				pickedUp = true;
				Select.powerup_got = true;
				PowerupListener.powerUpTimer = PowerupListener.powerUpTime;

			}
		}
	}

	void Update()
	{
		if(pickedUp && !explosionParticle.isPlaying)
		{
			//DestroyObject(GameObject.FindGameObjectWithTag("PowerUp"));
			DestroyObject(this.gameObject);
		}
	}
}
