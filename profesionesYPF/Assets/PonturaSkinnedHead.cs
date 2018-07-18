using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonturaSkinnedHead : MonoBehaviour {

	public MeshFilter meshFilter;
	public SkinnedMeshRenderer myMesh;

	void Start () {
		
	}

	void Update () {
		myMesh.sharedMesh = meshFilter.mesh;
	}
}
