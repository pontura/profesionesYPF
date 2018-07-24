using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour {

	public GameObject faceModelMesh;
	public FacetrackingManager facetrackingManager;
	public CharacterInScene characterInScene;
	public HeadCharacter headCharacter;

	public void SetPhoto()
	{
		facetrackingManager.pauseModelMeshUpdates = true;
		facetrackingManager.getFaceModelData = false;
		headCharacter.Init(faceModelMesh);
		Invoke ("Delayed", 1);
		characterInScene.Init (headCharacter);
	}
	public void Reset()
	{
		Destroy (facetrackingManager.gameObject);

	}
}
