using UnityEngine;
using System.Collections;

public class PowerUpRotate : MonoBehaviour {

	Transform trans;
	public float speed = 100f;

	void Awake()
	{
		trans = GetComponent<Transform> ();
	}

	void Update()
	{
		trans.Rotate (Vector3.left, speed * Time.deltaTime);
	}
}
