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

		Events.BackClicked += BackClicked;
		Data.Instance.scenesManager.ShowDoubleNavigation ();
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.stickers+1000);

		foreach (string iconName in Data.Instance.carrera.sctickers_tags) {
			StickerButton newSticker = Instantiate(stickerTag, Vector3.zero, Quaternion.identity, container_tags);
			Sprite s = Resources.Load("stickers/" + iconName, typeof(Sprite)) as Sprite;
			newSticker.Init (this, s);
		}
		foreach (string iconName in Data.Instance.carrera.sctickers_icons) {
			StickerButton newSticker = Instantiate(stickerIcon, Vector3.zero, Quaternion.identity, container_icons);
			Sprite s = Resources.Load("stickers/" + iconName, typeof(Sprite)) as Sprite;
			newSticker.Init (this, s);
		}
	}
	void OnDestroy(){
		Events.BackClicked -= BackClicked;
	}
	public void OnStickerSelected(Sticker sticker)
	{
		all.Remove (sticker);
		Destroy (sticker.gameObject);
		draggerManager.OnItemSelected (sticker.sprite, sticker.restrictions);
	}
	public void OnItemSelected(Sprite asset)
	{
		draggerManager.OnItemSelected (asset, Vector2.zero);
	}
	public void AddSticker (Sprite sprite, Vector3 pos, Vector2 restrictMovement)
	{
		Sticker newSticker = Instantiate(sticker, pos, Quaternion.identity, stickersContainer);
		all.Add (newSticker);
		newSticker.Init (this, sprite, restrictMovement);
	}
	bool done;
	public void BackClicked()
	{
		if (done)
			return;
		done = true;
		buttonsPanel.SetActive (false);
		draggerManager.dragger.SetActive (false);
		Data.Instance.screenshotManager.Init (true);
		Invoke ("Next", 0.5f);
	}
	void Next()
	{
		Data.Instance.scenesManager.JumpNext ();
	}
}
