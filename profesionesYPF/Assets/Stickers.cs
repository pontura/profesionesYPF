using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickers : MonoBehaviour {

	public DraggerManager draggerManager;

	void Start () {
		
	}
	
	public void OnItemSelected(Sprite sr)
	{
		draggerManager.OnItemSelected (sr);
	}

	public void Done()
	{
		Data.Instance.scenesManager.Next ();
	}
}
