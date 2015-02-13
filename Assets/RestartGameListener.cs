using UnityEngine;
using System.Collections;

public class RestartGameListener : MonoBehaviour {

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
				Select.puz_piece = 0;
				Application.LoadLevel ("HorrorGameOutsideLevel"); 
		}
	}
}
