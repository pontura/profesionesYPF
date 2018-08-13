using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickerButton : MonoBehaviour {

	public Stickers stickers;
	public GameObject asset;
	public Image image;

	public void Init (Stickers stickers,  Sprite asset) {
	//	this.asset = asset;
		image.sprite = asset;
		image.SetNativeSize ();
		this.stickers = stickers;
	}
	public void OnClicked()
	{
		stickers.OnItemSelected (asset);
	}
}
