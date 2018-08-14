using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoReady : MonoBehaviour {

	public RawImage rawImage;

	void Start()
	{		
		Data.Instance.scenesManager.ShowDoubleNavigation ();
		rawImage.material.mainTexture = Data.Instance.texture2d;
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.photoReady);
	}

	void Next()
	{
		Data.Instance.scenesManager.Next ();
	}
}