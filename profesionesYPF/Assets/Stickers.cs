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
	public RenderTexture rt;
	public Texture2D myTexture2D;
	public SpriteRenderer sr;

	void Start () {
		//Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.stickers);
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
