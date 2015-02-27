using UnityEngine;
using System.Collections;

public class EnemyColor : MonoBehaviour {

	public float blinkTime = 1f;

	MeshRenderer mesh;
	float timer = 0f;
	Transform trans;
	EnemyAI enemyai;

	void Awake () 
	{
		mesh = GetComponent<MeshRenderer> ();
		trans = GetComponent<Transform> ();
		enemyai = GetComponentInParent<EnemyAI> ();
	}

	void Update () 
	{
		if(Select.powerup_got && !enemyai.enemyDead) //blink between red and blue if player has picked up the power up
		{
			trans.localScale = new Vector3(8f, 8f, 8f);
			timer += Time.deltaTime;

			renderer.material.color = Color.blue;
		}
		else if(enemyai.enemyDead)
		{
			trans.localScale = new Vector3(3f, 3f, 3f);
			renderer.material.color = Color.green;
		}
		else
		{
			trans.localScale = new Vector3(8f, 8f, 8f);
			renderer.material.color = Color.red;
		}
	}
}
