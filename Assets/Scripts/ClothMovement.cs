using UnityEngine;
using System.Collections;

public class ClothMovement : MonoBehaviour {
	public int start = 0;
	public int index = 0;
	public int increase = 1;

	private float val = 50f;
	private int shapeCount;
	private SkinnedMeshRenderer skinnedMeshRend;
	private Mesh clothMesh;

	void Start () 
	{
		skinnedMeshRend = GetComponent<SkinnedMeshRenderer>();
		clothMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
		shapeCount = clothMesh.blendShapeCount;
		skinnedMeshRend.updateWhenOffscreen = false;
	}

	void Update ()					// Traversing through each shape key/frame
	{ 
		skinnedMeshRend.SetBlendShapeWeight(index, 0.0f);	// Turn off previous shape key
		if(increase == 1) 			// Traversing down array
		{
			if(index < (shapeCount - 1)){
				index++;
			}
			else 					// access last shape key
			{  						//   then reverse traverse
				increase = 0;
				index--;
			}
		}
		else 						// Traversing up array
		{
			if(index > start){
				index--;
			}
			else
			{
				increase = 1;
				index++;
			}
		}
		skinnedMeshRend.SetBlendShapeWeight(index, val);	// Turn on current shape key
	}
}
