using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {

	void Start()
	{
		Invoke ("Delayed", 0.1f);
	}
	void Delayed()
	{
		Data.Instance.scenesManager.Next ();
	}
}
