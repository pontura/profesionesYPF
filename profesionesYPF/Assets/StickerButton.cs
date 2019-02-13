using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickerButton : MonoBehaviour {

	public Stickers stickers;
	public Image image;
	public Sprite asset;



	public void Init (Stickers stickers,  Sprite asset) {
		
		this.asset = asset;
		image.sprite = asset;
		image.SetNativeSize ();
		float scaler = 0.3f;

		if(asset.name == "Sticker_tubogrande" || asset.name == "Sticker_picogrande")
			image.transform.localScale = new Vector3 (scaler/2, scaler/2, scaler/2);
		else
			image.transform.localScale = new Vector3 (scaler, scaler, scaler);
		this.stickers = stickers;
	}
	public void OnClicked()
	{
		stickers.OnItemSelected (asset);
	}
}
