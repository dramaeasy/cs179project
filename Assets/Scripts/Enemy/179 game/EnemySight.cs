using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour 
{
	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public bool playerHeard;

	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	private GameObject player;
	private PlayerHealth playerHealth;

	void Awake()
	{
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerInSight = false;
	}

	void OnTriggerStay(Collider other) //Will be called every frame as long as player is in enemy sphere collider
	{
		if (other.gameObject == player) 
		{
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position; //Calculate vector from enemy to player
			float angle = Vector3.Angle(direction, transform.forward); 

			if(angle < fieldOfViewAngle * 0.5f) //Is player in cone in front of enemy?
			{
				RaycastHit hit; //Raycast to player to see if player is in line of sight

				Debug.DrawRay(transform.position + transform.up, direction.normalized, Color.blue, 100);
				if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, Mathf.Infinity)) //length of ray was not working if set to col.radius
				{
					if(hit.collider.gameObject == player)
					{
						playerInSight = true;
					}
				}


				//playerInSight = true;

			}

			if(CalculatePathLength(player.transform.position) <= 11.0)
			{
				//playerHeard = true;
			}
			else
			{
				playerHeard = false;
			}

		}
	}

	void OnTriggerExit(Collider other)//When player leaves the "sphere" collider
	{
		if(other.gameObject == player)
		{
			playerInSight = false;
		}
	}

	float CalculatePathLength(Vector3 targetPosition)
	{
		NavMeshPath path = new NavMeshPath ();

		if(nav.enabled)
		{
			nav.CalculatePath(targetPosition, path); //loads path with the path from enemy to the player
		}

		Vector3[] allWayPoints = new Vector3[path.corners.Length + 2]; //Waypoints from path are loaded into allWayPoints

		allWayPoints [0] = transform.position;
		allWayPoints [allWayPoints.Length - 1] = targetPosition;

		for(int i = 0; i < path.corners.Length; i++)
		{
			allWayPoints[i+1] = path.corners[i];
		}

		float pathLength = 0f;

		for(int i = 0; i < allWayPoints.Length - 1; i++)
		{
			pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i+1]); //calculate total distance from enemy to player
		}

		return pathLength;
	}
}
