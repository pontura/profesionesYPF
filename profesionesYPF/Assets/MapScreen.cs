using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScreen : MonoBehaviour {

	void Start()
	{
	}
	public void Next()
	{
		Data.Instance.scenesManager.Next ();
	}
}
