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
	float initialAngle;
	public float scaleValue;
	public bool doubleTouchOn;
	public float angleValue;

	Stickers stickers;
	Vector2 restrictions;
	float offset = 20;

	public int totalTouches;
	int allTouchesPosible = 2;
	float minScale = 0.5f;
	float maxScale = 2f;
	//public GameObject lookAtObject;

	void Start()
	{
		stickers = GetComponent<Stickers> ();
		Input.ResetInputAxes ();
	}
	void ResetDragger()
	{
		dragger.transform.localScale = Vector3.one;
		dragger.transform.localEulerAngles = new Vector3 (0, 90, 0);
		angleValue = 0;
		scaleValue = 1;
		initialAngle = 0;
	}
	void Update () {	
			totalTouches = Input.touchCount;
			Vector2 pos = Input.mousePosition;


		if (Input.touchCount > allTouchesPosible-1 && restrictions == Vector2.zero) {
	

			Vector2 pos1 = Input.touches [allTouchesPosible-2].position;
			Vector2 pos2 = Input.touches [allTouchesPosible-1].position;

			pos = (pos1+pos2)/2;

			if (!doubleTouchOn) {
				doubleTouchOn = true;
				initalDistance = Vector2.Distance (pos1, pos2);
				initialAngle = angleValue;
			} else {
				//lookAtObject.transform.LookAt (Input.touches [allTouchesPosible - 2].position);
				//angleValue = lookAtObject.transform.localEulerAngles.x - initialAngle;

				scaleValue = 1+(((initalDistance - Vector2.Distance (pos1, pos2)) *-1)/150);
				if (scaleValue < minScale)
					scaleValue = minScale;
				else if (scaleValue > maxScale)
					scaleValue = maxScale;
				dragger.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
			}
			dragger.transform.localEulerAngles = new Vector3 (-angleValue, 90, 0);

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
			//lookAtObject.transform.position = pos;
			dragger.transform.position = pos;
		} 
	}
	public void OnItemSelected(Sprite sprite, Vector2 restrictions, Transform t)
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

		print (t.localScale);

		dragger.transform.localScale = t.localScale;
		//dragger.transform.localEulerAngles = t.localEulerAngles;
		//}

//		asset = Instantiate (newAsset);
//		Utils.RemoveAllChildsIn (dragger.transform);
//		asset.transform.SetParent (dragger.transform);
//		asset.transform.localScale = Vector3.one;
//		asset.transform.localPosition = Vector3.zero;
	}
	public void StopDragging()
	{
		//angleValue = 0;
		Vector3 rot = new Vector3 (angleValue, -90, 0);
		Vector3 sc = new Vector3 (scaleValue, scaleValue, scaleValue);

		if(restrictions != Vector2.zero)
		{
			rot = new Vector3 (0, 90, 0);
			sc = Vector3.one;
		}
		
		if (sprite == null) {
			print ("StopDragging NO hay sprite");
		} else {
			stickers.AddSticker (sprite, dragger.transform.position, rot,sc , restrictions);
		}
		dragging = false;
		sprite = null;
		image.sprite = null;
		dragger.transform.position = new Vector2 (2000, -2000);
		ResetDragger ();
	}
}
