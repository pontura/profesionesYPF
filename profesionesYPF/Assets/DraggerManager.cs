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
	float scaleValue = 1;
	public bool doubleTouchOn;

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
		dragger.transform.localEulerAngles = Vector3.zero;
		scaleValue = 1;
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

		} else {
			doubleTouchOn = false;
		}
		if (Input.GetMouseButtonDown (0)) {
			dragging = true;
		} else if (dragging && Input.GetMouseButtonUp (0) && Input.touchCount == 0) {
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
		scaleValue = t.localScale.x;
		dragger.transform.localEulerAngles = new Vector3(0,Random.Range(0,300),0);
		dragger.transform.localScale = t.localScale;
		dragger.transform.localEulerAngles = t.localEulerAngles;
	}
	public void StopDragging()
	{
		Vector3 sc = new Vector3 (scaleValue, scaleValue, scaleValue);

		if(restrictions != Vector2.zero)
		{
			dragger.transform.localEulerAngles = Vector3.zero;
			sc = Vector3.one;
		}
		
		if (sprite == null) {
			print ("StopDragging NO hay sprite");
		} else {
			stickers.AddSticker (sprite, dragger.transform.position, dragger.transform.localEulerAngles, sc , restrictions);
		}

		dragger.transform.localEulerAngles = Vector3.zero;
		dragging = false;
		sprite = null;
		image.sprite = null;
		dragger.transform.position = new Vector2 (2000, -2000);
		ResetDragger ();
	}
}
