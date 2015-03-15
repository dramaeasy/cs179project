using UnityEngine;
using System.Collections;

public class PuzzlePieceSpinning : MonoBehaviour {

	public float speed;
	Transform trans;

	void Awake () 
	{
		trans = GetComponent<Transform> ();
	}

	void Update () 
	{
		trans.Rotate (Vector3.up, speed * Time.deltaTime);
	}
}
