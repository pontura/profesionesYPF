using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public KinectManager kinectManager;

	void Start () {
		Invoke ("Delayed", 0.5f);
	}
	
	void Delayed()
	{
		kinectManager.computeUserMap = KinectManager.UserMapType.CutOutTexture;
	}
}
