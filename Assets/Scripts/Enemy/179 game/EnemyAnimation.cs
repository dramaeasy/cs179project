
using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour 
{
	public float deadZone = 5f;

	private Transform player;
	private EnemySight enemySight;
	private NavMeshAgent nav;
	//private Animator anim;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		//anim = GetComponent<Animator> ();
		
		deadZone *= Mathf.Deg2Rad;
	}

	void Update()
	{
		NavAnimSetup ();
	}

	void onAnimatorMove()
	{
//		nav.velocity = anim.deltaPosition / Time.deltaTime;
//		transform.rotation = anim.rootRotation;
	}

	void NavAnimSetup()
	{
		float speed;
		float angle;

		if(enemySight.playerInSight)
		{
			speed = 0f;

			angle = FindAngle(transform.forward, player.position - transform.position, transform.up);
		}
		else
		{
			speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;

			angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);

			if(Mathf.Abs (angle) < deadZone)
			{
				transform.LookAt (transform.position + nav.desiredVelocity);
				Vector3 rot = new Vector3(170, transform.localPosition.y, transform.localPosition.z); 
				angle = 0f;
			}
		}
	}

	float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector)
	{
		if(toVector == Vector3.zero)
		{
			return 0f;
		}

		float angle = Vector3.Angle (fromVector, toVector);
		Vector3 normal = Vector3.Cross (fromVector, toVector);
		angle *= Mathf.Sign(Vector3.Dot(normal, upVector));
		angle *= Mathf.Deg2Rad;

		return angle;
	}
}
