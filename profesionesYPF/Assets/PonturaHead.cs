using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonturaHead : MonoBehaviour {

	public Vector3 offset;
	public Vector3 offset_rot;
	public Transform container;

	void Start () {
		//offset
	}

	void Update () {
		Vector3 rot = container.transform.localEulerAngles;
		print (rot.z);


		Vector3 myRot = transform.localEulerAngles;

		if (rot.y > 0 && rot.y < 180) {
			myRot.y = offset_rot.y - (rot.y / 2);
		} else if (rot.y > 180) {
			float _newRot = 360 - rot.y;
			myRot.y =  offset_rot.y + (_newRot / 2);
		}
		if (rot.z > 0 && rot.z < 180) {
			myRot.x = offset_rot.x - (rot.z / 2);
		} else if (rot.z > 180) {
			float _newRot = 360 - rot.z;
			myRot.x =  offset_rot.x + (_newRot / 2);
		}
		if (rot.x > 0 && rot.x < 180) {
			myRot.z = offset_rot.z + (rot.x);
		} else if (rot.x > 180) {
			float _newRot = 360 - rot.x;
			myRot.z =  offset_rot.z - (_newRot);
		}
		transform.localEulerAngles = myRot;
	}
}
