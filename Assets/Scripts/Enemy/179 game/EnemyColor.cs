﻿using UnityEngine;
using System.Collections;

public class EnemyColor : MonoBehaviour {

	public float blinkTime = 1f;

	MeshRenderer mesh;
	EnemyAI enemy1; //Reference to the EnemyAI script to read powerUpActive variable
	float timer = 0f;
	Transform trans;
	EnemyAI enemyai;

	void Awake () 
	{
		mesh = GetComponent<MeshRenderer> ();
		enemy1 = GetComponentInParent<EnemyAI> ();
		trans = GetComponent<Transform> ();
		enemyai = GetComponent<EnemyAI> ();
	}

	void Update () 
	{
		if(Select.powerup_got && !enemyai.enemyDead) //blink between red and blue if player has picked up the power up
		{
			trans.localScale = new Vector3(6f, 6f, 6f);
			timer += Time.deltaTime;

			if(timer >= blinkTime)
			{
				if(mesh.renderer.material.color == Color.blue)
				{
					mesh.material.color = Color.blue;
				}
				else
				{
					mesh.material.color = Color.blue;
				}

				timer = 0f;
			}
		}
		else if(enemyai.enemyDead)
		{
			trans.localScale = new Vector3(1f, 1f, 1f);
			mesh.renderer.material.color = Color.green;
		}
		else
		{
			trans.localScale = new Vector3(6f, 6f, 6f);
			mesh.renderer.material.color = Color.red;
		}
	}
}
