using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticker : MonoBehaviour {

	public GameObject asset;
	public Transform container;
	public Stickers stickers;

	public void Init(Stickers stickers, GameObject asset)
	{
		this.asset = asset;
		this.stickers = stickers;
		GameObject newAsset = Instantiate (asset);
		newAsset.transform.SetParent (container);
		newAsset.transform.localScale = Vector3.one;
		newAsset.transform.localPosition = Vector3.zero;
	}
	public void Selected()
	{
		stickers.OnStickerSelected (this);
	}
}
