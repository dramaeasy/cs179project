using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuzzlePiecesUI : MonoBehaviour {
	
	Text text;
	
	void Awake()
	{
		text = GetComponent<Text> ();
	}
	
	void Update () 
	{
		text.text = "Square Pieces: " + Select.puz_piece + " / " + Select.totalPuzPieces;
	}
}
