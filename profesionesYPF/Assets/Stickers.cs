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
	//	Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.stickers);
		//rawImage.material.mainTexture = Data.Instance.rt;

		//RenderTexture.active = rt;

//		RenderTexture.active = rt;
//		Texture2D myTexture2D = 
//		myTexture2D.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
////		myTexture2D.Apply();
////
//		Texture2D targetTexture= new Texture2D(350, 350);
//		GetComponent<Renderer>().material.mainTexture = targetTexture;
		
		for (int y = 0; y < 350; y++) {
			for (int x = 0; x < 350; x++) {
				print ( (rawImage.texture as Texture2D).GetPixel (x, y).a);
			}
		}

		myTexture2D.Apply();

		sr.material.mainTexture = myTexture2D;

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
