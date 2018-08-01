using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupa : MonoBehaviour {

	public Transform lookAtTarget;

	void Start () {
		
	}

	void LateUpdate () {
		transform.LookAt(lookAtTarget.transform);
	}
}
