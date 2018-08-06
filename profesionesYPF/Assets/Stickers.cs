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
	public void Done()
	{
		Data.Instance.scenesManager.Next ();
	}
}
