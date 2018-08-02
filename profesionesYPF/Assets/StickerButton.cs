using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerButton : MonoBehaviour {

	public Stickers stickers;
	public Sprite content;
	void Start () {
		
	}
	public void OnClicked()
	{
		stickers.OnItemSelected (content);
	}
}
