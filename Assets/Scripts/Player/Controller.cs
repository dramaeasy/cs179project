using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour {
	public float MoveSpeed;
	public float RotationSpeed;
	CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDir = Vector3.zero;
		moveDir.x = Input.GetAxis("Horizontal"); // get result of AD keys in X
		moveDir.z = Input.GetAxis("Vertical"); // get result of WS keys in Z
		//Vector3 forward = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward)*MoveSpeed;
		moveDir = transform.TransformDirection (moveDir.normalized) * MoveSpeed;
		transform.Rotate( new Vector3(0, Input.GetAxis("Mouse X")*RotationSpeed*Time.deltaTime,0) );
		cc.Move (moveDir * Time.deltaTime);
		cc.SimpleMove(Physics.gravity);

		if(Select.powerup_got)
		{
			MoveSpeed = 10;
		}
		else
		{
			MoveSpeed = 6;
		}
	}
}
