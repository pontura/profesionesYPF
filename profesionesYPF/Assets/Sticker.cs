using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticker : MonoBehaviour {

	public GameObject asset;
	public Transform container;
	public Stickers stickers;
	public bool restrictMovement;

	public Vector2 restrictions;

	public void Init(Stickers stickers, GameObject asset, Vector2 restrictions)
	{
		this.asset = asset;
		this.restrictions = restrictions;
		this.stickers = stickers;
		GameObject newAsset = Instantiate (asset);
		newAsset.transform.SetParent (container);
		newAsset.transform.localScale = Vector3.one;
		newAsset.transform.localPosition = Vector3.zero;

		if (restrictMovement) {
			restrictions = transform.position;
		}
	}
	public void Selected()
	{
		if (restrictMovement) {
			restrictions = transform.position;
		}
		stickers.OnStickerSelected (this);
	}
}
