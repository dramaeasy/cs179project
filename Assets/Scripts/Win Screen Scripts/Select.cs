using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	public static int totalPuzPieces = 25;
	public static int puz_piece = 0;
	public static bool powerup_got = false;
	public RaycastHit hit;

	public static int level = 0;

	void Update () {

		if (puz_piece >= totalPuzPieces) 
		{
			if(level == 0)
			{
				totalPuzPieces = 20;
				puz_piece = 0;
				powerup_got = false;
				Application.LoadLevel("Level02");
				level++;
			}
			else
			{
				Application.LoadLevel("WinScreen");
			}
		}
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
	
		if (Physics.Raycast (ray, out hit, 10)) {
			if ( hit.collider.gameObject.GetComponent<Interact>()!= null )
			{

				hit.collider.gameObject.GetComponent<Interact>().OnLookEnter();	
				Debug.Log( puz_piece );

			}
		}

		if(powerup_got)
		{
			GhostChase.ghostChaseTimer = 0f;
		}
	}

	void Reset()
	{
		totalPuzPieces = 25;
		puz_piece = 0;
		powerup_got = false;
		level = 0;
	}
}
