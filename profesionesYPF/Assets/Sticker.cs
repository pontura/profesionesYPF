using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticker : MonoBehaviour {

	public Sprite sprite;
	public Transform container;
	public Stickers stickers;
	public bool restrictMovement;
	public Image image;

	public GameObject robot;
	public GameObject brujula;
	public GameObject metro;

	public Vector2 restrictions;

	public void Init(Stickers stickers, Sprite sprite, Vector2 restrictions)
	{
		robot.SetActive (false);
		brujula.SetActive (false);
		metro.SetActive (false);
		image.enabled = true;
		switch (sprite.name) {
		case "Sticker_robot":
			robot.SetActive (true);
			image.enabled = false;
			break;
		case "Sticker_brujula":
			brujula.SetActive (true);
			image.enabled = false;
			break;
		case "Sticker_metro":
			metro.SetActive (true);
			image.enabled = false;
			break;
		}
		print ("sprite::::::   " + sprite.name);

		this.sprite = sprite;
		this.restrictions = restrictions;
		this.stickers = stickers;
		image.sprite = sprite;
		image.SetNativeSize ();

//		GameObject newAsset = Instantiate (asset);
//		newAsset.transform.SetParent (container);
//		newAsset.transform.localScale = Vector3.one;
//		newAsset.transform.localPosition = Vector3.zero;

		if (restrictMovement) {
			restrictions = transform.position;
		}
	}
	public void Selected()
	{
		//this.sprite = image.sprite;
		if (restrictMovement) {
			restrictions = transform.position;
		}
		stickers.OnStickerSelected (this);
	}
}
