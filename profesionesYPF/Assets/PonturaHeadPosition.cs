using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonturaHeadPosition : MonoBehaviour {

	public FacetrackingManager faceTrackingManager;
	public Vector3 offset;
	public GameObject faceModelMesh;

	void Update () {
		//transform.localPosition = faceTrackingManager.myHeadPosition + offset;
		faceModelMesh.transform.localPosition = transform.localPosition;
	}
}
