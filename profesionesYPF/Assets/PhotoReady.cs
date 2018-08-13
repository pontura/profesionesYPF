using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoReady : MonoBehaviour {

	public RawImage rawImage;

	void Start()
	{		
		rawImage.material.mainTexture = Data.Instance.texture2d;
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.results);
	}

	void Next()
	{
		Data.Instance.scenesManager.Next ();
	}
}