using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stickers : MonoBehaviour {

	public RawImage rawImage;
	public DraggerManager draggerManager;
	public Transform stickersContainer;
	public Sticker sticker;
	public List<Sticker> all;

	void Start () {
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.stickers);
		rawImage.texture = Data.Instance.texture2d;
	}
	public void OnStickerSelected(Sticker sticker)
	{
		all.Remove (sticker);
		Destroy (sticker.gameObject);
		draggerManager.OnItemSelected (sticker.image.sprite);
	}
	public void OnItemSelected(Sprite sr)
	{
		draggerManager.OnItemSelected (sr);
	}
	public void AddSticker (Sprite sprite, Vector3 pos)
	{
		Sticker newSticker = Instantiate(sticker, pos, Quaternion.identity, stickersContainer);
		all.Add (newSticker);
		newSticker.Init (this, sprite);
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
