using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticker : MonoBehaviour {

	public Image image;
	Stickers stickers;
	public void Init(Stickers stickers, Sprite sprite)
	{
		this.stickers = stickers;
		image.sprite = sprite;
	}
	public void Selected()
	{
		stickers.OnStickerSelected (this);
	}
}
