using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stickers : MonoBehaviour {

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
		Data.Instance.scenesManager.ShowDoubleNavigation ();
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.stickers);

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

	public void OnStickerSelected(Sticker sticker)
	{
		all.Remove (sticker);
		Destroy (sticker.gameObject);
		draggerManager.OnItemSelected (sticker.gameObject);
	}
	public void OnItemSelected(GameObject asset)
	{
		draggerManager.OnItemSelected (asset);
	}
	public void AddSticker (GameObject asset, Vector3 pos)
	{
		Sticker newSticker = Instantiate(sticker, pos, Quaternion.identity, stickersContainer);
		all.Add (newSticker);
		newSticker.Init (this, asset);
	}
	bool done;
	public void Done()
	{
		if (done)
			return;
		done = true;
		Data.Instance.screenshotManager.Init (true);
		Invoke ("Next", 0.5f);
	}
	void Next()
	{
		Data.Instance.scenesManager.Next ();
	}
}
