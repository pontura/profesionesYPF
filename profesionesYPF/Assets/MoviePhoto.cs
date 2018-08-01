using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviePhoto : MonoBehaviour {

	public GameObject faceModelMesh;
	public KinectManager kinectManager;

	public void Done()
	{
		Destroy (kinectManager.gameObject);
		Invoke ("Delayed", 1);
	}
	void Delayed()
	{
		Data.Instance.scenesManager.Next ();
	}
}
