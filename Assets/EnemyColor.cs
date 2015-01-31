using UnityEngine;
using System.Collections;

public class EnemyColor : MonoBehaviour {

	SkinnedMeshRenderer mesh;
	float blinkTime = 1f;
	float timer = 0f;
	Color redd;
	// Use this for initialization
	void Start () 
	{
		mesh = GetComponent<SkinnedMeshRenderer> ();
		redd = new Color (1, 0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if(timer >= blinkTime)
		{
			if(mesh.renderer.material.color == Color.blue)
			{
				Debug.Log("im  red");
				mesh.material.color = Color.white;
			}
			else
			{
				Debug.Log("Im blue");
				mesh.material.color = Color.blue;
			}

			timer = 0f;
		}
	}
}
