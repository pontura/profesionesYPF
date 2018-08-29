using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggerManager : MonoBehaviour {

	public GameObject dragger;

	Sprite sprite;

	public Image image;

	public bool dragging;
	Stickers stickers;
	Vector2 restrictions;
	float offset = 20;
	void Start()
	{
		stickers = GetComponent<Stickers> ();
	}
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			dragging = true;
		} else if (dragging && Input.GetMouseButtonUp (0)) {
			StopDragging ();
		}
		if (dragging) {
			if (image.sprite == null)
				image.enabled = false;
			else
				image.enabled = true;
			
			Vector2 pos = Input.mousePosition;
			if (restrictions != Vector2.zero) {
				if(pos.x>restrictions.x+offset)
					pos.x = restrictions.x+offset;
				else if(pos.x<restrictions.x-offset)
					pos.x = restrictions.x-offset;
				if(pos.y>restrictions.y+offset)
					pos.y = restrictions.y+offset;
				else if(pos.y<restrictions.y-offset)
					pos.y = restrictions.y-offset;
			}

			dragger.transform.position = pos;
		} 
	}
	public void OnItemSelected(Sprite sprite, Vector2 restrictions)
	{
		if (sprite == null) {
			print ("no hay sprite");
			dragging = false;
			return;
		}
		this.restrictions = restrictions;
		this.sprite = sprite;
		image.sprite = sprite;
		image.SetNativeSize ();

//		asset = Instantiate (newAsset);
//		Utils.RemoveAllChildsIn (dragger.transform);
//		asset.transform.SetParent (dragger.transform);
//		asset.transform.localScale = Vector3.one;
//		asset.transform.localPosition = Vector3.zero;
	}
	public void StopDragging()
	{
		if (sprite == null) {
			print ("StopDragging NO hay sprite");
		} else {
			stickers.AddSticker (sprite, dragger.transform.position, restrictions);
		}
		dragging = false;
		sprite = null;
		image.sprite = null;
		dragger.transform.position = new Vector2 (2000, -2000);
	}
}
