using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggerManager : MonoBehaviour {

	public GameObject dragger;
	public Image image;
	Sprite sprite;
	public bool dragging;
	Stickers stickers;

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
		if (dragging && sprite != null) {
			Vector2 pos = Input.mousePosition;
			dragger.transform.position = pos;
		} 
	}
	public void OnItemSelected(Sprite sr)
	{
		sprite = sr;
		image.sprite = sprite;
	}
	public void StopDragging()
	{
		if (sprite == null)
			return;
		stickers.AddSticker (sprite, dragger.transform.position);
		dragging = false;
		sprite = null;
		dragger.transform.position = new Vector2 (2000, -2000);
	}
}
