using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuzzlePiecesUI : MonoBehaviour {
	
	Text text;
	int puzzlePiecesLeft;
	
	void Awake()
	{
		text = GetComponent<Text> ();
	}
	
	void Update () 
	{
		puzzlePiecesLeft = Select.totalPuzPieces - Select.puz_piece;
		text.text = "Puzzle Pieces Left: " + puzzlePiecesLeft;
	}
}
