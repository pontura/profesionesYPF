using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggerManager : MonoBehaviour {

	public GameObject dragger;
	public GameObject asset;

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
		} else if (Input.GetMouseButtonUp (0)) {
			StopDragging ();
		}
		if (dragging && asset != null) {
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
	public void OnItemSelected(GameObject newAsset, Vector2 restrictions)
	{
		this.restrictions = restrictions;
		asset = Instantiate (newAsset);
		Utils.RemoveAllChildsIn (dragger.transform);
		asset.transform.SetParent (dragger.transform);
		asset.transform.localScale = Vector3.one;
		asset.transform.localPosition = Vector3.zero;
	}
	public void StopDragging()
	{
		if (asset == null)
			return;
		stickers.AddSticker (asset, dragger.transform.position, restrictions);
		dragging = false;
		asset = null;
		dragger.transform.position = new Vector2 (2000, -2000);
	}
}
