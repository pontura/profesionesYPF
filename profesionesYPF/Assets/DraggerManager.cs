using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggerManager : MonoBehaviour {

	public GameObject dragger;
	Sprite sprite;

	public Image image;
	public bool dragging;

	public float initalDistance;
	public float scaleValue;
	public bool doubleTouchOn;
	public float angleValue;

	Stickers stickers;
	Vector2 restrictions;
	float offset = 20;

	public GameObject lookAtObject;

	void Start()
	{
		stickers = GetComponent<Stickers> ();
	}
	void Update () {	
		
		lookAtObject.transform.LookAt (Input.mousePosition);
		angleValue = lookAtObject.transform.localEulerAngles.x;

		if (Input.touchCount > 1) {
			Vector2 pos1 = Input.touches [0].position;
			Vector2 pos2 = Input.touches [1].position;

			if (!doubleTouchOn) {
				doubleTouchOn = true;
				initalDistance = Vector2.Distance (pos1, pos2);
			} else {
				scaleValue = initalDistance - Vector2.Distance (pos1, pos2);
			}


		} else {
			doubleTouchOn = false;
		}
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
			stickers.AddSticker (sprite, dragger.transform.position, new Vector3(angleValue,-90,0), restrictions);
		}
		dragging = false;
		sprite = null;
		image.sprite = null;
		dragger.transform.position = new Vector2 (2000, -2000);
	}
}
