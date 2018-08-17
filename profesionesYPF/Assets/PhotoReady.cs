using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoReady : MonoBehaviour {

	public Image image;
	public RawImage rawImage;
	public Text title;

	void Start()
	{		
		title.text = Data.Instance.texts.photo_ready_title + " " + Data.Instance.texts.photo_ready_subtitle;

		Data.Instance.scenesManager.ShowDoubleNavigation ();
		image.material.mainTexture = Data.Instance.texture2d;
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.photoReady);
	}

	void Next()
	{
		Data.Instance.scenesManager.Next ();
	}
}