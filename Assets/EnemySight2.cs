using UnityEngine;
using System.Collections;

public class EnemySight2 : MonoBehaviour 
{
	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public bool playerHeard;
	public ResetPlayer reset;
	
	private GameObject enemy;
	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	private GameObject player;
	private PlayerHealth playerHealth;
	private Transform enemyLoc;
	private EnemyAI2 enemyai;
	private AudioSource audio;
	
	void Awake()
	{
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerInSight = false;
		enemy = GameObject.FindGameObjectWithTag ("Ghost1");
		enemyai = GetComponent<EnemyAI2> ();
		reset = player.GetComponent<ResetPlayer> ();
		enemyLoc = GetComponent<Transform> ();
		audio = GetComponent<AudioSource> ();
		audio.enabled = true;
	}
	
	
	void OnTriggerStay(Collider other) //Will be called every frame as long as player is in enemy sphere collider
	{
		
		if (other.gameObject == player && !enemyai.enemyDead) 
		{
			if(!audio.isPlaying)
			{
				audio.Play();
			}
			playerInSight = false;
			
			Vector3 direction = other.transform.position - transform.position; //Calculate vector from enemy to player
			float angle = Vector3.Angle(direction, transform.forward); 
			
			if(angle < fieldOfViewAngle * 0.5f) //Is player in cone in front of enemy? Right now its set to a sphere rather than cone.
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
				
			}
			
			if(CalculatePathLength(player.transform.position) <= 11.0)
			{
				playerHeard = true;
			}
			else
			{
				playerHeard = false;
			}
			
		}
		
		if(Vector3.Distance(other.transform.position, transform.position) <= 3)
		{
			if(Select.powerup_got)
			{
				enemyai.enemyDead= true;
			}
			else
			{
				if(PlayerLives.lives <= 0)
				{
					PlayerLives.lives = 0;
					Application.LoadLevel("GameOverLevel");
					
				}

				PlayerLives.lives--;
				reset.ResetPlayerPosition();
				nav.enabled = false;
				enemyLoc.position = new Vector3(0.22f, 0.32f, -1f);
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
	
	void Update()
	{
		if(!nav.enabled)
		{
			nav.enabled = true;
		}
	}
}
