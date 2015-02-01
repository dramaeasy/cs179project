using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public float patrolSpeed = 2f;
	public float chaseSpeed = 2f;
	public float chaseWaitTime = 2f;
	public float patrolWaitTime = 1f;
	public Transform [] patrolWaypoints;
	public bool powerUpActive;
	public float powerUpTime = 7f;
	public float powerUpTimer = 0f;
	public float fieldOfViewAngle = 110f;
	
	private Transform enemyLoc;
	private EnemySight enemySight;                         
	private NavMeshAgent nav; 
	private Animator anim;
	private Transform player;                               
	private PlayerHealth playerHealth;                     
	private float chaseTimer;                             
	private float patrolTimer;                          
	private int wayPointIndex;
	
	
	void Awake()
	{
		enemyLoc = GetComponent<Transform> ();
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth> ();
		anim = GetComponent<Animator> ();
		wayPointIndex = 0;
		powerUpActive = false;
		
		nav.destination = patrolWaypoints [wayPointIndex].position;
	}
	
	void Update() //state machine for AI
	{
		if(powerUpActive) //State 1: run away from player because player picked up power up
		{
			powerUpTimer += Time.deltaTime;
			
			if(powerUpTimer >= powerUpTime)
			{
				powerUpActive = false;
				powerUpTimer = 0f;
			}
			else
			{
				RunAway();
				anim.SetBool("playerInSight", true); //set running animation
			}
		}
		else if(enemySight.playerInSight || enemySight.playerHeard) //State 2: chase player because he is close
		{
			Chase();
			anim.SetBool("playerInSight", true); //set running animation
		}
		else //State 3: patrol waypoints
		{
			Patroll();
			anim.SetBool("playerInSight", false); //set running animation
		}
	}
	
	void Chase()
	{
		nav.destination = player.position;
		nav.speed = chaseSpeed;
	}
	
	void Patroll()
	{
		nav.speed = patrolSpeed;
		
		if(nav.remainingDistance < nav.stoppingDistance) //Enemy is close to the destination waypoint
		{
			patrolTimer += Time.deltaTime;
			
			if(patrolTimer >= patrolWaitTime)
			{
				wayPointIndex = Random.Range(0, patrolWaypoints.Length - 1); //Choose next random waypoint
				
				patrolTimer = 0f;
			}
		}
		else
		{
			patrolTimer = 0f;
		}
		
		nav.destination = patrolWaypoints[wayPointIndex].position;
	}
	
	void RunAway()
	{
		if(nav.remainingDistance < nav.stoppingDistance)
		{
			nav.speed = chaseSpeed;
			
			int farthestWayPointIndex = 0;
			float farthestAway = 0f;
			
			for(int i = 0; i < patrolWaypoints.Length - 1; i++) //Find the farthest waypoint from Player to run to
			{
				float distance = Vector3.Distance(patrolWaypoints[i].position, player.position);
				
				if(distance > farthestAway)
				{
					farthestAway = distance;
					farthestWayPointIndex = i;
				}
			}
			
			float enemyDistance = Vector3.Distance(enemyLoc.position, player.position);
			
			if(enemyDistance < 15)
			{
				NavMeshPath newPath = new NavMeshPath ();
				int indexOfWaypoint = 0;
				
				if(FindPathAwayFromPlayer(ref newPath, ref indexOfWaypoint))
				{
					//Debug.Log("NEW PATH SET! Waypoint: " + indexOfWaypoint);
					nav.SetDestination(patrolWaypoints[indexOfWaypoint].position);
				}
				else
				{
					nav.SetDestination(patrolWaypoints[0].position);
				}
			}
			else
			{
				nav.destination = patrolWaypoints [farthestWayPointIndex].position;
			}
		}
	}
	
	bool FindPathAwayFromPlayer(ref NavMeshPath finalPath, ref int indexOfWaypoint)
	{
		NavMeshPath path = new NavMeshPath ();
		int cornersInFrontPlayer = 0;
		indexOfWaypoint = 0;
		
		for(int i = 0; i < patrolWaypoints.Length; i++)
		{
			if(nav.enabled)
			{
				nav.CalculatePath(patrolWaypoints[i].position, path); //loads path with the path from enemy to the player
			}
			else
			{
				return false;
			}
			
			Vector3 directionWaypoint = patrolWaypoints[i].position - player.position;
			
			int corners = 0;
			
			for(int j = 0; j < path.corners.Length; j++)
			{
				Vector3 direction = path.corners[j] - player.position;
				
				float angle = Vector3.Angle(direction, transform.forward);
				float waypointAngle = Vector3.Angle(directionWaypoint, transform.forward);
				
				if((angle < fieldOfViewAngle * 0.5f))
				{
					corners++;
				}
			}
			
			if(corners > cornersInFrontPlayer)
			{
				cornersInFrontPlayer = corners;
				finalPath = path;
				indexOfWaypoint = i;
			}
		}
		
		if(finalPath == null)
		{
			Debug.Log("FINALPATH IS NULL!");
			return false;
		}
		else
		{
			return true;
		}	
	}
}
