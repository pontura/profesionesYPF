﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stickers : MonoBehaviour {

	public Text title;
	public GameObject buttonsPanel;
	public RawImage rawImage;
	public DraggerManager draggerManager;
	public Transform stickersContainer;
	public Transform container_icons_generics;

	public Sticker sticker;
	public StickerButton stickerTag;
	public StickerButton stickerIcon;

	public List<Sticker> all;
	public RenderTexture rt;
	public Texture2D myTexture2D;
	public SpriteRenderer sr;
	public Transform container_tags;
	public Transform container_icons;


	void Start () {
		
		title.text = Data.Instance.texts.stickers_title;

		//Events.BackClicked += BackClicked;
		Data.Instance.scenesManager.ShowSimpleNavigation ();
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.stickers+1000);

		string[] sctickers_icons;

		if(Data.Instance.results.x == 1) 
			sctickers_icons = Data.Instance.texts.iconos_cat_1;
		if(Data.Instance.results.x == 2) 
			sctickers_icons = Data.Instance.texts.iconos_cat_2;
		if(Data.Instance.results.x == 3) 
			sctickers_icons = Data.Instance.texts.iconos_cat_3;
		else 
			sctickers_icons = Data.Instance.texts.iconos_cat_4;

		foreach (string iconName in  Data.Instance.texts.iconos_tags) {
			StickerButton newSticker = Instantiate(stickerTag, Vector3.zero, Quaternion.identity, container_tags);
			Sprite s = Resources.Load("stickers/" + iconName, typeof(Sprite)) as Sprite;
			newSticker.Init (this, s);
		}
		foreach (string iconName in Data.Instance.texts.iconos_generics) {
			StickerButton newSticker = Instantiate(stickerIcon, Vector3.zero, Quaternion.identity, container_icons_generics);
			Sprite s = Resources.Load("stickers/" + iconName, typeof(Sprite)) as Sprite;
			newSticker.Init (this, s);
		}
		foreach (string iconName in sctickers_icons) {
			StickerButton newSticker = Instantiate(stickerIcon, Vector3.zero, Quaternion.identity, container_icons);
			Sprite s = Resources.Load("stickers/" + iconName, typeof(Sprite)) as Sprite;
			newSticker.Init (this, s);
		}
	}
	void OnDestroy(){
		//Events.BackClicked -= BackClicked;
	}
	public void OnStickerSelected(Sticker sticker)
	{		
		print ("__OnStickerSelected " + sticker);

		draggerManager.OnItemSelected (sticker.sprite, sticker.restrictions);

		all.Remove (sticker);
		Destroy (sticker.gameObject);
	}
	public void OnItemSelected(Sprite asset)
	{
		print ("OnItemSelected " + asset);
		draggerManager.OnItemSelected (asset, Vector2.zero);
	}
	public void AddSticker (Sprite sprite, Vector3 pos, Vector2 restrictMovement)
	{
		print ("AddSticker " + sprite);

		Sticker newSticker = Instantiate(sticker, pos, Quaternion.identity, stickersContainer);
		all.Add (newSticker);
		newSticker.Init (this, sprite, restrictMovement);
	}

	bool done;
	public void Back()
	{
		if (done)
			return;
		done = true;
		Data.Instance.scenesManager.JumpBack ();
	}
	public void Next()
	{
		if (done)
			return;
		done = true;
		buttonsPanel.SetActive (false);
		draggerManager.dragger.SetActive (false);
		Data.Instance.screenshotManager.Init (true);
		Invoke ("NextDone", 0.5f);
	}
	void NextDone()
	{
		Data.Instance.scenesManager.JumpNext();
	}
}
