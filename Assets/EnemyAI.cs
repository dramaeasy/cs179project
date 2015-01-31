using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float patrolSpeed = 2f;
	public float chaseSpeed = 2f;
	public float chaseWaitTime = 2f;
	public float patrolWaitTime = 1f;
	public Transform [] patrolWaypoints;

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

		nav.destination = patrolWaypoints [wayPointIndex].position;
	}

	void Update()
	{
		if(enemySight.playerInSight || enemySight.playerHeard)
		{
			Chasing();
			anim.SetBool("playerInSight", true);
		}
		else
		{
			Patrolling();
			anim.SetBool("playerInSight", false);
		}
	}

	void Chasing()
	{
		nav.destination = player.position;
		nav.speed = chaseSpeed;
	}

	void Patrolling()
	{
		nav.speed = patrolSpeed;

		if(nav.remainingDistance < nav.stoppingDistance)
		{
			patrolTimer += Time.deltaTime;

			if(patrolTimer >= patrolWaitTime)
			{
				wayPointIndex = Random.Range(0, patrolWaypoints.Length - 1);
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
}
