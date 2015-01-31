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
		powerUpActive = true;

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
				Debug.Log(wayPointIndex);

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

		nav.destination = patrolWaypoints [farthestWayPointIndex].position;
	}
}
