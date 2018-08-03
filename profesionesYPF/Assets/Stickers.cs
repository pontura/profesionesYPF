using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stickers : MonoBehaviour {

	public RawImage rawImage;
	public DraggerManager draggerManager;

	void Start () {
		rawImage.texture = Data.Instance.texture2d;
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
