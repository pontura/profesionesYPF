using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonturaHeadPosition : MonoBehaviour {

	public FacetrackingManager faceTrackingManager;
	public Vector3 offset;
	public GameObject faceModelMesh;

	void Update () {
		transform.rotation = Quaternion.Lerp(transform.rotation, faceTrackingManager.GetHeadRotation(true), 0.2f);
	}
}
