using UnityEngine;
using System.Collections;

public class EnemyColor : MonoBehaviour {

	public float blinkTime = 1f;

	MeshRenderer mesh;
	EnemyAI enemy1; //Reference to the EnemyAI script to read powerUpActive variable
	float timer = 0f;

	void Awake () 
	{
		mesh = GetComponent<MeshRenderer> ();
		enemy1 = GetComponentInParent<EnemyAI> ();
	}

	void Update () 
	{
		if(enemy1.powerUpActive) //blink between white and blue if player has picked up the power up
		{
			timer += Time.deltaTime;

			if(timer >= blinkTime)
			{
				if(mesh.renderer.material.color == Color.blue)
				{
					mesh.material.color = Color.white;
				}
				else
				{
					mesh.material.color = Color.blue;
				}

				timer = 0f;
			}
		}
	}
}
