using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonturaHead : MonoBehaviour {

	public Vector3 offset;
	public Vector3 offset_rot;
	public Transform container;

	void Start () {
		//offset
		offset_rot = Vector3.zero;
	}

	void LateUpdate () {
		Vector3 rot = container.transform.localEulerAngles;
		Vector3 myRot = transform.localEulerAngles;
		if (rot.y > 0 && rot.y < 180) {
			myRot.y = offset_rot.y - (rot.y/8);
		} else if (rot.y > 180) {
			float _newRot = 360 - rot.y;
			myRot.y =  offset_rot.y + (_newRot/8);
		}
		if (rot.z > 0 && rot.z < 180) {
			myRot.z = offset_rot.z - (rot.z/2);
		} else if (rot.z > 180) {
			float _newRot = 360 - rot.z;
			myRot.z =  offset_rot.z + (_newRot/2);
		}
		if (rot.x > 0 && rot.x < 180) {
			myRot.x = offset_rot.x + (rot.x/2);
		} else if (rot.x > 180) {
			float _newRot = 360 - rot.x;
			myRot.x =  offset_rot.x - (_newRot/2);
		}
		myRot.x *= -1;
		transform.localEulerAngles = myRot;
	}
}
