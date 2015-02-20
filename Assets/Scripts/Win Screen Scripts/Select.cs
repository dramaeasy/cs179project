using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	public static int totalPuzPieces = 6;
	public static int puz_piece = 0;
	public static bool powerup_got = false;
	public RaycastHit hit;

	void Update () {
		if (puz_piece >= totalPuzPieces) {
			Application.LoadLevel("Win_screen");	
		}
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
	
		if (Physics.Raycast (ray, out hit, 10)) {
			if ( hit.collider.gameObject.GetComponent<Interact>()!= null )
			{

				hit.collider.gameObject.GetComponent<Interact>().OnLookEnter();	
				Debug.Log( puz_piece );

			}
		}

		
	}
}
