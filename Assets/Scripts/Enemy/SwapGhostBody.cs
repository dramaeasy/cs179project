using UnityEngine;
using System.Collections;

public class SwapGhostBody : MonoBehaviour {
	private Vector3 currPos;
	private Quaternion currQuart;
	private GameObject ghostNormal, ghostChase;
	private GameObject current, temp;
	private EnemyAI enemy;
	private bool oldmode;
	
	void Start ()
	{
		ghostChase = Resources.Load ("ghostChase") as GameObject;
		ghostNormal = Resources.Load ("ghostNormal") as GameObject;
		Vector3 trans = gameObject.transform.position;
		current = Instantiate (ghostNormal, trans, gameObject.transform.rotation) as GameObject;
		current.transform.parent = gameObject.transform;	
		current.AddComponent("ClothMovement");
		current.AddComponent("EnemyColor");
		oldmode = true;
	}

	void Update ()
	{
		enemy = GetComponentInChildren<EnemyAI> ();
		if (oldmode != enemy.patrolMode) 				// if there is a change in mode
		{												//  swap bodies
			temp = current;
			Destroy (current);
			currPos = gameObject.transform.position; 	// get position and rotation of 
			currQuart = gameObject.transform.rotation;	//  sphere

			if (enemy.patrolMode == false) 				// if in chase mode or running away
			{ 
					current = GameObject.Instantiate (ghostChase, currPos, currQuart) as GameObject;
			} 
			else
			{											// else if in patrol mode
					current = GameObject.Instantiate (ghostNormal, currPos, currQuart) as GameObject;
			}
			current.transform.parent = gameObject.transform;	// Set ghostHead as ghostBody's parent
			current.AddComponent ("ClothMovement");				// Add ClothMovement script to ghost's body
			current.AddComponent("EnemyColor");
			oldmode = enemy.patrolMode;
		}
	}
}
