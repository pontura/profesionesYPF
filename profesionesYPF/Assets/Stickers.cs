using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stickers : MonoBehaviour {

	public Text title;
	public GameObject buttonsPanel;
	public RawImage rawImage;
	public DraggerManager draggerManager;
	public Transform stickersContainer;
	public Transform stickersContainerWithRestrictions;
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

	public GameObject carrearasContainer;
	public List<CarreraInSticker> carreras_default_icons;


	void Start () {

		foreach (CarreraInSticker go in carrearasContainer.GetComponentsInChildren<CarreraInSticker>())
			carreras_default_icons.Add (go);
		
		foreach (CarreraInSticker go in carreras_default_icons) 
			go.gameObject.SetActive (false);

		carreras_default_icons [Data.Instance.carrera.id-1].gameObject.SetActive (true);
		
		title.text = Data.Instance.texts.stickers_title;

		//Events.BackClicked += BackClicked;
		Data.Instance.scenesManager.ShowSimpleNavigation ();
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.stickers);


		foreach (string iconName in  Data.Instance.texts.iconos_tags) {
			StickerButton newSticker = Instantiate(stickerTag, Vector3.zero, Quaternion.identity, container_tags);
			Sprite s = Resources.Load("stickers/hashtags/" + iconName, typeof(Sprite)) as Sprite;
			newSticker.Init (this, s);
		}
		foreach (string iconName in Data.Instance.texts.iconos_generics) {
			StickerButton newSticker = Instantiate(stickerIcon, Vector3.zero, Quaternion.identity, container_icons_generics);
			Sprite s = Resources.Load("stickers/generics/" + iconName, typeof(Sprite)) as Sprite;
			newSticker.Init (this, s);
		}
		foreach (string iconName in Data.Instance.carrera.stickers_icons) {
			StickerButton newSticker = Instantiate(stickerIcon, Vector3.zero, Quaternion.identity, container_icons);
			Sprite s = Resources.Load("stickers/" + iconName, typeof(Sprite)) as Sprite;
			newSticker.Init (this, s);
		}
	}
	void OnDestroy(){
		//Events.BackClicked -= BackClicked;
	}
	bool adding;
	public void OnStickerSelected(Sticker sticker)
	{		
		if (adding)
			return;
		adding = true;
		draggerManager.OnItemSelected (sticker.sprite, sticker.restrictions, sticker.transform);

		all.Remove (sticker);
		Destroy (sticker.gameObject);
	}
	public void OnItemSelected(Sprite asset)
	{
		adding = true;
		Transform t = transform;
		t.localEulerAngles = Vector3.zero;
		t.localScale = Vector3.one;
		draggerManager.OnItemSelected (asset, Vector2.zero, t);
	}
	public void AddSticker (Sprite sprite, Vector3 pos, Vector3 rot, Vector3 _scale, Vector2 restrictMovement)
	{
		adding = false;
	//	print ("AddSticker " + sprite + " " + pos + " " + rot + " " + _scale + " " + restrictMovement);

		Sticker newSticker;
		if (restrictMovement == Vector2.zero)
			newSticker = Instantiate (sticker, pos, Quaternion.identity, stickersContainer);
		else
			newSticker = Instantiate (sticker, pos, Quaternion.identity, stickersContainerWithRestrictions);
		
		all.Add (newSticker);
		newSticker.Init (this, sprite, restrictMovement);
		newSticker.transform.localScale = _scale;

		//if (restrictMovement == Vector2.zero)
			newSticker.transform.localEulerAngles = rot;
		//else
			//newSticker.transform.localEulerAngles =  Vector3.zero;
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
