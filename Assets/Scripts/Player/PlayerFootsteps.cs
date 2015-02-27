using UnityEngine;
using System.Collections;

public class PlayerFootsteps : MonoBehaviour {

	public AudioClip ground;

	bool step = true;
	bool playing = false;
	float audioLength = 0.6f;
	float elapTime = 0f;

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		CharacterController controller = GetComponent<CharacterController> ();

		if (controller.isGrounded && controller.velocity.magnitude < 7 && 
		    controller.velocity.magnitude > 5 && hit.gameObject.tag == "Untagged" && step == true) 
		{
			walkOnGround();
		}
	}

	IEnumerator WaitForFootSteps(float stepsLength) { step = false; yield return new WaitForSeconds(stepsLength); step = true; }

	void walkOnGround()
	{
			//Debug.Log(elapTime + " seconds");
			audio.clip = ground;
			audio.Play();
			StartCoroutine(WaitForFootSteps(audioLength));
	}

	void Update()
	{

	}
	
}
